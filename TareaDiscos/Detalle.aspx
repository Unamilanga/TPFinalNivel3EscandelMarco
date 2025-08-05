<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="TareaDiscos.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container-fluid p-4 back">
        <div class="card shadow-lg rounded-3 border-0 custom-card-color">
            <div class="card-body p-4 p-md-5">
            
                <div class="text-center mb-5">
                    <h2 class="fw-bold text-secondary">Formulario de Artículo</h2>
                    <p class="text-muted">Complete todos los campos requeridos</p>
                    <hr class="mx-auto w-25 my-4">
                </div>
            
            <div class="row g-4">
                <div class="col-12 col-md-6">
                       <div class="mb-4">

                    <asp:Label AssociatedControlID="txtCodigo" runat="server" Text="Código del Articulo" CssClass="form-label fw-semibold"></asp:Label>
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control border border-secondary" placeholder="El CODIGO no se puede editar, revise antes de aceptar." ></asp:TextBox>
                           <asp:RequiredFieldValidator ControlToValidate="txtCodigo" ErrorMessage="El código es obligatorio" runat="server" ForeColor="Red" Display="Dynamic" />
                           <asp:Label ID="LblErroresCd" runat="server" CssClass="text-danger" EnableViewState="false"></asp:Label>
                       </div>
                    <div class="mb-4">
                        <asp:Label AssociatedControlID="txtNombre" Text="Nombre del Articulo" runat="server" CssClass="form-label fw-bold required" />
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control border border-secondary" placeholder="Ej: Motorola g"></asp:TextBox>
                        <asp:Label ID="LblErroresNb" runat="server" CssClass="text-danger" EnableViewState="false"></asp:Label>

                    </div>
                    <div class="mb-4">
                        <asp:Label AssociatedControlID="txtDescripcion" runat="server" Text="Descripción" CssClass="form-label fw-bold required"></asp:Label>
                        <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control border border-secondary" placeholder="Ej: Descripción ..." TextMode="MultiLine" Rows="3" ></asp:TextBox>
                        <asp:Label ID="LblErroresDp" runat="server" CssClass="text-danger" EnableViewState="false"></asp:Label>
                    </div>
                    <asp:Button ID="BtnAceptarr" runat="server" Text="Aceptar" CssClass="btn btn-dark me-2 mb-2" OnClick="BtnAceptarr_Click" OnClientClick="return confirm('¿Seguro que desea Continuar?');"/>
                    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-dark me-2 mb-2" OnClick="BtnCancelar_Click" CausesValidation="false"/>
                </div>
                <div class="col-12 col-md-6">
                    <div class="mb-4">
                        <asp:Label runat="server" AssociatedControlID="ddMarca" CssClass="form-label fw-bold" Text="Marca"></asp:Label>
                        <asp:DropDownList ID="ddMarca" runat="server"  CssClass="form-select border border-secondary"></asp:DropDownList>
                    </div>
                    <div class="mb-4">
                        <asp:Label runat="server" AssociatedControlID="ddCategoria" CssClass="form-label fw-bold" text="Categoria"></asp:Label>
                        <asp:DropDownList ID="ddCategoria" runat="server" CssClass="form-select border border-secondary"></asp:DropDownList>
                    </div>
                    <div class="mb-4">
                        <asp:Label AssociatedControlID="txtPrecio" runat="server" CssClass="form-label fw-bold required">Precio</asp:Label>
                        <div class="input-group">
                            <span class="input-group-text border border-secondary" >$</span>
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control text-end border border-secondary" TextMode="Number"></asp:TextBox>
                        </div>
                            <asp:RequiredFieldValidator ControlToValidate="txtPrecio" ErrorMessage="El Precio es obligatorio" runat="server" ForeColor="Red" Display="Dynamic" />
                            
                    </div>

                    <div class="mb-4">
                        <asp:Label  runat="server" CssClass="form-label fw-bold" AssociatedControlID="txtUrl">Imagen URL</asp:Label>
                        <div class="input-group">
                            <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control border border-secondary" 
                                       placeholder="https://ejemplo.com/imagen.jpg"></asp:TextBox>
                            <asp:Label ID="LblErrorUrl" runat="server" CssClass="text-danger" EnableViewState="false"></asp:Label>
                            <button class="btn btn-outline-secondary" type="button" data-bs-toggle="modal" data-bs-target="#modalSubirImagen">
                                <i class="bi bi-upload"></i>
                            </button>
                        </div>
                   </div>
            </div>
        </div>
        </div>
    </div>
</div>
    
</asp:Content>
