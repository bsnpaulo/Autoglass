using System.Collections.Generic;
using System.Threading.Tasks;
using Autoglass.Domain.Models;

namespace Autoglass.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> GetByIdAsync(int id);
        Task<IEnumerable<Produto>> ListAsync(Produto produto, int pagina, int tamanhoDaPagina);
        Task AddAsync(Produto produto);
        Task EditAsync(Produto produto);
        Task DeleteAsync(Produto produto);
    }
}