<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TareaDiscos.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <h1 class="text-center fw-bold display-5 mt-4 mb-2">¡Descubrí nuestras novedades!</h1>
    <p class="text-center text-muted mb-4">Los productos más recientes</p>



    <div class="container mt-4">
        <!-- Barra de búsqueda -->
        <div class="row mb-4">
            <div class="col-12">
                <asp:TextBox ID="TxtBuscador" runat="server" placeholder="¿Qué estás buscando?" CssClass="form-control border border-secondary" OnTextChanged="TxtBuscador_TextChanged" AutoPostBack="true"></asp:TextBox>
            </div>
        </div>

        <!-- Filtros a la izquierda y tarjetas a la derecha -->
        <div class="row">
            <!-- Columna de filtros -->
            <div class="col-12 col-md-3 mb-4 cuadro-gris p-3 rounded-3 shadow-sm">
                <label class="form-label fw-semibold">Categorías disponibles</label>
                <asp:CheckBoxList ID="cblCategorias" runat="server" CssClass="form-check" RepeatDirection="Vertical" RepeatLayout="Flow" />

                <hr />

                <label class="form-label fw-semibold">Marcas disponibles</label>
                <asp:CheckBoxList ID="cblMarcas" runat="server" CssClass="form-check" RepeatDirection="Vertical" RepeatLayout="Flow" />

                <hr />

                <asp:Button ID="btfiltro" runat="server" Text="Filtrar" CssClass="btn btn-outline-dark mt-auto align-self-start w-40" OnClick="btfiltro_Click" />
                <asp:Button ID="btcancelar" runat="server" Text="Limpiar filtro" CssClass="btn btn-outline-dark mt-auto align-self-start w-40" OnClick="btcancela_Click" />
            </div>

            <!-- Columna de tarjetas -->
            <div class="col-12 col-md-9">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row row-cols-1 row-cols-md-3 g-4">
                            <asp:Repeater runat="server" ID="RepetidorArticulos">
                                <ItemTemplate>
                                    <div class="col">
                                        <div class="card h-100 border-0 shadow-sm hover-effect">
                                            <img src="<%# Eval("ImagenUrl") %>" class="card-img-top"
                                                 onerror="this.onerror=null;this.src='https://cdn4.iconfinder.com/data/icons/ui-beast-3/32/ui-49-4096.png';" />
                                            <div class="card-body d-flex flex-column">
                                                <h5 class="card-title text-truncate" title='<%# Eval("Nombre") %>'><%# Eval("Nombre") %></h5>
                                                <p class="card-text flex-grow-1 line-clamp-2" data-bs-toggle="tooltip"
                                                   title='<%# Eval("Descripcion") %>'><%# Eval("Descripcion") %></p>
                                                <p class="card-text"><small class="text-body-secondary"><%# Eval("Categoria") %></small></p>
                                                <asp:LinkButton runat="server"
                                                                CommandName="DetalleId"
                                                                CommandArgument='<%# Eval("Codigo") %>'
                                                                CssClass="btn btn-outline-dark mt-auto align-self-start"
                                                                OnClick="BtnDetalle_Click">
                                                    <i class="bi bi-eye-fill me-1"></i> Ver detalle
                                                </asp:LinkButton>
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
    </div>

</asp:Content>
