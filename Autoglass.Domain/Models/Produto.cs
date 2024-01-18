using System;

namespace Autoglass.Domain.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public string Situacao { get; set; }

        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; } = null!;

        public static string ValidarProduto(Produto produto)
        {
            if (produto == null)
                return "Produto é nulo.";

            if (produto.Situacao?.ToLower() != "a" && produto.Situacao?.ToLower() != "i")
                return "Situação inválida. Deve ser 'A' ou 'I'.";

            if (produto.DataFabricacao >= produto.DataValidade)
                return "Data de fabricação não pode ser maior ou igual à data de validade.";

            if (produto.FornecedorId <= 0)
                return "Informe o codigo do fornecedor";

            return null;
        }
    }
}