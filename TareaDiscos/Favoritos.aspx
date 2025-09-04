<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TareaDiscos.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <h1 class="text-center fw-bold display-5 mt-4 mb-2">Mis Favoritos</h1>
    <asp:Label ID="lbFav" runat="server" ></asp:Label>
    </div>
            <div class="row mt-5">
            <div class="col-12 col-md-9 mx-auto mb-5">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="row row-cols-1 row-cols-md-3 g-4">
                            <asp:Repeater runat="server" ID="RArticulos">
                                <ItemTemplate>
                                    <div class="col">
                                        <div class="card h-100 border-0 shadow-sm hover-effect">
                                              <div class="row g-0">
                                                <div class="col-md-4">
                                                  <img src="<%# Eval("ImagenUrl") %>" class="card-img-top"
                                                    onerror="this.onerror=null;this.src='https://cdn4.iconfinder.com/data/icons/ui-beast-3/32/ui-49-4096.png';" />
                                                </div>
                                                <div class="col-md-8">
                                                  <div class="card-body">
                                                    <h5 class="card-title">
                                                        <a href='DescArticulo.aspx?Codigo=<%# Eval("Codigo") %>' class="text-decoration-none text-dark fw-bold"><%# Eval("Nombre") %></a>

                                                        </h5>
                                                    <p class="card-text"><%#Eval("Descripcion") %></p>
                                                    <asp:LinkButton runat="server" ID="Lbborrar" OnClick="Lbborrar_Click" OnClientClick="return confirm('¿Seguro que desea borrar?');" CommandArgument='<%#Eval("IdArticulo")%>' CssClass="btn-tachito"><i class="bi bi-trash"></i></asp:LinkButton>
                                                  </div>
                                                </div>
                                              </div>
                                            </div>
                                            </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
</asp:Content>
