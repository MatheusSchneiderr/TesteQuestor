namespace TesteQuestor.Models;

public class Banco
{
    public int Id { get; set; }
    public string NomeBanco { get; set; } = null!;
    public string CodigoBanco { get; set; } = null!;
    public decimal PercentualJuros { get; set; }

    public ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();
}
