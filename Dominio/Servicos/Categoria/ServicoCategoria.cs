using Dominio.Interfaces;
using SistemaDeVenda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Servicos
{
    public class ServicoCategoria : IServicoCategoria
    {
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
            List<Categoria> lista = new List<Categoria>();
            Categoria categoria = new Categoria() 
            {
                Id = 1,
                Descricao = "Teste"

            };
            lista.Add(categoria);

            return lista;
        }

        public Categoria GetCategoria(int id)
        {
            throw new NotImplementedException();
        }
    }
}
