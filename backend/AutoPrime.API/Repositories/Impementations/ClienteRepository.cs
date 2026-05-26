using MongoDB.Driver;
using AutoPrime.API.Models;

namespace AutoPrime.API.Repositories;

public class ClienteRepository : MongoRepository<Cliente>, IClienteRepository
{
    public ClienteRepository(IMongoDatabase database)
        : base(database, "clientes") { }

    public async Task<Cliente?> ObterPorCpfAsync(string cpf)
    {
        return await _collection
            .Find(c => c.Cpf == cpf)
            .FirstOrDefaultAsync();
    }

    public async Task<Cliente?> ObterPorEmailAsync(string email)
    {
        return await _collection
            .Find(c => c.Email == email.ToLower())
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Cliente>> BuscarPorNomeAsync(string nome)
    {
        var filtro = Builders<Cliente>.Filter.Regex(
            c => c.Nome,
            new MongoDB.Bson.BsonRegularExpression(nome, "i")
        );

        return await _collection
            .Find(filtro)
            .SortBy(c => c.Nome)
            .ToListAsync();
    }
}
