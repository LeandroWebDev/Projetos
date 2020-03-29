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
    public class VendaController : Controller
    {
         //protected readonly ApplicationDbContext dbContext;

        protected readonly IServicoAplicacaoProduto ServicoAplicacaoProduto;
        protected readonly IServicoAplicacaoCliente ServicoAplicacaoCliente;
        protected readonly IServicoAplicacaoVenda ServicoAplicacao;

        public VendaController(IServicoAplicacaoProduto servicoAplicacaoProduto, 
                               IServicoAplicacaoVenda servicoAplicacao, 
                               IServicoAplicacaoCliente servicoAplicacaoCliente
                               )
        {
            ServicoAplicacao = servicoAplicacao;
            ServicoAplicacaoCliente = servicoAplicacaoCliente;
            ServicoAplicacaoProduto = servicoAplicacaoProduto;
        }
        public IActionResult Index()
        {
            
            return View(ServicoAplicacao.Listar());
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {

            VendaViewModel viewModel = new VendaViewModel();
            viewModel.ListaClientes = ServicoAplicacaoCliente.ListaDropDown();
            viewModel.ListaProdutos = ServicoAplicacaoProduto.ListaDropDown();
            if (id != null)
            {
                viewModel = ServicoAplicacao.Carregar((int)id);
            }
            
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(VendaViewModel item)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacao.Cadastrar(item);
            }
            else
            {
                item.ListaClientes = ServicoAplicacaoCliente.ListaDropDown();
                item.ListaProdutos = ServicoAplicacaoProduto.ListaDropDown();
                return View(item);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            ServicoAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }

        //[HttpGet("GetValorProduto/{CodigoProduto}")]
        //public decimal GetValorProduto(int CodigoProduto)
        //{
        //    //var valor = dbContext.Produto.Where(x => x.Id == CodigoProduto).Select(x => x.Valor).FirstOrDefault();
        //    return (decimal)ServicoAplicacaoProduto.Carregar(CodigoProduto).Valor;// dbContext.Produto.Where(x => x.Id == CodigoProduto).Select(x => x.Valor).FirstOrDefault();


        //}
    }
}