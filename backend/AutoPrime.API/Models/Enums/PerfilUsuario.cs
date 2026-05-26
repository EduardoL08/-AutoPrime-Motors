namespace AutoPrime.API.Models.Enums;

/// <summary>
/// Perfis de acesso do sistema.
/// Admin: acesso total (incluindo delete).
/// Vendedor: pode registrar vendas e consultar dados.
/// Visualizador: somente leitura.
/// </summary>
public enum PerfilUsuario
{
    Admin = 0,
    Vendedor = 1,
    Visualizador = 2
}
