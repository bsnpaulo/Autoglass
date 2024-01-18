using System.Collections.Generic;

namespace Autoglass.Domain.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string Cnpj { get; set; }

        public ICollection<Produto> Produtos { get; } = new List<Produto>();
    }
}