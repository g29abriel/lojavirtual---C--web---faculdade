using lojavirtual.Entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace lojavirtual.Dado
{
    public class dProduto : Produto
    {
        public void InserirProduto(Produto prod)
        {
            //String interpolation
            string query = $"INSERT INTO produtos (codigo, descricao, validade, quantidade, preco) " +
                $"VALUES ('{prod.codigo}','{prod.descricao}','{prod.validade}',{prod.quantidade},{prod.preco})";

            conexao.ModificarTabela(query);
        }

        public void ExcluirProduto(int produtoId)
        {
            string query = $"DELETE FROM produtos WHERE id = {produtoId}";
            conexao.ModificarTabela(query);
        }

        public DataTable RecuperarTodosProdutos()
        {
            string query = 
                "SELECT " +
                    "id, " +
                    "codigo, " +
                    "descricao, " +
                    "validade, " +
                    "quantidade, " +
                    "preco " +
                "FROM produtos";
            return conexao.RecuperarDados(query);
        }

        public Produto RecuperarProdutoPorId(int produtoId)
        {
            string query =
                "SELECT " +
                    "id, " +
                    "codigo, " +
                    "descricao, " +
                    "validade, " +
                    "quantidade, " +
                    "preco " +
                $"FROM produtos WHERE id = {produtoId}";
            DataTable dt = conexao.RecuperarDados(query);

            Produto prod = new Produto();
            prod.id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
            prod.codigo = dt.Rows[0]["codigo"].ToString();
            prod.descricao = dt.Rows[0]["descricao"].ToString();
            prod.validade = dt.Rows[0]["validade"].ToString();
            prod.quantidade = Convert.ToInt32(dt.Rows[0]["quantidade"].ToString());
            prod.preco = Convert.ToDouble(dt.Rows[0]["preco"].ToString());
            return prod;
        }

        public void AtualizarProduto(Produto produto)
        {
            string query = $"UPDATE produtos SET " +
                    $"codigo = '{produto.codigo}', " +
                    $"descricao = '{produto.descricao}', " +
                    $"validade = '{produto.validade}', " +
                    $"quantidade = {produto.quantidade}, " +
                    $"preco = {produto.preco.ToString("0.00", CultureInfo.InvariantCulture)} " +
                $"WHERE id = {produto.id}";

            conexao.ModificarTabela(query);
        }
    }
}