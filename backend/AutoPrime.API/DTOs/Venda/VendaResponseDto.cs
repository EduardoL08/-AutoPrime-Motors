using AutoPrime.API.Models.Enums;

namespace AutoPrime.API.DTOs.Venda;

/// <summary>
/// DTO de saída de uma venda com dados populados das entidades relacionadas.
/// Ao invés de retornar apenas os Ids, retornamos os dados relevantes
/// de Veículo e Cliente para facilitar exibição no frontend.
/// </summary>
public class VendaResponseDto
{
    public string Id { get; set; } = string.Empty;

    // Dados do veículo
    public string VeiculoId { get; set; } = string.Empty;
    public string VeiculoDescricao { get; set; } = string.Empty;

    // Dados do cliente
    public string ClienteId { get; set; } = string.Empty;
    public string ClienteNome { get; set; } = string.Empty;

    // Dados do vendedor
    public string UsuarioId { get; set; } = string.Empty;
    public string UsuarioNome { get; set; } = string.Empty;

    public DateTime DataVenda { get; set; }
    public decimal PrecoFinal { get; set; }
    public string FormaPagamento { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? Observacoes { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }
}
