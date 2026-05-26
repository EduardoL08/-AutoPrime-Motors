using MongoDB.Driver;
using AutoPrime.API.Models;

namespace AutoPrime.API.Repositories;

public class UsuarioRepository : MongoRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(IMongoDatabase database)
        : base(database, "usuarios") { }

    public async Task<Usuario?> ObterPorEmailAsync(string email)
    {
        return await _collection
            .Find(u => u.Email == email.ToLower())
            .FirstOrDefaultAsync();
    }

    public async Task<bool> EmailJaCadastradoAsync(string email)
    {
        return await _collection
            .Find(u => u.Email == email.ToLower())
            .AnyAsync();
    }
}
