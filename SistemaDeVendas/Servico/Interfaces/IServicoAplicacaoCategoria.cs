using Aplicacao.Entidades;
using Aplicacao.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoCategoria
    {
        IEnumerable<SelectListItem> ListaDropDown();
        IEnumerable<CategoriaViewModel> Listar();
        CategoriaViewModel Carregar(int id);
        void Cadastrar(CategoriaViewModel categoria);
        void Excluir(int id);
    }
}
