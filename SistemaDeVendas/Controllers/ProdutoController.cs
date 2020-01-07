using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDeVendas.DAL;
using SistemaDeVendas.Entidades;
using SistemaDeVendas.Models;

namespace SistemaDeVendas.Controllers
{
    public class ProdutoController : Controller
    {
        protected readonly ApplicationDbContext dbContext;
        
        public ProdutoController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Produto> lista = dbContext.Produto.Include(x => x.Categoria).ToList();
            dbContext.Dispose();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ProdutoViewModel viewModel = new ProdutoViewModel();
            viewModel.ListaGategorias = ListaCategorias();
            if ( id !=null)
            {
                var produto = dbContext.Produto.Where(x => x.Id == id).FirstOrDefault();
                viewModel.Id = produto.Id;
                viewModel.Descricao = produto.Descricao;
                viewModel.Quantidade = produto.Quantidade;
                viewModel.Valor = produto.Valor;
                viewModel.IdCategoria = produto.IdCategoria;

            }
            return View(viewModel);
        }

        private IEnumerable<SelectListItem> ListaCategorias()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            lista.Add(new SelectListItem()
            {

                Value = string.Empty,
                Text = string.Empty
            });

            foreach (var item in dbContext.Categoria.ToList())
            {
                lista.Add(new SelectListItem()
                {

                    Value = item.Id.ToString(),
                    Text = item.Descricao.ToString()
                });

            }
            return lista;
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoViewModel produto)
        {
            
            if (ModelState.IsValid)
            {
                Produto ObjProduto = new Produto()
                {
                    Id = produto.Id,
                    Descricao = produto.Descricao,
                    Quantidade = produto.Quantidade,
                    Valor = (decimal)produto.Valor,
                    IdCategoria = (int)produto.IdCategoria

                };
                if(produto.Id == null)
                {
                    dbContext.Produto.Add(ObjProduto);
                }
                else
                {
                    dbContext.Entry(ObjProduto).State = EntityState.Modified;
                }

                dbContext.SaveChanges();
            }
            else
            {
                produto.ListaGategorias = ListaCategorias();
                return View(produto);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            var produto = new Produto() { Id = id };
            dbContext.Attach(produto);
            dbContext.Remove(produto);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}