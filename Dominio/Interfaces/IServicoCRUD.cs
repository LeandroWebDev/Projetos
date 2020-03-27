using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IServicoCRUD <TEntidade> where TEntidade: class
    {
        IEnumerable<TEntidade> Listar();
        void Cadastrar(TEntidade entidade);
        TEntidade Carregar(int id);
        void Excluir(int id);
    }
}
