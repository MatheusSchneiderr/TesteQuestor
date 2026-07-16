namespace TesteQuestor.DTOs.Banco;

public sealed record BancoResponse(
    int Id,
    string NomeBanco,
    string CodigoBanco,
    decimal PercentualJuros
);
