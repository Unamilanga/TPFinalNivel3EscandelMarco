using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using EmailService;
using NegocioUsuario;

namespace TareaDiscos
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void LbOlvido_Click(object sender, EventArgs e)
        {
            lblMensajeCorreo.Text = "";
            Usuarios usu = new Usuarios();
            Servicio servicio = new Servicio();
            if(!Page.IsValid) return;

            if (usu.ExisteMail(txtCorreo.Text))
            {
                servicio.RecuperarContraseña(txtCorreo.Text, usu.RecuperarContraseña(txtCorreo.Text));
                lblMensajeCorreo.Text = "Se ha enviado un correo a su cuenta";

            }




        }

        protected void LbNueva_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void BtnAcceder_Click(object sender, EventArgs e)
        {
            lblMensajeCorreo.Text = "";
            lblMensajeContraseña.Text = "";

            if (!Page.IsValid) return;

            string correo = txtCorreo.Text;
            string contraseña = txtContraseña.Text;
            Usuarios ingreso = new Usuarios();

            if (!ingreso.ExisteMail(correo))
            {
                lblMensajeCorreo.Text = "El correo no está registrado o no existe";
                return;
            }

            if (!ingreso.CoincideUser(correo, contraseña))
            {
                lblMensajeContraseña.Text = "Contraseña incorrecta";
                return;
            }

            Usuario usuarios = ingreso.ObtenerUsuario(correo, contraseña);
            Session.Add("Usuario", usuarios);
            Response.Redirect("Default.aspx", false);

        }

    }
}