using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using lojavirtual.Entidade;
using lojavirtual.Negocio;

namespace lojavirtual
{
    public partial class produtos : System.Web.UI.Page
    {
        private nProduto negocioProduto = new nProduto();
        private Produto prod;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                gdvProdutos.DataSource = negocioProduto.RecuperarTodosProdutos();
                gdvProdutos.DataBind();
            }
            catch (Exception exp)
            {
                divErro.InnerText = exp.Message;
            }
        }


        protected void btnCadastrar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                prod = new Produto();
                string id = txtId.Value == "" ? "0" : txtId.Value;
                prod.id= Convert.ToInt32(id);
                prod.codigo = txtCodigo.Value;
                prod.descricao = txtDescricao.Value;
                prod.validade = txtDataValidade.Value;
                prod.quantidade = Convert.ToInt32(txtQuantidade.Value);
                prod.preco = Convert.ToDouble(txtPreco.Value, CultureInfo.InvariantCulture);

                if (prod.id != 0)
                {
                    negocioProduto.AtualizarProduto(prod);
                }
                else
                {
                    negocioProduto.CadastrarProduto(prod);
                }
            }
            catch (Exception exp)
            {
                divErro.InnerText = exp.Message;
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void gdvProdutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int idProduto = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "excluir")
                {
                    negocioProduto.ExcluirProduto(idProduto);
                    Response.Redirect(Request.Url.AbsoluteUri);
                } else if (e.CommandName == "alterar") {
                    Produto prod = negocioProduto.RecuperarProdutoPorId(idProduto);
                    preencherFormulario(prod);
                }
            }
            catch (MySqlException exp)
            {
                divErro.InnerText = exp.Message;
            }
        }

        private void preencherFormulario(Produto produto)
        {
            txtId.Value = produto.id.ToString();
            txtCodigo.Value = produto.codigo;
            txtDescricao.Value = produto.descricao;
            txtDataValidade.Value = Convert.ToDateTime(produto.validade).ToString("yyyy-MM-dd");
            txtQuantidade.Value = produto.quantidade.ToString();
            txtPreco.Value = produto.preco.ToString(CultureInfo.InvariantCulture);
        }
    }
}