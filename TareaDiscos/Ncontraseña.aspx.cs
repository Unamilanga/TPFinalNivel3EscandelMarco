using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using NegocioUsuario;
using EmailService;

namespace TareaDiscos
{
	public partial class Ncontraseña : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void BtnCambiar_Click(object sender, EventArgs e)
        {
            LblActualError.Text = "";
            LblPassNueva.Text = "";
            LblConfirmarError.Text = "";

            Usuario user = (Usuario)Session["Usuario"];
            if (txtPassActual.Text == user.Pass)
            {
                if (txtPassNueva.Text.Length < 20)
                {
                    if ((txtPassNueva.Text == txtPassConfirmar.Text))
                    {
                        string nuevaContraseña = txtPassNueva.Text;
                        Usuarios negocio = new Usuarios();
                        negocio.CambiarContraseña(user, nuevaContraseña);
                        Usuario actualizado = negocio.ObtenerUsuario(user.Email, nuevaContraseña);
                        Session["usuario"] = actualizado;
                        Servicio mail = new Servicio();
                        mail.CambioDeContraseña(actualizado.Email, nuevaContraseña);
                        Response.Redirect("MiPerfil.aspx", false);

                    }
                    else { LblConfirmarError.Text = "Las contraseñas no coinciden."; }

                }
                else { LblPassNueva.Text = "La contraseña nueva no puede tener mas de 20 caracteres."; }

            }
            else { LblActualError.Text = "La contraseña actual es incorrecta."; }
        }
    }
}