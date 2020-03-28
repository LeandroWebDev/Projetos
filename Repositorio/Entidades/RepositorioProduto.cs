using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Repositorio.Contexto;
using System.Linq;

namespace Repositorio.Entidades
{
    public class RepositorioProduto : Repositorio<Produto>, IRepositorioProduto
    {
        public RepositorioProduto(ApplicationDbContext context) : base(context)
        {

        }
        public override IEnumerable<Produto> Read()
        {
            return Entidade.Include(x=>x.Categoria).AsNoTracking().ToList();
        }
    }
}
