using Aplicacao.Entidades;
using Aplicacao.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoProduto
    {
        IEnumerable<SelectListItem> ListaDropDown();
        IEnumerable<ProdutoViewModel> Listar();
        ProdutoViewModel Carregar(int id);
        void Cadastrar(ProdutoViewModel item);
        void Excluir(int id);
    }
}
