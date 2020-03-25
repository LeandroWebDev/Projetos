using Dominio.Entidades;
using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositorio
{
    public abstract class Repositorio<TEntidade> : DbContext, IRepositorio<TEntidade> where TEntidade : EntityBase, new()
    {

        DbContext context;
        DbSet<TEntidade> Entidade;
        public Repositorio(DbContext dbContext)
        {
            context = dbContext;
            Entidade = context.Set<TEntidade>();
        }
        public void Create(TEntidade Entity)
        {
           if(Entity.Id == null)
           {
                Entidade.Add(Entity);
           }
           else
           {
                context.Entry(Entity).State = EntityState.Modified;
           }
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ent = new TEntidade { Id = id };
            Entidade.Attach(ent);
            Entidade.Update(ent);
            context.SaveChanges();
        }

        public TEntidade Read(int id)
        {
            return Entidade.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<TEntidade> Read()
        {
            return Entidade.AsNoTracking().ToList();
        }
    }
}
