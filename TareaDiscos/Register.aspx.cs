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
	public partial class Register : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}


        protected void BtnAceptar_Click1(object sender, EventArgs e)
        {
            lblCorreoNuevo.Text = "";
            lblContraseñaNueva.Text = "";
            if (!Page.IsValid) return;

            string correo = txtCorreoNuevo.Text;
            string contraseña = txtContraseña.Text;
            Usuarios usuarios = new Usuarios();

            if (correo.Length < 100)
            {
                if (contraseña.Length < 20)
                {
                    if (usuarios.ExisteMail(correo))
                    {
                        lblCorreoNuevo.Text = "El correo ya está registrado";
                        return;
                    }
                    // Verifica de nuevo antes de crear el usuario
                    if (!usuarios.ExisteMail(correo))
                    {
                        var userId = usuarios.NuevoUser(correo, contraseña);
                        Servicio mail = new Servicio();
                        //mail.Registro(correo, contraseña);
                        mail.Registro(correo, contraseña);
                        Usuario nuevo = usuarios.ObtenerUsuario(correo, contraseña);

                        Session.Add("Usuario", nuevo);
                        Response.Redirect("MiPerfil.aspx", false);
                        return;
                    }
                }
                else
                {
                    lblContraseñaNueva.Text = "Menos de 20 caracteres";

                }
            }
            else
            {
                lblCorreoNuevo.Text = "Menos de 100 caracteres";
            }
            //revisar EmailService
        }
    }
}