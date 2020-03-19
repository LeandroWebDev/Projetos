using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.DAL;
using Aplicacao.Entidades;
using Aplicacao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao.Controllers
{
    public class ClienteController : Controller
    {
        protected readonly ApplicationDbContext dbContext;
        
        public ClienteController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Cliente> lista = dbContext.Cliente.ToList();
            dbContext.Dispose();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ClienteViewModel viewModel = new ClienteViewModel();

            if ( id !=null)
            {
                var cliente = dbContext.Cliente.Where(x => x.Id == id).FirstOrDefault();
                viewModel.Id = cliente.Id;
                viewModel.Nome = cliente.Nome;
                viewModel.CNPJ_CPF = cliente.CNPJ_CPF;
                viewModel.Email = cliente.Email;
                viewModel.Celular = cliente.Celular;
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                Cliente ObjCiente = new Cliente()
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    CNPJ_CPF = cliente.CNPJ_CPF,
                    Email = cliente.Email,
                    Celular = cliente.Celular

                };
                if(cliente.Id == null)
                {
                    dbContext.Cliente.Add(ObjCiente);
                }
                else
                {
                    dbContext.Entry(ObjCiente).State = EntityState.Modified;
                }

                dbContext.SaveChanges();
            }
            else
            {
                return View(cliente);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            var cliente = new Cliente() { Id = id };
            dbContext.Attach(cliente);
            dbContext.Remove(cliente);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}