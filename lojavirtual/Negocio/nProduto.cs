using lojavirtual.Dado;
using lojavirtual.Entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace lojavirtual.Negocio
{
    public class nProduto : Produto
    {
        private dProduto dadoProduto = new dProduto();
        public void CadastrarProduto(Produto prod)
        {
            if (prod.quantidade <= 0)
            {
                throw new Exception("A quantidade deve ser maior que zero.");
            }

            if (prod.preco <= 0)
            {
                throw new Exception("O preço não pode ser negativo.");
            }

            dadoProduto.InserirProduto(prod);
        }

        public void ExcluirProduto(int produtoId)
        {
            dadoProduto.ExcluirProduto(produtoId);
        }

        public DataTable RecuperarTodosProdutos()
        {
            return dadoProduto.RecuperarTodosProdutos();
        }

        public Produto RecuperarProdutoPorId(int produtoId)
        {
            return dadoProduto.RecuperarProdutoPorId(produtoId);
        }

        public void AtualizarProduto(Produto prod)
        {
            dadoProduto.AtualizarProduto(prod);
        }
    }
}