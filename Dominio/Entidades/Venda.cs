using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVenda.Dominio.Entidades
{
    public class Venda
    {
        [Key]
        public int? Id { get; set; }

        public DateTime Data { get; set; }

        public decimal Total { get; set; }

        public ICollection<VendaProdutos> Produtos { get; set; }

        public Cliente Cliente { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
    }
}
