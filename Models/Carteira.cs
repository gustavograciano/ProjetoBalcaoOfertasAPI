namespace ProjetoBalcaoOfertasAPI.Models
{
    public class Carteira
    {
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public decimal Saldo { get; set; }
        public string Moeda { get; set; }
    }
}
