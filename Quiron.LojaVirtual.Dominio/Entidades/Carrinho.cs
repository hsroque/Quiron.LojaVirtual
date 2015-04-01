using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> _ItensCarrinho = new List<ItemCarrinho>();

        //add
        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = _ItensCarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);


            if (item == null)
                _ItensCarrinho.Add(new ItemCarrinho { Produto = produto, Quantidade = quantidade });
            else
                item.Quantidade += quantidade;
        }

        //remove
        public void RemoverItem(Produto produto)
        {
            _ItensCarrinho.RemoveAll(p => p.Produto.ProdutoId == produto.ProdutoId);
        }


        //obter valor total
        public decimal ObterValorTotal()
        {
            return _ItensCarrinho.Sum(p => p.Produto.Preco * p.Quantidade);
        }


        //limpar
        public void LimparCarrinho()
        {
            _ItensCarrinho.Clear();
        }

        //itens carrinho
        public List<ItemCarrinho> ItensCarrinho
        {
            get
            {
                return _ItensCarrinho.ToList();
            }
        }


    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}
