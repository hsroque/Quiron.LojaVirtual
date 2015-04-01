using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTestCarrinho
    {
        //Teste de add itens ao carrinho
        [TestMethod]
        public void TestarAdicionarItem()
        {

            // Arragne - criação dos produtos

            Produto produto1 = new Produto { ProdutoId = 1, Nome = "TesteProduto1" };
            Produto produto2 = new Produto { ProdutoId = 2, Nome = "TesteProduto2" };

            // Arrange
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);



            //Act
            List<ItemCarrinho> itens = carrinho.ItensCarrinho;

            //Assert
            Assert.AreEqual(itens.Count, 2);
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[0].Quantidade, 2);
            Assert.AreEqual(itens[1].Quantidade, 3);

        }

        [TestMethod]
        public void TestarProdutoExistente()
        {
            // Arragne - criação dos produtos

            Produto produto1 = new Produto { ProdutoId = 1, Nome = "TesteProduto1" };
            Produto produto2 = new Produto { ProdutoId = 2, Nome = "TesteProduto2" };


            // Arrange
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 2);

            carrinho.AdicionarItem(produto1, 10);

            //Act
            List<ItemCarrinho> itens = carrinho.ItensCarrinho.OrderBy(p => p.Produto.ProdutoId).ToList();


            //Assert
            Assert.AreEqual(itens.Count, 2);
            Assert.AreEqual(itens[0].Quantidade, 11);
            Assert.AreEqual(itens[1].Quantidade, 2);
        }

        [TestMethod]
        public void TestarRemoverItem()
        {
            Produto produto1 = new Produto { ProdutoId = 1, Nome = "TesteProduto1" };
            Produto produto2 = new Produto { ProdutoId = 2, Nome = "TesteProduto2" };

            // Arrange
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);
            carrinho.AdicionarItem(produto1, 4);
            carrinho.AdicionarItem(produto2, 10);

            carrinho.RemoverItem(produto1);

            List<ItemCarrinho> itens = carrinho.ItensCarrinho;

            Assert.AreEqual(itens.Count, 1);
            Assert.AreEqual(itens[0].Produto, produto2);
            Assert.AreEqual(itens[0].Quantidade, 13);

        }

        [TestMethod]
        public void TestarValorTotal()
        {
            // Arragne - criação dos produtos

            Produto produto1 = new Produto { ProdutoId = 1, Nome = "TesteProduto1", Preco = 100M };
            Produto produto2 = new Produto { ProdutoId = 2, Nome = "TesteProduto2", Preco = 50M };


            // Arrange
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 2);

            carrinho.AdicionarItem(produto1, 4);

            //Act
            List<ItemCarrinho> itens = carrinho.ItensCarrinho.OrderBy(p => p.Produto.ProdutoId).ToList();

            decimal result = carrinho.ObterValorTotal();

            //Assert
            Assert.AreEqual(itens.Count, 2);
            Assert.AreEqual(result, 600M);
        }

        [TestMethod]
        public void TestarLimparCarrinho()
        {

            // Arragne - criação dos produtos

            Produto produto1 = new Produto { ProdutoId = 1, Nome = "TesteProduto1" };
            Produto produto2 = new Produto { ProdutoId = 2, Nome = "TesteProduto2" };

            // Arrange
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);

            carrinho.LimparCarrinho();

            Assert.AreEqual(carrinho.ItensCarrinho.Count, 0);
        }
    }
}
