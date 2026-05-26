using AutoPrime.API.Models;
using AutoPrime.API.Models.Enums;

namespace AutoPrime.API.Repositories;

/// <summary>
/// Contrato específico do repositório de veículos.
/// Herda todas as operações genéricas de IRepository
/// e adiciona consultas específicas do domínio de veículos.
/// </summary>
public interface IVeiculoRepository : IRepository<Veiculo>
{
    /// <summary>Retorna apenas veículos com status Disponível.</summary>
    Task<IEnumerable<Veiculo>> ObterDisponiveisAsync();

    /// <summary>Busca por marca e/ou modelo (pesquisa textual parcial).</summary>
    Task<IEnumerable<Veiculo>> BuscarPorMarcaModeloAsync(string termo);

    /// <summary>Filtra veículos dentro de uma faixa de preço.</summary>
    Task<IEnumerable<Veiculo>> FiltrarPorPrecoAsync(decimal precoMin, decimal precoMax);

    /// <summary>Atualiza apenas o status do veículo (evita substituir o documento inteiro).</summary>
    Task<bool> AtualizarStatusAsync(string id, StatusVeiculo status);
}
