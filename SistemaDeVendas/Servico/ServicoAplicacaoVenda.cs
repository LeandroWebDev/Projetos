using Aplicacao.Servico.Interfaces;
using Dominio.Servicos;
using Aplicacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Entidades;
using Newtonsoft.Json;

namespace Aplicacao.Servico
{
    public class ServicoAplicacaoVenda : IServicoAplicacaoVenda
    {
        private readonly IServicoVenda ServicoVenda;
        public ServicoAplicacaoVenda(IServicoVenda servico)
        {
            ServicoVenda = servico;
        }

        public void Cadastrar(VendaViewModel view)
        {
            Venda item = new Venda()
            {
                Id = view.Id,
                IdCliente = (int)view.IdCliente,
                Data = (DateTime)view.Data,
                Total = view.Total,
                Produtos = JsonConvert.DeserializeObject<ICollection<VendaProdutos>>(view.JsonProdutos)

            };
            ServicoVenda.Cadastrar(item);
        }

        public void Excluir(int id)
        {
            ServicoVenda.Excluir(id);
        }

        public IEnumerable<VendaViewModel> Listar()
        {
            var lista = ServicoVenda.Listar();
            List<VendaViewModel> listaVenda = new List<VendaViewModel>();

            foreach (var item in lista)
            {
                VendaViewModel venda = new VendaViewModel()
                {
                    Id = item.Id,
                    IdCliente = item.IdCliente,
                    Data = item.Data,
                    Total = item.Total
                };
                listaVenda.Add(venda);
            }
            return listaVenda;
        }

        public VendaViewModel Carregar(int id)
        {
            var registro = ServicoVenda.Carregar(id);

            VendaViewModel view = new VendaViewModel()
            {
                Id = registro.Id,
                IdCliente = registro.IdCliente,
                Data = registro.Data,
                Total = registro.Total
            };

            return view;
        }
    }
}
