using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Repositorio.Contexto;

namespace Repositorio.Entidades
{
    public class RepositorioCategoria : Repositorio<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoria(ApplicationDbContext context) : base(context)
        {

        }
        
    }
}
