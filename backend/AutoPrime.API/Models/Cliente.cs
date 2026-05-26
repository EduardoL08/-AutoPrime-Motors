using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AutoPrime.API.Models;

/// <summary>
/// Representa um cliente cadastrado na concessionária.
/// Um cliente pode estar associado a múltiplas vendas ao longo do tempo.
/// </summary>
public class Cliente
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("nome")]
    public string Nome { get; set; } = string.Empty;

    [BsonElement("email")]
    public string Email { get; set; } = string.Empty;

    [BsonElement("telefone")]
    public string Telefone { get; set; } = string.Empty;

    /// <summary>
    /// CPF armazenado apenas com dígitos (sem formatação).
    /// A formatação é responsabilidade do frontend.
    /// </summary>
    [BsonElement("cpf")]
    public string Cpf { get; set; } = string.Empty;

    /// <summary>
    /// Endereço como objeto embutido (embedded document) no MongoDB.
    /// Evita a necessidade de join — os dados ficam no mesmo documento.
    /// </summary>
    [BsonElement("endereco")]
    public Endereco? Endereco { get; set; }

    [BsonElement("criadoEm")]
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    [BsonElement("atualizadoEm")]
    public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;
}

/// <summary>
/// Objeto de valor (Value Object) embutido no documento Cliente.
/// No MongoDB, isso é gravado como subdocumento, não como coleção separada.
/// </summary>
public class Endereco
{
    [BsonElement("logradouro")]
    public string Logradouro { get; set; } = string.Empty;

    [BsonElement("numero")]
    public string Numero { get; set; } = string.Empty;

    [BsonElement("complemento")]
    public string? Complemento { get; set; }

    [BsonElement("bairro")]
    public string Bairro { get; set; } = string.Empty;

    [BsonElement("cidade")]
    public string Cidade { get; set; } = string.Empty;

    [BsonElement("estado")]
    public string Estado { get; set; } = string.Empty;

    [BsonElement("cep")]
    public string Cep { get; set; } = string.Empty;
}
