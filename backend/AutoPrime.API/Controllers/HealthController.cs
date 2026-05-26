using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using AutoPrime.API.Configurations;
using Microsoft.Extensions.Options;

namespace AutoPrime.API.Controllers;

/// <summary>
/// Controller de verificação de saúde da API.
/// Usado para confirmar que a API e o MongoDB estão operacionais.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class HealthController : ControllerBase
{
    private readonly IMongoDatabase _database;

    public HealthController(IMongoDatabase database)
    {
        _database = database;
    }

    /// <summary>
    /// Verifica se a API está rodando e se há conexão com o MongoDB.
    /// </summary>
    /// <returns>Status da API e do banco de dados.</returns>
    /// <response code="200">API e MongoDB operacionais.</response>
    /// <response code="503">Falha na conexão com o MongoDB.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public async Task<IActionResult> Get()
    {
        try
        {
            // Executa um ping no MongoDB para verificar conectividade
            await _database.RunCommandAsync((Command<MongoDB.Bson.BsonDocument>)"{ping:1}");

            return Ok(new
            {
                status = "healthy",
                api = "AutoPrime Motors API v1",
                database = "MongoDB conectado com sucesso",
                timestamp = DateTime.UtcNow
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status503ServiceUnavailable, new
            {
                status = "unhealthy",
                api = "AutoPrime Motors API v1",
                database = "Falha na conexão com MongoDB",
                error = ex.Message,
                timestamp = DateTime.UtcNow
            });
        }
    }
}
