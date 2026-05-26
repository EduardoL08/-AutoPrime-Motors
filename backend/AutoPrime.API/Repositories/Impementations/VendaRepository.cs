using MongoDB.Driver;
using AutoPrime.API.Models;
using AutoPrime.API.Models.Enums;

namespace AutoPrime.API.Repositories;

public class VendaRepository : MongoRepository<Venda>, IVendaRepository
{
    public VendaRepository(IMongoDatabase database)
        : base(database, "vendas") { }

    public async Task<IEnumerable<Venda>> ObterPorClienteAsync(string clienteId)
    {
        return await _collection
            .Find(v => v.ClienteId == clienteId)
            .SortByDescending(v => v.DataVenda)
            .ToListAsync();
    }

    public async Task<IEnumerable<Venda>> ObterPorVeiculoAsync(string veiculoId)
    {
        return await _collection
            .Find(v => v.VeiculoId == veiculoId)
            .SortByDescending(v => v.DataVenda)
            .ToListAsync();
    }

    public async Task<IEnumerable<Venda>> ObterPorUsuarioAsync(string usuarioId)
    {
        return await _collection
            .Find(v => v.UsuarioId == usuarioId)
            .SortByDescending(v => v.DataVenda)
            .ToListAsync();
    }

    public async Task<IEnumerable<Venda>> ObterPorStatusAsync(StatusVenda status)
    {
        return await _collection
            .Find(v => v.Status == status)
            .SortByDescending(v => v.DataVenda)
            .ToListAsync();
    }

    public async Task<IEnumerable<Venda>> ObterPorPeriodoAsync(DateTime inicio, DateTime fim)
    {
        var filtro = Builders<Venda>.Filter.And(
            Builders<Venda>.Filter.Gte(v => v.DataVenda, inicio),
            Builders<Venda>.Filter.Lte(v => v.DataVenda, fim)
        );

        return await _collection
            .Find(filtro)
            .SortByDescending(v => v.DataVenda)
            .ToListAsync();
    }

    public async Task<bool> AtualizarStatusAsync(string id, StatusVenda status, string? observacoes)
    {
        var filtro = Builders<Venda>.Filter.Eq(v => v.Id, id);
        var update = Builders<Venda>.Update
            .Set(v => v.Status, status)
            .Set(v => v.AtualizadoEm, DateTime.UtcNow);

        if (observacoes is not null)
            update = update.Set(v => v.Observacoes, observacoes);

        var resultado = await _collection.UpdateOneAsync(filtro, update);
        return resultado.ModifiedCount > 0;
    }
}
