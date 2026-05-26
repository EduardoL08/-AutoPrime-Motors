using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace AutoPrime.API.Repositories;

/// <summary>
/// Implementação base genérica do repositório para MongoDB.
/// 
/// PRINCÍPIO DRY (Don't Repeat Yourself):
/// Todo o código de acesso ao MongoDB fica aqui UMA VEZ.
/// Os repositórios específicos herdam este comportamento
/// e só adicionam o que for exclusivo de cada entidade.
/// 
/// PRINCÍPIO SRP (Single Responsibility — SOLID):
/// Esta classe tem uma única responsabilidade:
/// abstrair as operações CRUD do MongoDB Driver.
/// </summary>
public class MongoRepository<T> : IRepository<T> where T : class
{
    protected readonly IMongoCollection<T> _collection;

    /// <summary>
    /// O nome da collection é passado pelo repositório filho.
    /// Ex: VeiculoRepository passa "veiculos".
    /// </summary>
    public MongoRepository(IMongoDatabase database, string nomeColecao)
    {
        _collection = database.GetCollection<T>(nomeColecao);
    }

    public async Task<IEnumerable<T>> ObterTodosAsync()
    {
        return await _collection
            .Find(_ => true)
            .ToListAsync();
    }

    public async Task<T?> ObterPorIdAsync(string id)
    {
        // Filtramos pelo campo _id do MongoDB usando o ObjectId
        var filtro = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
        return await _collection.Find(filtro).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> filtro)
    {
        return await _collection.Find(filtro).ToListAsync();
    }

    public async Task<T> CriarAsync(T entidade)
    {
        await _collection.InsertOneAsync(entidade);
        return entidade;
    }

    public async Task<bool> AtualizarAsync(string id, T entidade)
    {
        var filtro = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
        var resultado = await _collection.ReplaceOneAsync(filtro, entidade);
        return resultado.ModifiedCount > 0;
    }

    public async Task<bool> DeletarAsync(string id)
    {
        var filtro = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
        var resultado = await _collection.DeleteOneAsync(filtro);
        return resultado.DeletedCount > 0;
    }

    public async Task<bool> ExisteAsync(Expression<Func<T, bool>> filtro)
    {
        return await _collection.Find(filtro).AnyAsync();
    }
}
