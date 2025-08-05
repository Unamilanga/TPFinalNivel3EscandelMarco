using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using NegocioUsuario;

namespace TareaDiscos
{
	public partial class MiPerfil : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["Usuario"];
                    txtNombre.Text = (usuario.Nombre);
                    txtApellido.Text = (usuario.Apellido);
                    txtCorreo.Text = (usuario.Email);
                    txtUrl.Text = string.IsNullOrEmpty(usuario.urlImagenPerfil) ? "https://via.placeholder.com/40" : usuario.urlImagenPerfil;
                    previewImg.ImageUrl = string.IsNullOrEmpty(usuario.urlImagenPerfil) ? "https://via.placeholder.com/150" : usuario.urlImagenPerfil;

                }
            }

		}

        protected void BtnAceptarr_Click(object sender, EventArgs e)
        {
            NombreError.Text = "";
            ApellidoError.Text = "";
            if (!Page.IsValid) return;

            if ((txtNombre.Text).Length > 50 || (txtNombre.Text=="")) { NombreError.Text = "No superior a 50 caracteres, ni vacio"; return; }
            if ((txtApellido.Text).Length>50 || (txtApellido.Text=="" )) { ApellidoError.Text = "No superior a 50 caracteres"; return; }
            Usuario user = (Usuario)Session["Usuario"];
            user.Nombre = txtNombre.Text;
            user.Apellido = txtApellido.Text;
            user.urlImagenPerfil = txtUrl.Text;
            Usuarios editar = new Usuarios();
            editar.EditarUsuario(user);
            Response.Redirect("MiPerfil.aspx", false);



        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MiPerfil.aspx", false);
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            txtNombre.ReadOnly = false;
            txtApellido.ReadOnly = false;
            txtUrl.ReadOnly = false;
            txtUrl.ReadOnly = false;
            BtnAceptarr.Visible = true;
            BtnCancelar.Visible = true;
            BtnEditar.Visible = false;
            BtnNcon.Visible = false;
        }



        protected void BtnUsarUrl_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                previewImg.ImageUrl = txtUrl.Text;
            }
            else
            {
                previewImg.ImageUrl = "https://via.placeholder.com/150";
            }
        }

    }



}