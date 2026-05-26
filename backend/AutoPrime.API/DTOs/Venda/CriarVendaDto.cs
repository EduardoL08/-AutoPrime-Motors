using System.ComponentModel.DataAnnotations;
using AutoPrime.API.Models.Enums;

namespace AutoPrime.API.DTOs.Venda;

public class CriarVendaDto
{
    [Required(ErrorMessage = "Id do veículo é obrigatório")]
    public string VeiculoId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Id do cliente é obrigatório")]
    public string ClienteId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Preço final é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Preço final deve ser maior que zero")]
    public decimal PrecoFinal { get; set; }

    public FormaPagamento FormaPagamento { get; set; } = FormaPagamento.AVista;

    [StringLength(500, ErrorMessage = "Observações devem ter no máximo 500 caracteres")]
    public string? Observacoes { get; set; }
}

/// <summary>
/// DTO para atualizar apenas o status de uma venda existente.
/// Ex: mudar de Pendente → Concluída ou Cancelada.
/// </summary>
public class AtualizarStatusVendaDto
{
    [Required(ErrorMessage = "Status é obrigatório")]
    public StatusVenda Status { get; set; }

    [StringLength(500)]
    public string? Observacoes { get; set; }
}
