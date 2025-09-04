using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using NegocioSeguridad;

namespace TareaDiscos
{
	public partial class Maestra : System.Web.UI.MasterPage
	{
        public bool EsAdmin { get; set; } = false;
        protected void Page_Load(object sender, EventArgs e)
		{

			if(!(Page is Login || Page is Register || Page is Default || Page is Error || Page is DescArticulo))
			{
				if (!Seguridad.SesionActiva(Session["Usuario"]))
                {
                   Response.Redirect("Login.aspx", false);
                   return;
                }
            }

            if (Page is Modificar || Page is Detalle)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                if (!usuario.Admin)
                {
                    Response.Redirect("Default.aspx", false);
                    return;
                }
            }


            if (Seguridad.SesionActiva(Session["Usuario"]))
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                EsAdmin = usuario.Admin;
            }



        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Default.aspx", false );
        }
    }
}