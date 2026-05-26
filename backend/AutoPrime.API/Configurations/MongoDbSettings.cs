namespace AutoPrime.API.Configurations;

/// <summary>
/// Configurações de conexão com o MongoDB.
/// Os valores são lidos do appsettings.json ou variáveis de ambiente.
/// </summary>
public class MongoDbSettings
{
    /// <summary>
    /// String de conexão completa com o MongoDB.
    /// Exemplo: mongodb://localhost:27017
    /// </summary>
    public string ConnectionString { get; set; } = string.Empty;

    /// <summary>
    /// Nome do banco de dados a ser utilizado.
    /// </summary>
    public string DatabaseName { get; set; } = string.Empty;
}
