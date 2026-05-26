using System.ComponentModel.DataAnnotations;
using AutoPrime.API.Models.Enums;

namespace AutoPrime.API.DTOs.Veiculo;

/// <summary>
/// DTO de entrada para criação ou atualização de um veículo.
/// 
/// Por que usar DTOs em vez de passar o Model direto?
/// - Segurança: o cliente nunca controla campos como Id, CriadoEm, Status
/// - Flexibilidade: a API pode evoluir sem quebrar o contrato externo
/// - Validação: as regras ficam no DTO, não no Model
/// </summary>
public class CriarVeiculoDto
{
    [Required(ErrorMessage = "Marca é obrigatória")]
    [StringLength(50, ErrorMessage = "Marca deve ter no máximo 50 caracteres")]
    public string Marca { get; set; } = string.Empty;

    [Required(ErrorMessage = "Modelo é obrigatório")]
    [StringLength(100, ErrorMessage = "Modelo deve ter no máximo 100 caracteres")]
    public string Modelo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ano é obrigatório")]
    [Range(1900, 2030, ErrorMessage = "Ano deve estar entre 1900 e 2030")]
    public int Ano { get; set; }

    [Required(ErrorMessage = "Cor é obrigatória")]
    [StringLength(30, ErrorMessage = "Cor deve ter no máximo 30 caracteres")]
    public string Cor { get; set; } = string.Empty;

    [Required(ErrorMessage = "Preço é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Preço deve ser maior que zero")]
    public decimal Preco { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quilometragem não pode ser negativa")]
    public int Quilometragem { get; set; } = 0;

    [StringLength(1000, ErrorMessage = "Descrição deve ter no máximo 1000 caracteres")]
    public string? Descricao { get; set; }

    /// <summary>
    /// Lista de URLs das fotos do veículo (máx. 10).
    /// </summary>
    public List<string> Imagens { get; set; } = [];
}
