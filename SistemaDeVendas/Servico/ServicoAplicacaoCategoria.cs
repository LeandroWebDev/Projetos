using Aplicacao.Servico.Interfaces;
using Dominio.Servicos;
using Aplicacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Entidades;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoCategoria : IServicoAplicacaoCategoria
    {
        private readonly IServicoCategoria Servico;
        public ServicoAplicacaoCategoria(IServicoCategoria servico)
        {
            Servico = servico;
        }

        public void Cadastrar(CategoriaViewModel view)
        {
            Categoria item = new Categoria()
            {
                Id = view.Id,
                Descricao = view.Descricao
            };
            Servico.Cadastrar(item);
        }

        public void Excluir(int id)
        {
            Servico.Excluir(id);
        }

        public IEnumerable<CategoriaViewModel> Listar()
        {
            var lista = Servico.Listar();
            List<CategoriaViewModel> listaCategoria = new List<CategoriaViewModel>();

            foreach (var item in lista)
            {
                CategoriaViewModel categoria = new CategoriaViewModel()
                {
                    Id = item.Id,
                    Descricao = item.Descricao
                };
                listaCategoria.Add(categoria);
            }
            return listaCategoria;
        }

        public CategoriaViewModel Carregar(int id)
        {
            var registro = Servico.Carregar(id);
            CategoriaViewModel item = new CategoriaViewModel()
            {
                Id = registro.Id,
                Descricao = registro.Descricao
            };

            return item;
        }
    }
}
