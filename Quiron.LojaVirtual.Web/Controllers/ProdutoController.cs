using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutosRepositorio repositorio;

        // GET: Produto
        public ActionResult Index()
        {
            repositorio = new ProdutosRepositorio();

            var produtos = repositorio.Produtos.Take(10);

            return View(produtos);
        }
    }
}