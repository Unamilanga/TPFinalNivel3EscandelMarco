
<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Modificar.aspx.cs" Inherits="TareaDiscos.Modificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1 class="text-center fw-bold display-5 mt-4 mb-2">Tabla de articulos</h1>
<p class="text-center text-muted mb-4">Gestor de articulos</p>

<ContentTemplate>
    <div class="form-group d-flex flex-column flex-md-row align-items-md-center mb-3">
        
        <asp:TextBox ID="txtBuscador" runat="server" CssClass="form-control border border-secondary w-100 w-md-auto" placeholder="Buscar articulo ..." OnTextChanged="TxtBuscador_TextChanged" AutoPostBack="true" />
    </div>

    <div class="table-responsive rounded-3 shadow-lg w-100">
        <asp:GridView ID="GvArticulos" runat="server" CssClass="table table-hover table-striped align-middle mb-0 w-100" AutoGenerateColumns="false" DataKeyNames="Codigo" OnPageIndexChanging="GvArticulos_PageIndexChanging" HeaderStyle-CssClass="table-dark"
            AllowPaging="true" PageSize="3" PagerSettings-Mode="NumericFirstLast" PagerSettings-Position="Bottom" PagerStyle-CssClass="pagination" PagerStyle-ForeColor="Gray"
            SelectedRowStyle-CssClass="table-active" GridLines="None" OnRowCommand="GvArticulos_RowCommand">

            <Columns>
                <asp:BoundField HeaderText="Código" DataField="Codigo" ItemStyle-CssClass="fw-semibold" />
                <asp:BoundField HeaderText="Modelo" DataField="Nombre" ItemStyle-CssClass="fw-semibold" />
                <asp:BoundField HeaderText="Categoria" DataField="Categoria" ItemStyle-CssClass="fw-semibold d-none d-md-table-cell" />
                <asp:BoundField HeaderText="Marca" DataField="Marca" ItemStyle-CssClass="fw-semibold d-none d-md-table-cell" />
                <asp:BoundField HeaderText="Precio $" DataField="Precio" ItemStyle-CssClass="fw-semibold" DataFormatString="{0:F}" HtmlEncode="false" />

                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar" ControlStyle-ForeColor="Gray" CommandArgument='<%# Eval("Codigo") %>' CssClass="btn btn-link p-0 text-primary">
                            <i class="bi bi-pencil"></i>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnBorrar" runat="server" CommandName="Borrar" CssClass="btn btn-link btn-sm text-danger p-0" OnClientClick="return confirm('¿Seguro que desea borrar?');" CommandArgument='<%# Eval("Codigo") %>'>
                            <i class="bi bi-trash"></i>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</ContentTemplate>

<asp:Button ID="BtnAgregar" OnClick="Agregar_Click" runat="server" Text="Agregar" CssClass="btn btn-dark mt-3" />

</asp:Content>