<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="produtos.aspx.cs" Inherits="lojavirtual.produtos" %>

<!doctype html>
<html lang="pt-br">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Bootstrap CSS -->
    <!--CDN: Content Delivery Network-->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"
        integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">

    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js"
        integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n"
        crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"
        integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo"
        crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"
        integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6"
        crossorigin="anonymous"></script>

    <script src="https://kit.fontawesome.com/76ead412be.js" crossorigin="anonymous"></script>
    <title>Produtos</title>
</head>

<body class="container">

    <div class="jumbotron">
        <h3>Produtos </h3>
    </div>
    <div id="divErro" runat="server"></div>
    <div id="formulario">
        <form id="formCadastro" runat="server">
            <div class="row">
                <div class="form-group col-md-6">
                    <label for="txtId">Id:</label>
                    <input type="number" id="txtId" class="form-control" placeholder="ID" runat="server" disabled="disabled">
                </div>
                <div class="form-group col-md-6">
                    <label for="txtCodigo">Código:</label>
                    <input type="text" id="txtCodigo" class="form-control" placeholder="CÓDIGO" runat="server">
                </div>
            </div>
            <div class="form-group">
                <label for="txtDescricao">Descrição:</label>
                <input type="text" id="txtDescricao" class="form-control" placeholder="DESCRIÇÃO" runat="server">
            </div>
            <div class="row">
                <div class="form-group col-md-4">
                    <label for="txtDataValidade">Validade:</label>
                    <input type="date" id="txtDataValidade" class="form-control" runat="server">
                </div>
                <div class="form-group col-md-4">
                    <label for="txtQuantidade">Quantidade:</label>
                    <input type="number" id="txtQuantidade" class="form-control" placeholder="QUANTIDADE" min="0" value="0" step="1" runat="server">
                </div>
                <div class="form-group col-md-4">
                    <label for="txtPreco">Preço:</label>
                    <input type="number" id="txtPreco" class="form-control" placeholder="PREÇO" min="0" value="0" step="0.01" runat="server">
                </div>
            </div>
            <button type="submit" id="btnCadastrar" class="btn btn-info" runat="server" onserverclick="btnCadastrar_ServerClick">Salvar</button>
            <hr />
            <br />
            <br />
            <asp:GridView ID="gdvProdutos" runat="server" CssClass="table table-borderless table-hover" 
                GridLines="None" AutoGenerateColumns="false" EmptyDataText="Não há produtos cadastrados"
                OnRowCommand="gdvProdutos_RowCommand" >
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="codigo" />
                    <asp:BoundField HeaderText="Descrição" DataField="descricao" />
                    <asp:BoundField HeaderText="Validade" DataField="validade" DataFormatString="{0:d}" />
                    <asp:BoundField HeaderText="Quantidade" DataField="quantidade" />
                    <asp:BoundField HeaderText="Preço" DataField="preco" DataFormatString="{0:C}" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Alterar" runat="server" CommandName="alterar" 
                                CommandArgument='<%# Eval("id") %>' CssClass="btn btn-info">Editar</asp:LinkButton>
                            <asp:LinkButton ID="Excluir" runat="server" CommandName="excluir" 
                                CommandArgument='<%# Eval("id") %>' CssClass="btn btn-info">Excluir</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </form>
    </div>
    <hr>
</body>

</html>
