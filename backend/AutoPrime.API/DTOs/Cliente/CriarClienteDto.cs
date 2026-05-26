using System.ComponentModel.DataAnnotations;

namespace AutoPrime.API.DTOs.Cliente;

public class CriarClienteDto
{
    [Required(ErrorMessage = "Nome é obrigatório")]
    [StringLength(150, ErrorMessage = "Nome deve ter no máximo 150 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Telefone é obrigatório")]
    [Phone(ErrorMessage = "Telefone inválido")]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "CPF é obrigatório")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve conter exatamente 11 dígitos")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter apenas dígitos")]
    public string Cpf { get; set; } = string.Empty;

    public EnderecoDto? Endereco { get; set; }
}

public class EnderecoDto
{
    [Required(ErrorMessage = "Logradouro é obrigatório")]
    public string Logradouro { get; set; } = string.Empty;

    [Required(ErrorMessage = "Número é obrigatório")]
    public string Numero { get; set; } = string.Empty;

    public string? Complemento { get; set; }

    [Required(ErrorMessage = "Bairro é obrigatório")]
    public string Bairro { get; set; } = string.Empty;

    [Required(ErrorMessage = "Cidade é obrigatória")]
    public string Cidade { get; set; } = string.Empty;

    [Required(ErrorMessage = "Estado é obrigatório")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "Estado deve ser a sigla com 2 letras (ex: MG)")]
    public string Estado { get; set; } = string.Empty;

    [Required(ErrorMessage = "CEP é obrigatório")]
    [RegularExpression(@"^\d{8}$", ErrorMessage = "CEP deve conter 8 dígitos")]
    public string Cep { get; set; } = string.Empty;
}
