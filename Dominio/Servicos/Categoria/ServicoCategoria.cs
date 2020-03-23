using Dominio.Interfaces;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Repositorio;

namespace Dominio.Servicos
{
    public class ServicoCategoria : IServicoCategoria
    {
        IRepositorioCategoria RepositorioCategoria;

        public ServicoCategoria(IRepositorioCategoria repositorioCategoria)
        {
            RepositorioCategoria = repositorioCategoria;
        }
        public void Cadastrar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> GetCategoria()
        {

            return RepositorioCategoria.Read();
        }

        public Categoria GetCategoria(int id)
        {
            throw new NotImplementedException();
        }
    }
}
