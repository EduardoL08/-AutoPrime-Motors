namespace AutoPrime.API.Models.Enums;

/// <summary>
/// Ciclo de vida de uma venda.
/// Pendente → Concluída (fecha negócio) ou Cancelada (desfaz a venda).
/// </summary>
public enum StatusVenda
{
    Pendente = 0,
    Concluida = 1,
    Cancelada = 2
}
