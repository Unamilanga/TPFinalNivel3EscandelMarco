<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="DescArticulo.aspx.cs" Inherits="TareaDiscos.DescArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-4">
        <div class="card shadow-lg rounded-3 border-0 custom-card-color">
            <div class="card-body p-4 p-md-5">
            <div class="row">
                <div class="col-md-6">
                    <asp:Image ID="imgArticulo" runat="server" CssClass="img-fluid rounded shadow-sm" onerror="this.onerror=null;this.src='https://cdn4.iconfinder.com/data/icons/ui-beast-3/32/ui-49-4096.png'" />
                </div>
                <div class="col-md-6">
                    <h2><asp:Label ID="lblNombre" runat="server" /></h2>
                    <p class="text-muted">
                        <strong>Categoría:</strong> <asp:Label ID="lblCategoria" runat="server" />
                    </p>
                    <p class="text-muted">
                        <strong>Marca:</strong> <asp:Label ID="lblMarca" runat="server" />
                    </p>
                    <p>
                        <asp:Label ID="lblDescripcion" runat="server" />
                    </p>
                    <div class="d-flex mt-auto gap-4">
                        <h4 class="text-success">$<asp:Label ID="lblPrecio" runat="server" /></h4>
                        <a href="Default.aspx" class="btn btn-secondary mt-3">← Volver</a>
                        <asp:LinkButton runat="server" ID="LbAgregarFav" CommandName="AgregarFv" CommandArgument='<%#Eval("Codigo")%>' CssClass="btn btn-outline-dark mt-auto align-self-start" OnClick="LbAgregarFav_Click"><i class="bi bi-star me-1"></i></asp:LinkButton>
                    </div>
                </div>
            </div>
            </div>
            </div>
    </div>
</asp:Content>
