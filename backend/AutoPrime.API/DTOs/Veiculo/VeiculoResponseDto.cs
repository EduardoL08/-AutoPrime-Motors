using AutoPrime.API.Models.Enums;

namespace AutoPrime.API.DTOs.Veiculo;

/// <summary>
/// DTO de saída — o que o cliente recebe ao consultar um veículo.
/// Expõe apenas os campos necessários, nunca dados sensíveis.
/// </summary>
public class VeiculoResponseDto
{
    public string Id { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public int Ano { get; set; }
    public string Cor { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Quilometragem { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public List<string> Imagens { get; set; } = [];
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }
}
