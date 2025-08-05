<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Ncontraseña.aspx.cs" Inherits="TareaDiscos.Ncontraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Cambiar Contraseña</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container-fluid p-4 back">
    <div class="card shadow-lg rounded-3 border-0 custom-card-color">
        <div class="card-body p-4 p-md-5">
        
            <div class="text-center mb-4">
                <h2 class="fw-bold text-secondary">Cambiar Contraseña</h2>
                <hr class="mx-auto w-25 my-3">
            </div>

            <!-- Contraseña actual -->
            <div class="mb-3">
                <asp:Label runat="server" AssociatedControlID="txtPassActual" CssClass="form-label fw-semibold"
                           Text="Contraseña actual"></asp:Label>
                <asp:TextBox ID="txtPassActual" runat="server" TextMode="Password" CssClass="form-control" />
                <asp:Label ID="LblActualError" runat="server" CssClass="text-danger" EnableViewState="false"></asp:Label>
            </div>

            <!-- Nueva contraseña -->
            <div class="mb-3">
                <asp:Label runat="server" AssociatedControlID="txtPassNueva" CssClass="form-label fw-semibold"
                           Text="Nueva contraseña"></asp:Label>
                <asp:TextBox ID="txtPassNueva" runat="server" TextMode="Password" CssClass="form-control" />
                <asp:Label ID="LblPassNueva" runat="server" CssClass="text-danger" EnableViewState="false"></asp:Label>
            </div>

            <!-- Confirmar contraseña -->
            <div class="mb-3">
                <asp:Label runat="server" AssociatedControlID="txtPassConfirmar" CssClass="form-label fw-semibold"
                           Text="Confirmar nueva contraseña"></asp:Label>
                <asp:TextBox ID="txtPassConfirmar" runat="server" TextMode="Password" CssClass="form-control" />
                <asp:Label ID="LblConfirmarError" runat="server" CssClass="text-danger" EnableViewState="false"></asp:Label>
            </div>

            <!-- Botones -->
            <div class="mt-4">
                <asp:Button ID="BtnCambiar" runat="server" Text="Cambiar contraseña" CssClass="btn btn-dark me-2 mb-2"
                            OnClick="BtnCambiar_Click"
                            OnClientClick="return confirm('¿Seguro que desea cambiar la contraseña?');" />
                <asp:Button ID="BtnVolver" runat="server" Text="Volver" CssClass="btn btn-outline-dark me-2 mb-2"
                            PostBackUrl="~/MiPerfil.aspx" />
            </div>
        </div>
    </div>
</div>



</asp:Content>
