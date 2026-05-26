namespace AutoPrime.API.Models.Enums;

/// <summary>
/// Define se o veículo está disponível para venda ou já foi comercializado.
/// Gravado como string no MongoDB para legibilidade nos documentos.
/// </summary>
public enum StatusVeiculo
{
    Disponivel = 0,
    Vendido = 1,
    Reservado = 2
}
