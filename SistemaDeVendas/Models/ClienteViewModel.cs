using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeVendas.Models
{
    public class ClienteViewModel
    {
        public int? Id { get; set; }


        [Required(ErrorMessage = "Informe o nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe CNJP/CPF!")]
        public string CNPJ_CPF { get; set; }

        [Required(ErrorMessage = "Informe o Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o Celular!")]
        public string Celular { get; set; }
    }
}
