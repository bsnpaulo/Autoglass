using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autoglass.Domain.Interfaces;
using Autoglass.Domain.Models;
using Autoglass.Service.Dtos;
using Autoglass.Service.Interfaces;
using AutoMapper;

namespace Autoglass.Service.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public ProdutoService(
            IProdutoRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task AddAsync(ProdutoDto produto)
        {
            var mapProduto = _mapper.Map<Produto>(produto);

            var validaProduto = Produto.ValidarProduto(mapProduto);

            if (!string.IsNullOrEmpty(validaProduto))
                throw new ApplicationException(validaProduto);
            mapProduto.Situacao = "A";
            await _repository.AddAsync(mapProduto);
        }

        public async Task DeleteAsync(ProdutoDto produto)
        {
            var produtoRecuperado = await _repository.GetByIdAsync(produto.CodigoProduto);

            if (produtoRecuperado == null)
                throw new ApplicationException("Produto ñ encontrado.");

            produtoRecuperado.Situacao = "I";

            await _repository.DeleteAsync(produtoRecuperado);
        }

        public async Task EditAsync(ProdutoDto produto)
        {
            var produtoRecuperado = await _repository.GetByIdAsync(produto.CodigoProduto);

            if (produtoRecuperado == null)
                throw new ApplicationException("Produto ñ encontrado.");

            var mapProduto = _mapper.Map<Produto>(produto);

            var validaProduto = Produto.ValidarProduto(mapProduto);

            if (!string.IsNullOrEmpty(validaProduto))
                throw new ApplicationException(validaProduto);

            await _repository.EditAsync(mapProduto);
        }

        public async Task<ProdutoDto> GetByIdAsync(int id)
        {
            var produtoRecuperado = await _repository.GetByIdAsync(id);

            return _mapper.Map<ProdutoDto>(produtoRecuperado);
        }

        public async Task<IEnumerable<ProdutoDto>> ListAsync(
            string descricao,
            DateTime? dataFabricacao,
            DateTime? dataValidade,
            string situacao,
            int pagina, int tamanhoDaPagina)
        {
            var produto = new Produto
            {
                Descricao = descricao,
                DataFabricacao = dataFabricacao ?? DateTime.MinValue,
                DataValidade = dataValidade ?? DateTime.MinValue,
                Situacao = situacao
            };

            var result = await _repository.ListAsync(produto, pagina, tamanhoDaPagina);

            return _mapper.Map<IEnumerable<ProdutoDto>>(result);
        }
    }
}