using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Web.Areas.Administrativo.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutosRepositorio _repositorio;

        // GET: Administrativo/Produto
        public ActionResult Index()
        {
            _repositorio = new ProdutosRepositorio();

            var produtos = _repositorio.Produtos;

            return View(produtos);
        }

        public ViewResult NovoProduto()
        {

            return View();
        }

        public ViewResult Alterar(int ProdutoId)
        {

            _repositorio = new ProdutosRepositorio();

            Produto produto = (Produto)_repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == ProdutoId);

            return View(produto);
        }

        [HttpPost]
        public ActionResult Alterar(Produto Produto)
        {
            if (ModelState.IsValid)
            {
                _repositorio = new ProdutosRepositorio();
                _repositorio.Salvar(Produto);

                TempData["mensagem"] = string.Format("{0} foi salvo com sucesso", Produto.Nome);
            }
            return RedirectToAction("Index");
        }


        public ActionResult Excluir(int ProdutoId)
        {
            _repositorio = new ProdutosRepositorio();

            Produto produto = (Produto)_repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == ProdutoId);

            return View();
        }

    }
}