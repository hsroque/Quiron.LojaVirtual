using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;


namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CategoriaController : Controller
    {

        private ProdutosRepositorio repositorio;

        // GET: Categoria
        public PartialViewResult Menu(string categoria = null)
        {

            ViewBag.CategoriaSelecionada = categoria;

            repositorio = new ProdutosRepositorio();

            IEnumerable<string> categorias = repositorio.Produtos
                .Select(p => p.Categoria)
                .Distinct()
                .OrderBy(c => c);


            return PartialView(categorias);
        }
    }
}