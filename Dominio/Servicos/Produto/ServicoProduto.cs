using Dominio.Interfaces;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Repositorio;

namespace Dominio.Servicos
{
    public class ServicoProduto : IServicoProduto
    {
        IRepositorioProduto Repositorio;

        public ServicoProduto(IRepositorioProduto repositorio)
        {
            Repositorio = repositorio;
        }
        public void Cadastrar(Produto item)
        {
           Repositorio.Create(item);
        }

        public void Excluir(int id)
        {
            Repositorio.Delete(id);
        }

        public IEnumerable<Produto> Listar()
        {

            return Repositorio.Read();
        }

        public Produto Carregar(int id)
        {
            return Repositorio.Read(id);
        }

      
    }
}
