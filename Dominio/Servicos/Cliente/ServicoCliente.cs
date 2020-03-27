using Dominio.Interfaces;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Repositorio;

namespace Dominio.Servicos
{
    public class ServicoCliente : IServicoCliente
    {
        IRepositorioCliente Repositorio;

        public ServicoCliente(IRepositorioCliente repositorio)
        {
            Repositorio = repositorio;
        }
        public void Cadastrar(Cliente item)
        {
           Repositorio.Create(item);
        }

        public void Excluir(int id)
        {
            Repositorio.Delete(id);
        }

        public IEnumerable<Cliente> Listar()
        {

            return Repositorio.Read();
        }

        public Cliente Carregar(int id)
        {
            return Repositorio.Read(id);
        }

      
    }
}
