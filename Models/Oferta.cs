public class Oferta
{
    public int Id { get; set; }
    public int Id_Usuario { get; set; }
    public int Id_Carteira { get; set; }
    public decimal Preco { get; set; }
    public int Id_Moeda { get; set; }
    public int Quantidade { get; set; }
    public DateTime Data_Criacao { get; set; }
    public bool Deletado { get; set; }
}
