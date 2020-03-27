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
    public class ClienteController : Controller
    {
         //protected readonly ApplicationDbContext dbContext;

        protected readonly IServicoAplicacaoCliente ServicoAplicacao;
        
        public ClienteController(IServicoAplicacaoCliente servicoAplicacao)
        {
            ServicoAplicacao = servicoAplicacao;
        }
        public IActionResult Index()
        {
            
            return View(ServicoAplicacao.Listar());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ClienteViewModel viewModel = new ClienteViewModel();
            if (id != null)
            {
                viewModel = ServicoAplicacao.Carregar((int)id);
            }   
               
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ClienteViewModel item)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacao.Cadastrar(item);
            }
            else
            {
                return View(item);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            ServicoAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}