using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class ProdutosRepositorio
    {
        private readonly EfDbContext context = new EfDbContext();


        public IEnumerable<Produto> Produtos
        {
            get { return context.Produtos; }
        }

        public void Salvar(Produto produto)
        {
            if (produto.ProdutoId == 0)
            {
                context.Produtos.Add(produto);
            }
            else
            {
                Produto prod = context.Produtos.FirstOrDefault(p => p.ProdutoId == produto.ProdutoId);
                if (prod != null)
                {
                    prod.Nome = produto.Nome;
                    prod.Categoria = produto.Categoria;
                    prod.Descricao = produto.Descricao;
                    prod.Preco = produto.Preco;
                }
            }

            context.SaveChanges();
        }
    }
}
