using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aplicacao.Models;
using Aplicacao.DAL;

namespace Aplicacao.Controllers
{
    public class CategoriaController : Controller
    {
         //protected readonly ApplicationDbContext dbContext;

        protected readonly IServicoAplicacaoCategoria _servicoAplicacaoCategoria;
        
        public CategoriaController(IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            _servicoAplicacaoCategoria = servicoAplicacaoCategoria;
        }
        public IActionResult Index()
        {
            
            return View(_servicoAplicacaoCategoria.GetCategoria());
        }

    //    [HttpGet]
    //    public IActionResult Cadastro(int? id)
    //    {
    //        CategoriaViewModel viewModel = new CategoriaViewModel();

    //        if ( id !=null)
    //        {
    //            var categoria = dbContext.Categoria.Where(x => x.Id == id).FirstOrDefault();
    //            viewModel.Id = categoria.Id;
    //            viewModel.Descricao = categoria.Descricao;
    //        }
    //        return View(viewModel);
    //    }

    //    [HttpPost]
    //    public IActionResult Cadastro( CategoriaViewModel categoria)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            Categoria ObjCategoria = new Categoria()
    //            {
    //                Id = categoria.Id,
    //                Descricao = categoria.Descricao

    //            };
    //            if(categoria.Id == null)
    //            {
    //                dbContext.Categoria.Add(ObjCategoria);
    //            }
    //            else
    //            {
    //                dbContext.Entry(ObjCategoria).State = EntityState.Modified;
    //            }

    //            dbContext.SaveChanges();
    //        }
    //        else
    //        {
    //            return View(categoria);
    //        }

    //        return RedirectToAction("Index");
    //    }

    //    public IActionResult Excluir(int id)
    //    {
    //        var categoria = new Categoria() { Id = id };
    //        dbContext.Attach(categoria);
    //        dbContext.Remove(categoria);
    //        dbContext.SaveChanges();
    //        return RedirectToAction("Index");
    //    }
    }
}