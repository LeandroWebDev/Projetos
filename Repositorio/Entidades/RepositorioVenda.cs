using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Repositorio.Contexto;
using Dominio.Repositorio;
using System.Linq;

namespace Repositorio.Entidades
{
    
    public class RepositorioVenda : Repositorio<Venda>, IRepositorioVenda
    {
        public RepositorioVenda(ApplicationDbContext context) : base(context)
        {

        }

        public override void Delete(int id)
        {
            var listaProduto =
            Entidade.Include(x => x.Produtos)
            .Where(y => y.Id == id).AsNoTracking().ToList();

            foreach (var item in listaProduto[0].Produtos)
            {
               var venda = new VendaProdutos();
                venda.IdProduto = item.IdProduto;
                venda.IdVenda = id;
            
            
                //Produto
                DbSet<VendaProdutos> dbSet;
                dbSet = context.Set<VendaProdutos>();
                dbSet.Attach(venda);
                dbSet.Remove(venda);
                context.SaveChanges();

            }

            base.Delete(id);    
        }
    }
}
