<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TareaDiscos.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
    <div class="row">
        <div class="col-12 col-sm-8 col-md-6 col-lg-5 col-xl-4 mx-auto">
                <div class="card shadow-lg rounded-3 border-0 custom-card-color">
                    <div class="card-body p-4 p-md-5">
                    <div class="text-center mb-6">
                        <h2 class="fw-bold text-secondary">Bienvenido</h2>
                        <p class="text-muted">Registrese</p>
                        <hr class="mx-auto w-25 my-4">
                    </div>
                                <div class="col-10 mx-auto">
                                    <div class="my-4">
                                            <asp:Label AssociatedControlID="txtCorreoNuevo" runat="server" Text="Correo" CssClass="form-label fw-semibold"></asp:Label>
                                            <asp:TextBox ID="txtCorreoNuevo" runat="server" TextMode="Email" CssClass="form-control border border-secondary" placeholder="Ej: ejemplo@mail.com" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtCorreoNuevo" ErrorMessage="El correo es obligatorio" runat="server" ForeColor="Red" Display="Dynamic" />
                                            <asp:Label ID="lblCorreoNuevo" runat="server" CssClass="text-danger" EnableViewState="false"></asp:Label>
                                    </div>

                                    <div class="my-4">
                                                <asp:Label AssociatedControlID="txtContraseña" runat="server" Text="Contraseña" CssClass="form-label fw-semibold"></asp:Label>
                                                    <div class="input-group">
                                                        <asp:TextBox ID="txtContraseña" ClientIDMode="Static" runat="server" TextMode="Password" CssClass="form-control border border-secondary" placeholder="Ingrese su contraseña"></asp:TextBox>
                                                        <button type="button" id="btnShowPass" class="btn btn-outline-secondary">👁️</button>
                                                         </div>
                                                        <asp:RequiredFieldValidator ControlToValidate="txtContraseña" ErrorMessage="La contraseña es obligatorio" runat="server" ForeColor="Red" Display="Dynamic" />
                                                   <div class="text-end">
                                                        <asp:Label ID="lblContraseñaNueva" runat="server" CssClass="text-danger" EnableViewState="false"></asp:Label>
                                             </div>
                                    </div>
                                 </div>
                        
                        <div class="d-flex justify-content-center mb-4">
                            <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" OnClick="BtnAceptar_Click1" CssClass="btn btn-dark w-50" />
                        </div>
                    </div>
                </div>

        </div>
    </div>
</div>
</asp:Content>
