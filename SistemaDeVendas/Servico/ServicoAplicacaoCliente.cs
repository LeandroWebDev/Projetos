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
    public class ServicoAplicacaoCliente : IServicoAplicacaoCliente
    {
        private readonly IServicoCliente ServicoCliente;
        public ServicoAplicacaoCliente(IServicoCliente servicoCliente)
        {
            ServicoCliente = servicoCliente;
        }

        public void Cadastrar(ClienteViewModel clienteView)
        {
            Cliente cliente = new Cliente()
            {
                Id = clienteView.Id,
                Celular = clienteView.Celular,
                Nome = clienteView.Nome,
                CNPJ_CPF = clienteView.CNPJ_CPF,
                Email = clienteView.Email,

            };
            ServicoCliente.Cadastrar(cliente);
        }

        public void Excluir(int id)
        {
            ServicoCliente.Excluir(id);
        }

        public IEnumerable<ClienteViewModel> Listar()
        {
            var lista = ServicoCliente.Listar();
            List<ClienteViewModel> listaCliente = new List<ClienteViewModel>();

            foreach (var item in lista)
            {
                ClienteViewModel cliente = new ClienteViewModel()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    CNPJ_CPF = item.CNPJ_CPF,
                    Email = item.Email,
                    Celular = item.Celular
                };
                listaCliente.Add(cliente);
            }
            return listaCliente;
        }

        public ClienteViewModel Carregar(int id)
        {
            var registro = ServicoCliente.Carregar(id);
            ClienteViewModel cliente = new ClienteViewModel()
            {
                Id = registro.Id,
                Nome = registro.Nome,
                CNPJ_CPF = registro.CNPJ_CPF,
                Email = registro.Email,
                Celular = registro.Celular
            };

            return cliente;
        }
    }
}
