namespace TesteQuestor.Models;

public class Boleto
{
    public int Id { get; set; }
    public string NomePagador { get; set; } = null!;
    public string CpfCnpjPagador { get; set; } = null!;
    public string NomeBeneficiario { get; set; } = null!;
    public string CpfCnpjBeneficiario { get; set; } = null!;
    public decimal Valor { get; set; }
    public DateTime DataVencimento { get; set; }
    public string? Observacao { get; set; }

    public int BancoId { get; set; }
    public Banco Banco { get; set; } = null!;
}
