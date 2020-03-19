using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.DAL;
using Aplicacao.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Controllers
{
    public class RelatorioController : Controller
    {
        protected readonly ApplicationDbContext dbContext;

        public RelatorioController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Grafico()
        {
            var lista = dbContext.VendaProdutos
                .GroupBy(x => x.IdProduto)
                .Select(y => new GraficoViewModel
                {
                    IdProduto = y.Last().IdProduto,
                    //Descricacao = y.Produto.Descricao,
                    TotalVendido = y.Sum(z => z.Quantidade)
                }).ToList();


            return View();
        }
    }
}