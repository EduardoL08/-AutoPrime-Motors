namespace AutoPrime.API.DTOs.Cliente;

public class ClienteResponseDto
{
    public string Id { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;

    /// <summary>
    /// CPF formatado para exibição: 000.000.000-00
    /// A formatação acontece no mapeamento Model → DTO.
    /// </summary>
    public string Cpf { get; set; } = string.Empty;

    public EnderecoDto? Endereco { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }
}
