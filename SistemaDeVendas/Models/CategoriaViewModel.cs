using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Models
{
    public class CategoriaViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage ="Informe a Descrição!")]
        public string Descricao { get; set; }
    }
}
