using AutoPrime.API.Models.Enums;

namespace AutoPrime.API.DTOs.Usuario;

/// <summary>
/// DTO de saída do usuário — NUNCA inclui a senha ou hash.
/// </summary>
public class UsuarioResponseDto
{
    public string Id { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Perfil { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public DateTime CriadoEm { get; set; }
}

/// <summary>
/// Retornado após login bem-sucedido.
/// Contém o token JWT e os dados básicos do usuário logado.
/// </summary>
public class TokenResponseDto
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expiracao { get; set; }
    public UsuarioResponseDto Usuario { get; set; } = null!;
}
