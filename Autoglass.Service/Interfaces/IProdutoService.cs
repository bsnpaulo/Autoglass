using Autoglass.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoglass.Service.Interfaces
{
    public interface IProdutoService
    {
        Task<ProdutoDto> GetByIdAsync(int id);
        Task<IEnumerable<ProdutoDto>> ListAsync(
            string descricao,
            DateTime? dataFabricacao,
            DateTime? dataValidade, string situacao,
            int pagina, int tamanhoDaPagina);
        Task AddAsync(ProdutoDto produto);
        Task EditAsync(ProdutoDto produto);
        Task DeleteAsync(ProdutoDto produto);
    }
}