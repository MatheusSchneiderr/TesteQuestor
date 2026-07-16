using System.ComponentModel.DataAnnotations;
using TesteQuestor.Validation;

namespace TesteQuestor.DTOs.Boleto;

public sealed record CreateBoletoRequest(
    [Required, StringLength(150, MinimumLength = 1)] string NomePagador,
    [Required, CpfCnpj] string CpfCnpjPagador,
    [Required, StringLength(150, MinimumLength = 1)] string NomeBeneficiario,
    [Required, CpfCnpj] string CpfCnpjBeneficiario,
    [Required, Range(0.01, double.MaxValue)] decimal Valor,
    [Required] DateTime? DataVencimento,
    string? Observacao,
    [Required] int BancoId
);
