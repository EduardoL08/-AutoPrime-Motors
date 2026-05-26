using System.Linq.Expressions;

namespace AutoPrime.API.Repositories;

/// <summary>
/// Interface genérica de repositório.
/// 
/// PRINCÍPIO DIP (Dependency Inversion — SOLID):
/// As camadas superiores (Services) dependem desta abstração,
/// não das implementações concretas do MongoDB.
/// Isso permite trocar o banco de dados sem alterar os Services.
/// 
/// PRINCÍPIO OCP (Open/Closed — SOLID):
/// Podemos criar novos repositórios especializados estendendo
/// esta interface, sem modificar o código existente.
/// 
/// O T where T : class garante que só tipos de referência
/// (classes) podem ser usados como entidade.
/// </summary>
public interface IRepository<T> where T : class
{
    /// <summary>Retorna todos os documentos da coleção.</summary>
    Task<IEnumerable<T>> ObterTodosAsync();

    /// <summary>Retorna um documento pelo seu Id (ObjectId string).</summary>
    Task<T?> ObterPorIdAsync(string id);

    /// <summary>Filtra documentos com base em uma expressão lambda.</summary>
    Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> filtro);

    /// <summary>Insere um novo documento na coleção.</summary>
    Task<T> CriarAsync(T entidade);

    /// <summary>Substitui um documento existente pelo Id.</summary>
    Task<bool> AtualizarAsync(string id, T entidade);

    /// <summary>Remove um documento pelo Id.</summary>
    Task<bool> DeletarAsync(string id);

    /// <summary>Verifica se existe algum documento que satisfaça o filtro.</summary>
    Task<bool> ExisteAsync(Expression<Func<T, bool>> filtro);
}
