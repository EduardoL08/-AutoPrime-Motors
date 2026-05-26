using AutoPrime.API.Models;

namespace AutoPrime.API.Repositories;

public interface IClienteRepository : IRepository<Cliente>
{
    /// <summary>Busca cliente pelo CPF (único no sistema).</summary>
    Task<Cliente?> ObterPorCpfAsync(string cpf);

    /// <summary>Busca cliente pelo email (único no sistema).</summary>
    Task<Cliente?> ObterPorEmailAsync(string email);

    /// <summary>Busca clientes por nome (parcial, case-insensitive).</summary>
    Task<IEnumerable<Cliente>> BuscarPorNomeAsync(string nome);
}
