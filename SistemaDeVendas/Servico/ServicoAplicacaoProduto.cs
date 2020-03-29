using Aplicacao.Servico.Interfaces;
using Dominio.Servicos;
using Aplicacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoProduto : IServicoAplicacaoProduto
    {
        private readonly IServicoProduto Servico;
        public ServicoAplicacaoProduto(IServicoProduto servico)
        {
            Servico = servico;
        }

        public void Cadastrar(ProdutoViewModel registro)
        {
            Produto item = new Produto()
            {
                Id = registro.Id,
                Descricao = registro.Descricao,
                Quantidade = registro.Quantidade,
                Valor = (decimal)registro.Valor,
                IdCategoria = (int)registro.IdCategoria
            };
            Servico.Cadastrar(item);
        }

        public void Excluir(int id)
        {
            Servico.Excluir(id);
        }

        public IEnumerable<ProdutoViewModel> Listar()
        {
            var listar = Servico.Listar();
            List<ProdutoViewModel> lista = new List<ProdutoViewModel>();

            foreach (var registro in listar)
            {
            ProdutoViewModel item = new ProdutoViewModel()
                {
                Id = registro.Id,
                Descricao = registro.Descricao,
                Quantidade = registro.Quantidade,
                Valor = (decimal)registro.Valor,
                IdCategoria = (int)registro.IdCategoria,
                DescricaoCategoria = registro.Categoria.Descricao
            };
                lista.Add(item);
            }
            return lista;
        }

        public ProdutoViewModel Carregar(int id)
        {
            var registro = Servico.Carregar(id);
        ProdutoViewModel item = new ProdutoViewModel()
            {
                Id = registro.Id,
                Descricao = registro.Descricao,
                Quantidade = registro.Quantidade,
                Valor = registro.Valor,
                IdCategoria = registro.IdCategoria
            };

            return item;
        }
        public IEnumerable<SelectListItem> ListaDropDown()
        {
            List<SelectListItem> retorno = new List<SelectListItem>();

            var lista = this.Listar();

            foreach (var item in lista)
            {
                SelectListItem produto = new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = item.Descricao
                };
                retorno.Add(produto);
            }
            return retorno;
        }
    }
}
