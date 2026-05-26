using MongoDB.Driver;
using AutoPrime.API.Models;
using AutoPrime.API.Models.Enums;

namespace AutoPrime.API.Repositories;

/// <summary>
/// Implementação concreta do repositório de veículos.
/// Herda o CRUD genérico do MongoRepository e implementa
/// os métodos específicos de veículos definidos na interface.
/// </summary>
public class VeiculoRepository : MongoRepository<Veiculo>, IVeiculoRepository
{
    public VeiculoRepository(IMongoDatabase database)
        : base(database, "veiculos") { }

    public async Task<IEnumerable<Veiculo>> ObterDisponiveisAsync()
    {
        return await _collection
            .Find(v => v.Status == StatusVeiculo.Disponivel)
            .SortByDescending(v => v.CriadoEm)
            .ToListAsync();
    }

    public async Task<IEnumerable<Veiculo>> BuscarPorMarcaModeloAsync(string termo)
    {
        // Busca case-insensitive usando regex do MongoDB
        var filtro = Builders<Veiculo>.Filter.Or(
            Builders<Veiculo>.Filter.Regex(v => v.Marca,
                new MongoDB.Bson.BsonRegularExpression(termo, "i")),
            Builders<Veiculo>.Filter.Regex(v => v.Modelo,
                new MongoDB.Bson.BsonRegularExpression(termo, "i"))
        );

        return await _collection
            .Find(filtro)
            .SortBy(v => v.Marca)
            .ToListAsync();
    }

    public async Task<IEnumerable<Veiculo>> FiltrarPorPrecoAsync(decimal precoMin, decimal precoMax)
    {
        var filtro = Builders<Veiculo>.Filter.And(
            Builders<Veiculo>.Filter.Gte(v => v.Preco, precoMin),
            Builders<Veiculo>.Filter.Lte(v => v.Preco, precoMax)
        );

        return await _collection
            .Find(filtro)
            .SortBy(v => v.Preco)
            .ToListAsync();
    }

    public async Task<bool> AtualizarStatusAsync(string id, StatusVeiculo status)
    {
        // Update parcial — altera apenas os campos necessários
        // sem substituir o documento inteiro (mais eficiente)
        var filtro = Builders<Veiculo>.Filter.Eq(v => v.Id, id);
        var update = Builders<Veiculo>.Update
            .Set(v => v.Status, status)
            .Set(v => v.AtualizadoEm, DateTime.UtcNow);

        var resultado = await _collection.UpdateOneAsync(filtro, update);
        return resultado.ModifiedCount > 0;
    }
}
