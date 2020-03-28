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
           RepositorioCategoria.Create(categoria);
        }

        public void Excluir(int id)
        {
            RepositorioCategoria.Delete(id);
        }

        public IEnumerable<Categoria> Listar()
        {

            return RepositorioCategoria.Read();
        }

        public Categoria Carregar(int id)
        {
            return RepositorioCategoria.Read(id);
        }
    }
}
