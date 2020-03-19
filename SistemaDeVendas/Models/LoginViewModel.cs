using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Informe seu E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua Senha")]
        public string Senha { get; set; }
    }
}
