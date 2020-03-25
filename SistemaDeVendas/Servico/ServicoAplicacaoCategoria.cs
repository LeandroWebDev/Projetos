using Aplicacao.Servico.Interfaces;
using Dominio.Servicos;
using Aplicacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Aplicacao.Entidades;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoCategoria : IServicoAplicacaoCategoria
    {
        private readonly IServicoCategoria ServicoCategoria;
        public ServicoAplicacaoCategoria(IServicoCategoria servicoCategoria)
        {
            ServicoCategoria = servicoCategoria;
        }

        public void Cadastrar(CategoriaViewModel categoriaView)
        {
            Categoria categoria = new Categoria()
            {
                Id = categoriaView.Id,
                Descricao = categoriaView.Descricao
            };
            ServicoCategoria.Cadastrar(categoria);
        }

        public IEnumerable<CategoriaViewModel> GetCategoria()
        {
            var lista = ServicoCategoria.GetCategoria();
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

        public CategoriaViewModel GetRegistro(int id)
        {
            var registro = ServicoCategoria.GetCategoria(id);
            CategoriaViewModel categoria = new CategoriaViewModel()
            {
                Id = registro.Id,
                Descricao = registro.Descricao
            };

            return categoria;
        }
    }
}
