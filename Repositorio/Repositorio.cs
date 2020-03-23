using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio
{
    public abstract class Repositorio<TEntidade> : DbContext, IRepositorio<TEntidade> where TEntidade : class, new()
    {

        DbContext context;
        DbSet<TEntidade> Entidades;
        public Repositorio(DbContext dbContext)
        {
            context = dbContext;
            Entidades = context.Set<TEntidade>();
        }
        public void Create(TEntidade Entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TEntidade Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntidade> Read()
        {
            return Entidades.AsNoTracking().ToList();
        }
    }
}
