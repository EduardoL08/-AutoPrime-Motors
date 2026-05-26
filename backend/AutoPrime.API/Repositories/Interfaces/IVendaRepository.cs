using AutoPrime.API.Models;
using AutoPrime.API.Models.Enums;

namespace AutoPrime.API.Repositories;

public interface IVendaRepository : IRepository<Venda>
{
    /// <summary>Retorna todas as vendas de um cliente específico.</summary>
    Task<IEnumerable<Venda>> ObterPorClienteAsync(string clienteId);

    /// <summary>Retorna todas as vendas de um veículo específico.</summary>
    Task<IEnumerable<Venda>> ObterPorVeiculoAsync(string veiculoId);

    /// <summary>Retorna todas as vendas registradas por um vendedor.</summary>
    Task<IEnumerable<Venda>> ObterPorUsuarioAsync(string usuarioId);

    /// <summary>Filtra vendas por status (Pendente, Concluída, Cancelada).</summary>
    Task<IEnumerable<Venda>> ObterPorStatusAsync(StatusVenda status);

    /// <summary>Retorna vendas em um intervalo de datas.</summary>
    Task<IEnumerable<Venda>> ObterPorPeriodoAsync(DateTime inicio, DateTime fim);

    /// <summary>Atualiza apenas o status da venda.</summary>
    Task<bool> AtualizarStatusAsync(string id, StatusVenda status, string? observacoes);
}
