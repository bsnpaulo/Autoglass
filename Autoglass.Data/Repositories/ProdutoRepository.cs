using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoglass.Data.Context;
using Autoglass.Domain.Interfaces;
using Autoglass.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Autoglass.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private AppDbContext _appDbContext;

        public ProdutoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Produto produto)
        {
            await _appDbContext.AddAsync(produto);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Produto produto)
        {
            _appDbContext.Update(produto);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Produto produto)
        {
            _appDbContext.Update(produto);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            return await _appDbContext.Produto
                .AsNoTracking()
                .Include(x => x.Fornecedor)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Produto>> ListAsync(Produto produto, int pagina, int tamanhoDaPagina)
        {
            int indiceInicial = (pagina - 1) * tamanhoDaPagina;

            var query = _appDbContext.Produto.AsQueryable();

            if (!string.IsNullOrEmpty(produto.Situacao))
                query = query.Where(p => p.Situacao == produto.Situacao);

            if (produto.DataFabricacao != DateTime.MinValue)
                query = query.Where(p => p.DataFabricacao == produto.DataFabricacao);

            if (produto.DataValidade != DateTime.MinValue)
                query = query.Where(p => p.DataFabricacao == produto.DataValidade);

            if (!string.IsNullOrEmpty(produto.Descricao))
            {
                query = query.Where(p => p.Descricao.Contains(produto.Descricao));
            }

            var produtosPaginados = await query
                .Include(x => x.Fornecedor)
                .OrderBy(p => p.Id)
                .Skip(indiceInicial)
                .Take(tamanhoDaPagina)
                .AsNoTracking()
                .ToListAsync();

            return produtosPaginados;
        }
    }
}