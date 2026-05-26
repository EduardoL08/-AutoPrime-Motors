using AutoPrime.API.Models;

namespace AutoPrime.API.Repositories;

public interface IUsuarioRepository : IRepository<Usuario>
{
    Task<Usuario?> ObterPorEmailAsync(string email);
    Task<bool> EmailJaCadastradoAsync(string email);
}
