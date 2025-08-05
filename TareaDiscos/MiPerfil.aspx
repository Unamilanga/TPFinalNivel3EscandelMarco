<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TareaDiscos.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid p-4 back">
        <div class="card shadow-lg rounded-3 border-0 custom-card-color">
            <div class="card-body p-4 p-md-5">
            
                <div class="text-center mb-5">
                    <h2 class="fw-bold text-secondary">Mi Perfil</h2>
                    <p class="text-muted">Complete todos los campos requeridos</p>
                    <hr class="mx-auto w-25 my-4">
                </div>
            
            <div class="row g-4">
                <div class="col-12 col-md-6">
                       <div class="mb-4">
                    <asp:Label AssociatedControlID="txtNombre" runat="server" Text="Nombre" CssClass="form-label fw-semibold"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control border border-secondary" ReadOnly="true"></asp:TextBox>
                           <asp:Label ID="NombreError" runat="server" CssClass="text-danger" EnableViewState="false"></asp:Label>
                        </div>
                    <div class="mb-4">
                        <asp:Label AssociatedControlID="txtApellido" Text="Apellido" runat="server" CssClass="form-label fw-bold required" />
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control border border-secondary" ReadOnly="true" ></asp:TextBox>
                        <asp:Label ID="ApellidoError" runat="server" CssClass="text-danger" EnableViewState="false"></asp:Label>
                    </div>
                    <div class="mb-4">
                        <asp:Label AssociatedControlID="txtCorreo" runat="server" Text="Correo" CssClass="form-label fw-semibold"></asp:Label>
                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control border border-secondary" ReadOnly="true"></asp:TextBox>
                    </div>

                    <asp:Button ID="BtnAceptarr" runat="server" Text="Aceptar" CssClass="btn btn-dark me-2 mb-2" OnClick="BtnAceptarr_Click" OnClientClick="return confirm('¿Seguro que desea Continuar?');" Visible="false" />
                    <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-dark me-2 mb-2" CausesValidation="false" OnClick="BtnCancelar_Click" Visible="false"/>
                    <asp:Button ID="BtnEditar" runat="server" Text="Editar Perfil" CssClass="btn btn-dark me-2 mb-2" OnClick="BtnEditar_Click" Visible="true"/>
                    <asp:Button ID="BtnNcon" runat="server" Text="Cambiar Contraseña" CssClass="btn btn-dark me-2 mb-2" PostBackUrl="~/Ncontraseña.aspx" Visible="true" />
                </div>                                  
                <div class="col-12 col-md-6">
                    <asp:UpdatePanel ID="updPreview" runat="server">
                        <ContentTemplate>
                                <div class="mb-4">
                                     <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control border border-secondary" placeholder="https://ejemplo.com/imagen.jpg" ReadOnly="True" ClientIDMode="Static" />
                                     <asp:Button ID="BtnUsarUrl" runat="server" Text="Usar URL" CssClass="btn btn-outline-secondary" OnClick="BtnUsarUrl_Click" />
                                    <asp:Image ID="previewImg" runat="server" CssClass="border mt-2" Width="150" Height="150"  onerror="this.onerror=null;this.src='https://cdn4.iconfinder.com/data/icons/ui-beast-3/32/ui-49-4096.png';" />
                                </div>
                        </ContentTemplate>
                        </asp:UpdatePanel>


            </div>
        </div>
        </div>
    </div>
</div>
    <script src="Scripts/PerfilImagen.js"></script>
</asp:Content>
