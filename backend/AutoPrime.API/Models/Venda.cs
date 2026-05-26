using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using AutoPrime.API.Models.Enums;

namespace AutoPrime.API.Models;

/// <summary>
/// Representa uma venda realizada na concessionária.
/// 
/// PADRÃO DE REFERÊNCIA NO MONGODB:
/// Em bancos relacionais usa chaves estrangeiras com JOIN.
/// No MongoDB, tem duas opções:
///   1. Embedding (embutir o documento inteiro) — bom para dados que raramente mudam
///   2. Referencing (guardar apenas o Id) — bom para dados que mudam frequentemente
/// 
/// Escolhir o REFERENCING porque:
/// - Veículos e Clientes têm seus próprios ciclos de vida
/// - Evita duplicação de dados
/// - O "join" é feito na camada de serviço (application-side join)
/// </summary>
public class Venda
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    /// <summary>
    /// Referência ao Veículo vendido.
    /// Armazena o Id (ObjectId como string) e um snapshot do nome
    /// para facilitar exibição sem precisar sempre buscar o veículo.
    /// </summary>
    [BsonElement("veiculoId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string VeiculoId { get; set; } = string.Empty;

    /// <summary>
    /// Snapshot: marca + modelo no momento da venda.
    /// Se o veículo for editado depois, o histórico da venda permanece correto.
    /// </summary>
    [BsonElement("veiculoDescricao")]
    public string VeiculoDescricao { get; set; } = string.Empty;

    /// <summary>
    /// Referência ao Cliente que comprou o veículo.
    /// </summary>
    [BsonElement("clienteId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ClienteId { get; set; } = string.Empty;

    /// <summary>
    /// Snapshot: nome do cliente no momento da venda.
    /// </summary>
    [BsonElement("clienteNome")]
    public string ClienteNome { get; set; } = string.Empty;

    /// <summary>
    /// Referência ao Usuário (vendedor) que registrou a venda.
    /// </summary>
    [BsonElement("usuarioId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string UsuarioId { get; set; } = string.Empty;

    /// <summary>
    /// Snapshot: nome do vendedor no momento da venda.
    /// </summary>
    [BsonElement("usuarioNome")]
    public string UsuarioNome { get; set; } = string.Empty;

    [BsonElement("dataVenda")]
    public DateTime DataVenda { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Preço negociado — pode ser diferente do preço de tabela do veículo.
    /// </summary>
    [BsonElement("precoFinal")]
    public decimal PrecoFinal { get; set; }

    [BsonElement("formaPagamento")]
    [BsonRepresentation(BsonType.String)]
    public FormaPagamento FormaPagamento { get; set; } = FormaPagamento.AVista;

    [BsonElement("status")]
    [BsonRepresentation(BsonType.String)]
    public StatusVenda Status { get; set; } = StatusVenda.Pendente;

    [BsonElement("observacoes")]
    public string? Observacoes { get; set; }

    [BsonElement("criadoEm")]
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    [BsonElement("atualizadoEm")]
    public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;
}
