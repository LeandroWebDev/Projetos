using Dominio.Interfaces;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Repositorio;

namespace Dominio.Servicos
{
    public class ServicoVenda : IServicoVenda
    {
        IRepositorioVenda Repositorio;
        public ServicoVenda(IRepositorioVenda repositorio)
        {
            Repositorio = repositorio;
        }
        public void Cadastrar(Venda item)
        {
           Repositorio.Create(item);
        }

        public void Excluir(int id)
        {
            Repositorio.Delete(id);
        }

        public IEnumerable<Venda> Listar()
        {

            return Repositorio.Read();
        }

        public Venda Carregar(int id)
        {
            return Repositorio.Read(id);
        }

      
    }
}
