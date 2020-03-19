using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVenda.Dominio.Entidades
{
    public class VendaProdutos
    {
        public int IdVenda { get; set; }

        public int IdProduto { get; set; }

        public double Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal ValorTotal { get; set; }

        public Produto Produto { get; set; }

        public Venda Venda { get; set; }
    }
}
