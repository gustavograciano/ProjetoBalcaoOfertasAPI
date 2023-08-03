using BalcãoDeOfertasAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalcaoDeOfertasAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OfertasController : ControllerBase
	{
		private readonly MeuDbContext _dbContext;

		public OfertasController(MeuDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Oferta>>> GetOfertas()
		{
			var ofertas = await _dbContext.Ofertas
				.Where(o => !o.Deletado)
				.OrderByDescending(o => o.Data_Criacao)
				.ToListAsync();

			return Ok(ofertas);
		}

		[HttpPost]
		public async Task<ActionResult> CriarOferta(Oferta novaOferta)
		{
			var carteira = await _dbContext.Carteiras
				.FirstOrDefaultAsync(c => c.Id == novaOferta.Id_Carteira && c.Id_Usuario == novaOferta.Id_Usuario);

			if (carteira == null || carteira.Saldo < novaOferta.Preco * novaOferta.Quantidade)
			{
				return BadRequest("Saldo insuficiente na carteira.");
			}

			var ofertasDoDia = await _dbContext.Ofertas
				.Where(o => o.Id_Usuario == novaOferta.Id_Usuario && o.Data_Criacao.Date == DateTime.Now.Date)
				.CountAsync();

			if (ofertasDoDia >= 5)
			{
				return BadRequest("Limite diário de ofertas atingido.");
			}

			novaOferta.Data_Criacao = DateTime.Now;
			_dbContext.Ofertas.Add(novaOferta);
			await _dbContext.SaveChangesAsync();

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeletarOferta(int id)
		{
			var oferta = await _dbContext.Ofertas.FirstOrDefaultAsync(o => o.Id == id);

			if (oferta == null)
			{
				return NotFound();
			}

			if (oferta.Id_Usuario != 1 /* Aqui você deve validar o usuário atual */)
			{
				return Forbid();
			}

			oferta.Deletado = true;
			await _dbContext.SaveChangesAsync();

			return Ok();
		}
	}
}
