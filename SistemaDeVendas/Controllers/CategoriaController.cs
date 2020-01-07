using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeVendas.DAL;
using SistemaDeVendas.Entidades;
using SistemaDeVendas.Models;

namespace SistemaDeVendas.Controllers
{
    public class CategoriaController : Controller
    {
        protected readonly ApplicationDbContext dbContext;
        
        public CategoriaController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Categoria> lista = dbContext.Categoria.ToList();
            dbContext.Dispose();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            CategoriaViewModel viewModel = new CategoriaViewModel();

            if ( id !=null)
            {
                var categoria = dbContext.Categoria.Where(x => x.Id == id).FirstOrDefault();
                viewModel.Id = categoria.Id;
                viewModel.Descricao = categoria.Descricao;
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro( CategoriaViewModel categoria)
        {
            if (ModelState.IsValid)
            {
                Categoria ObjCategoria = new Categoria()
                {
                    Id = categoria.Id,
                    Descricao = categoria.Descricao

                };
                if(categoria.Id == null)
                {
                    dbContext.Categoria.Add(ObjCategoria);
                }
                else
                {
                    dbContext.Entry(ObjCategoria).State = EntityState.Modified;
                }

                dbContext.SaveChanges();
            }
            else
            {
                return View(categoria);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            var categoria = new Categoria() { Id = id };
            dbContext.Attach(categoria);
            dbContext.Remove(categoria);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}