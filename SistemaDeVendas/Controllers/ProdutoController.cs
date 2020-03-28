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
    public class ProdutoController : Controller
    {
         //protected readonly ApplicationDbContext dbContext;

        protected readonly IServicoAplicacaoProduto ServicoAplicacao;
        protected readonly IServicoAplicacaoCategoria ServicoAplicacaoCategoria;
        public ProdutoController(IServicoAplicacaoProduto servicoAplicacao, IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            ServicoAplicacao = servicoAplicacao;
            ServicoAplicacaoCategoria = servicoAplicacaoCategoria; 
        }
        public IActionResult Index()
        {
            
            return View(ServicoAplicacao.Listar());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ProdutoViewModel viewModel = new ProdutoViewModel();
            if (id != null)
            {
                viewModel = ServicoAplicacao.Carregar((int)id);
            }

            viewModel.ListaGategorias = ServicoAplicacaoCategoria.ListaDropDown();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel item)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacao.Cadastrar(item);
            }
            else
            {
                item.ListaGategorias = ServicoAplicacaoCategoria.ListaDropDown();
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