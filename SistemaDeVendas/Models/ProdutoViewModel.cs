using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Models
{
    public class ProdutoViewModel
    {
        public int? Id { get; set; }


        [Required(ErrorMessage = "Informe a Descrição!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a Quantidade")]
        public double Quantidade { get; set; }

        [Required(ErrorMessage = "Informe o Valor!")]
        [Range(0.1, Double.PositiveInfinity)]
        public decimal? Valor { get; set; }

        [Required(ErrorMessage = "Informe a Categoria do Produto!")]
        public int? IdCategoria { get; set; }

        public IEnumerable<SelectListItem>ListaGategorias { get; set; }
    }
}
