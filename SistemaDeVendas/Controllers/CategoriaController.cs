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

        protected readonly IServicoAplicacaoCategoria ServicoAplicacaoCategoria;
        
        public CategoriaController(IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            ServicoAplicacaoCategoria = servicoAplicacaoCategoria;
        }
        public IActionResult Index()
        {
            
            return View(ServicoAplicacaoCategoria.GetCategoria());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            CategoriaViewModel viewModel = new CategoriaViewModel();
            if (id != null)
            {
                viewModel = ServicoAplicacaoCategoria.GetRegistro((int)id);
            }   
               
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(CategoriaViewModel categoria)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoCategoria.Cadastrar(categoria);
            }
            else
            {
                return View(categoria);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            ServicoAplicacaoCategoria.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}