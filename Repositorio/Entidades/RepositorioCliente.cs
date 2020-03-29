using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Repositorio.Contexto;
using Dominio.Repositorio;

namespace Repositorio.Entidades
{
    public class RepositorioCliente : Repositorio<Cliente>, IRepositorioCliente
    {
        
        public RepositorioCliente(ApplicationDbContext context) : base(context)
        {

        }
        
    }
}
