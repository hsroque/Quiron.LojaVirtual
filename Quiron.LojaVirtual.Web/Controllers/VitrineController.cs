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

        public int ProdutosPorPagina = 5;
        // GET: Produto
        public ViewResult ListaProdutos(string categoria, int pagina = 1)
        {
            repositorio = new ProdutosRepositorio();

            ProdutosViewModel model = new ProdutosViewModel
            {
                Produtos = repositorio.Produtos
                        .Where(p => categoria == null || p.Categoria == categoria)
                        .OrderBy(p => p.Nome)
                        .Skip((pagina - 1) * ProdutosPorPagina)
                        .Take(ProdutosPorPagina),


                CategoriaAtual = categoria

            };


            model.Paginacao = new Paginacao{
                                            ItensPorPagina = ProdutosPorPagina,
                                            ItensTotal = model.Produtos.Count(),
                                            PaginaAtual = pagina
                                        };

            return View(model);
        }
    }
}