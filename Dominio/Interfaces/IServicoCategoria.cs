using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IServicoCategoria
    {
        IEnumerable<Categoria> GetCategoria();
        void Cadastrar(Categoria categoria);
        Categoria GetCategoria(int id);
        void Excluir(int id);

    }
}
