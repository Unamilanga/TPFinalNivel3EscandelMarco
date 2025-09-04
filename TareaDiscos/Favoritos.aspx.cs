using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FavoritosNegocio;
using Dominio;

namespace TareaDiscos
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // <-- Importante: solo cargar datos la primera vez
            {
                CargarFavoritos();
            }
        }

        private void CargarFavoritos()
        {
            Favorito favoritoNegocio = new Favorito();
            List<Dominio.Favoritos> misFav = new List<Dominio.Favoritos>();
            Usuario usuario = (Usuario)Session["usuario"];

            try
            {
                if (usuario != null)
                {
                    misFav = favoritoNegocio.ObtenerFavoritos(usuario.Id);
                    RArticulos.DataSource = misFav;
                    RArticulos.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void Lbborrar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["usuario"];
                int idArticulo = int.Parse(((LinkButton)sender).CommandArgument);
                Favorito favoritoNegocio = new Favorito();
                int resultado = 0;
                favoritoNegocio.EliminarFavorito(usuario.Id, idArticulo, resultado);

                // Recarga los favoritos después de borrar
                CargarFavoritos();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }

}