using Aplicacao.Entidades;
using Aplicacao.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoCliente
    {
        IEnumerable<SelectListItem> ListaDropDown();
        IEnumerable<ClienteViewModel> Listar();
        ClienteViewModel Carregar(int id);
        void Cadastrar(ClienteViewModel cliente);
        void Excluir(int id);
    }
}
