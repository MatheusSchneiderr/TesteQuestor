namespace TesteQuestor.DTOs.Boleto;

public sealed record BoletoResponse(
    int Id,
    string NomePagador,
    string CpfCnpjPagador,
    string NomeBeneficiario,
    string CpfCnpjBeneficiario,
    decimal Valor,
    decimal ValorAtualizado,
    DateTime DataVencimento,
    string? Observacao,
    int BancoId,
    bool Vencido
);
