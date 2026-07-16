using AutoMapper;
using TesteQuestor.DTOs.Boleto;
using TesteQuestor.Exceptions;
using TesteQuestor.Models;
using TesteQuestor.Repositories;
using TesteQuestor.Validation;

namespace TesteQuestor.Services;

public class BoletoService(IBoletoRepository repository, IMapper mapper) : IBoletoService
{
    public async Task<BoletoResponse> CreateAsync(CreateBoletoRequest request)
    {
        if (!await repository.BancoExistsAsync(request.BancoId))
            throw new NotFoundException($"Banco com Id {request.BancoId} não encontrado.");

        var boleto = mapper.Map<Boleto>(request);
        boleto.CpfCnpjPagador = CpfCnpjAttribute.SomenteDigitos(boleto.CpfCnpjPagador);
        boleto.CpfCnpjBeneficiario = CpfCnpjAttribute.SomenteDigitos(boleto.CpfCnpjBeneficiario);

        var created = await repository.AddAsync(boleto);

        var fullBoleto = await repository.GetByIdAsync(created.Id)
            ?? throw new InvalidOperationException("Falha ao recuperar o boleto recém-criado.");

        return ToResponse(fullBoleto);
    }

    public async Task<BoletoResponse?> GetByIdAsync(int id)
    {
        var boleto = await repository.GetByIdAsync(id);
        return boleto is null ? null : ToResponse(boleto);
    }

    private static BoletoResponse ToResponse(Boleto boleto)
    {
        var vencido = DateTime.UtcNow.Date > boleto.DataVencimento.Date;
        var valorAtualizado = vencido
            ? boleto.Valor + boleto.Valor * (boleto.Banco.PercentualJuros / 100m)
            : boleto.Valor;

        return new BoletoResponse(
            boleto.Id,
            boleto.NomePagador,
            boleto.CpfCnpjPagador,
            boleto.NomeBeneficiario,
            boleto.CpfCnpjBeneficiario,
            boleto.Valor,
            valorAtualizado,
            boleto.DataVencimento,
            boleto.Observacao,
            boleto.BancoId,
            vencido
        );
    }
}
