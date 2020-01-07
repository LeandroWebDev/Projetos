using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SistemaDeVendas.DAL;
using SistemaDeVendas.Entidades;
using SistemaDeVendas.Models;

namespace SistemaDeVendas.Controllers
{
    public class VendaController : Controller
    {
        protected readonly ApplicationDbContext dbContext;

        public VendaController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Venda> lista = dbContext.Venda.ToList();
            dbContext.Dispose();
            return View(lista);
        }



        private IEnumerable<SelectListItem> ListaProdutos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            lista.Add(new SelectListItem()
            {

                Value = string.Empty,
                Text = string.Empty
            });

            foreach (var item in dbContext.Produto.ToList())
            {
                lista.Add(new SelectListItem()
                {

                    Value = item.Id.ToString(),
                    Text = item.Descricao.ToString()
                });

            }
            return lista;
        }
        private IEnumerable<SelectListItem> ListaClientes()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            lista.Add(new SelectListItem()
            {

                Value = string.Empty,
                Text = string.Empty
            });

            foreach (var item in dbContext.Cliente.ToList())
            {
                lista.Add(new SelectListItem()
                {

                    Value = item.Id.ToString(),
                    Text = item.Nome.ToString()
                });

            }
            return lista;
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            VendaViewModel viewModel = new VendaViewModel();
            viewModel.ListaClientes = ListaClientes();
            viewModel.ListaProdutos = ListaProdutos();
            if (id != null)
            {
                var entidade = dbContext.Venda.Where(x => x.Id == id).FirstOrDefault();
                viewModel.Id = entidade.Id;
                viewModel.Data = entidade.Data;
                viewModel.IdCliente = entidade.IdCliente;
                viewModel.Total = entidade.Total;

            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(VendaViewModel venda)
        {

            if (ModelState.IsValid)
            {
                Venda ObjVenda = new Venda()
                {
                    Id = venda.Id,
                    Data = (DateTime)venda.Data,
                    IdCliente = (int)venda.IdCliente,
                    Total = venda.Total,
                    Produtos = JsonConvert.DeserializeObject<ICollection<VendaProdutos>>(venda.JsonProdutos)

                };
                if (venda.Id == null)
                {
                    dbContext.Venda.Add(ObjVenda);
                }
                else
                {
                    dbContext.Entry(ObjVenda).State = EntityState.Modified;
                }

                dbContext.SaveChanges();
            }
            else
            {
                venda.ListaClientes = ListaClientes();
                venda.ListaProdutos = ListaProdutos();
                return View(venda);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            var venda = new Venda() { Id = id };
            dbContext.Attach(venda);
            dbContext.Remove(venda);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("GetValorProduto/{CodigoProduto}")]
        public decimal GetValorProduto(decimal CodigoProduto)
        {
            var valor = dbContext.Produto.Where(x => x.Id == CodigoProduto).Select(x => x.Valor).FirstOrDefault();
            return dbContext.Produto.Where(x => x.Id == CodigoProduto).Select(x => x.Valor).FirstOrDefault();

             
        }
    }
}
