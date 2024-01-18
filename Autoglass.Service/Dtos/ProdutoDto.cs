using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Autoglass.Service.Dtos
{
    public class ProdutoDto
    {
        [DisplayName("Código do produto")]
        public int CodigoProduto { get; set; }

        [Required(ErrorMessage = "Descricao eh requerido")]
        [DisplayName("Descrição do produto")]
        public string Descricao { get; set; }

        [DisplayName("Situação do produto(Ativo ou Inativo)")]
        public string Situacao { get; set; }

        [DisplayName("Data de fabricação")]
        public DateTime DataFabricacao { get; set; }

        [DisplayName("Data de validade")]
        public DateTime DataValidade { get; set; }

        public int CodigoFornecedor { get; set; }
        public FornecedorDto Fornecedor { get; set; }
    }
}