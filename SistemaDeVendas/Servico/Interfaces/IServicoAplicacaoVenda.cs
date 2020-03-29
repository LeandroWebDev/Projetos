using Aplicacao.Entidades;
using Aplicacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoVenda
    {
        IEnumerable<VendaViewModel> Listar();
        VendaViewModel Carregar(int id);
        void Cadastrar(VendaViewModel item);
        void Excluir(int id);
    }
}
