using System.ComponentModel.DataAnnotations;

namespace TesteQuestor.DTOs.Banco;

public sealed record CreateBancoRequest(
    [Required, StringLength(150, MinimumLength = 1)] string NomeBanco,
    [Required, StringLength(20, MinimumLength = 1)] string CodigoBanco,
    [Required, Range(0, 1000)] decimal? PercentualJuros
);
