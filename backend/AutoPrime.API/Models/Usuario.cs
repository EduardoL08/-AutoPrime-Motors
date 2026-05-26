using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using AutoPrime.API.Models.Enums;

namespace AutoPrime.API.Models;

/// <summary>
/// Representa um usuário do sistema (funcionário da concessionária).
/// A senha NUNCA é armazenada em texto plano — apenas o hash BCrypt.
/// </summary>
public class Usuario
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("nome")]
    public string Nome { get; set; } = string.Empty;

    [BsonElement("email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Hash BCrypt da senha. Nunca expor este campo em DTOs de resposta.
    /// </summary>
    [BsonElement("senhaHash")]
    public string SenhaHash { get; set; } = string.Empty;

    [BsonElement("perfil")]
    [BsonRepresentation(BsonType.String)]
    public PerfilUsuario Perfil { get; set; } = PerfilUsuario.Vendedor;

    [BsonElement("ativo")]
    public bool Ativo { get; set; } = true;

    [BsonElement("criadoEm")]
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

    [BsonElement("atualizadoEm")]
    public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;
}
