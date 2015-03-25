using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio repositorio;

        public int ProdutosPorPagina = 3;
        // GET: Produto
        public ViewResult ListaProdutos(int pagina = 1)
        {
            repositorio = new ProdutosRepositorio();

            ProdutosViewModel model = new ProdutosViewModel
            {
                Produtos = repositorio.Produtos
                        .OrderBy(p => p.Descricao)
                        .Skip((pagina - 1) * ProdutosPorPagina)
                        .Take(ProdutosPorPagina),

                Paginacao = new Paginacao
                {
                    ItensPorPagina = ProdutosPorPagina,
                    ItensTotal = repositorio.Produtos.Count(),
                    PaginaAtual = pagina
                }

            };


            return View(model);
        }
    }
}