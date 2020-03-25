using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Venda : EntityBase
    {
        public DateTime Data { get; set; }

        public decimal Total { get; set; }

        public ICollection<VendaProdutos> Produtos { get; set; }

        public Cliente Cliente { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
    }
}
