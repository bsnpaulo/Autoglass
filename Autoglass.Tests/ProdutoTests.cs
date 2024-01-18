using System;
using Autoglass.Domain.Models;
using Xunit;

namespace Autoglass.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void ValidarProduto_SituacaoInvalida()
        {
            // Arrange
            Produto produto = new()
            {
                Situacao = "X"
            };

            // Act
            string resultado = produto.ValidarProduto();

            // Assert
            Assert.Equal("Situação inválida. Deve ser 'A' ou 'I'.", resultado);
        }

        [Fact]
        public void ValidarProduto_DataFabricacaoMaiorIgualValidade_DeveRetornarMensagem()
        {
            // Arrange
            Produto produto = new()
            {
                Situacao = "A",
                FornecedorId = 1,
                DataFabricacao = DateTime.Parse("2024-01-18 15:30:45"),
                DataValidade = DateTime.Parse("2024-01-18 15:30:45")
            };

            // Act
            string resultado = produto.ValidarProduto();

            // Assert
            Assert.Equal("Data de fabricação não pode ser maior ou igual à data de validade.", resultado);
        }

        [Fact]
        public void ValidarProduto_FornecedorIdInvalido_DeveRetornarMensagem()
        {
            // Arrange
            Produto produto = new()
            {
                Situacao = "A",
                DataFabricacao = DateTime.Parse("2024-01-18 15:30:45"),
                DataValidade = DateTime.Parse("2025-01-18 15:30:45"),
                FornecedorId = 0
            };

            // Act
            string resultado = produto.ValidarProduto();

            // Assert
            Assert.Equal("Informe o codigo do fornecedor", resultado);
        }

        [Fact]
        public void ValidarProduto_ProdutoValido_DeveRetornarNull()
        {
            // Arrange
            Produto produto = new()
            {
                Descricao = "Produto válido",
                Situacao = "A",
                DataFabricacao = DateTime.Now,
                DataValidade = DateTime.Now.AddDays(30),
                FornecedorId = 1
            };

            // Act
            string resultado = produto.ValidarProduto();

            // Assert
            Assert.Null(resultado);
        }
    }
}