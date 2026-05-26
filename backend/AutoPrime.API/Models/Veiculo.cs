using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using AutoPrime.API.Models.Enums;

namespace AutoPrime.API.Models;

/// <summary>
/// Representa um veículo no estoque da concessionária.
/// O atributo [BsonId] indica ao driver do MongoDB qual campo é o _id do documento.
/// O atributo [BsonRepresentation] converte o ObjectId do Mongo para string no C#.
/// </summary>
public class Veiculo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("marca")]
    public string Marca { get; set; } = string.Empty;

    [BsonElement("modelo")]
    public string Modelo { get; set; } = string.Empty;

    [BsonElement("ano")]
    public int Ano { get; set; }

    [BsonElement("cor")]
    public string Cor { get; set; } = string.Empty;

    [BsonElement("preco")]
    public decimal Preco { get; set; }

    [BsonElement("quilometragem")]
    public int Quilometragem { get; set; }

    /// <summary>
    /// Gravado como string no MongoDB para facilitar leitura dos documentos.
    /// Ex: "Disponivel", "Vendido" ao invés de 0, 1.
    /// </summary>
    [BsonElement("status")]
    [BsonRepresentation(BsonType.String)]
    public StatusVeiculo Status { get; set; } = StatusVeiculo.Disponivel;

    [BsonElement("descricao")]
    public string? Descricao { get; set; }

    /// <summary>
    /// Lista de URLs das imagens do veículo.
    /// Armazenada como array no documento MongoDB.
    /// </summary>
    [BsonElement("imagens")]
    public List<string> Imagens { get; set; } = [];

    [BsonElement("criadoEm")]
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    [BsonElement("atualizadoEm")]
    public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;
}
