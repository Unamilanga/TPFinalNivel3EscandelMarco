using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TareaDiscos
{
	public partial class DescArticulo : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["Codigo"] != null)
            {
                try
                {
                    string codigo = (Request.QueryString["Codigo"]).ToString();
                    Catalogo catalogos = new Catalogo();
                    Articulo articulo = catalogos.FiltroCodigo(codigo);
                    if (articulo != null)
                    {
                        

                        lblNombre.Text = (articulo.Nombre).ToString();
                        lblDescripcion.Text = (articulo.Descripcion).ToString();
                        lblPrecio.Text = ((int)articulo.Precio).ToString();
                        imgArticulo.ImageUrl = (articulo.ImagenUrl).ToString();
                        lblCategoria.Text = articulo.Categoria.ToString();
                        lblMarca.Text = articulo.Marca.ToString();
                    }
                    else
                    {
                        Session.Add("Error", "Articulo no encontrado");
                        Response.Redirect("Error.aspx", false);
                    }

                }
                catch (Exception ex)
                {
                    Session.Add("Error", ex.Message);
                    Response.Redirect("Error.aspx");

                }
            }
            else
            {
                Session.Add("Error", "No se ha proporcionado un código de artículo.");
                Response.Redirect("Error.aspx", false);

            }
        }
	}
}