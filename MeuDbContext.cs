using Microsoft.EntityFrameworkCore;
using ProjetoBalcaoOfertasAPI.Models;

namespace BalcãoDeOfertasAPI
{
	public class MeuDbContext : DbContext
	{
		public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
		{
		}

		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Carteira> Carteiras { get; set; }
		public DbSet<Moeda> Moedas { get; set; }
		public DbSet<Oferta> Ofertas { get; set; }
	}
}
