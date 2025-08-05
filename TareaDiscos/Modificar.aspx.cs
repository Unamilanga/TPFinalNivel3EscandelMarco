using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TareaDiscos
{
    public partial class Modificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();
            }

        }

        private void CargarGrilla()
        {
            Catalogo catalogo = new Catalogo();
            GvArticulos.DataSource = catalogo.ListaSp();
            GvArticulos.DataBind();
        }


        protected void GvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvArticulos.PageIndex = e.NewPageIndex;
            CargarGrilla();
            
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Detalle.aspx");
        }

        protected void GvArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Catalogo catalogo = new Catalogo();
                Articulo articulo = new Articulo();
                if (e.CommandName == "Editar")
                {
                    string Codigo = (e.CommandArgument.ToString());
                    Response.Redirect("Detalle.aspx?Codigo=" + Codigo);
                }
                if (e.CommandName == "Borrar")
                {
                    string Codigo = (e.CommandArgument.ToString());
                    articulo = catalogo.FiltroCodigo(Codigo);
                    catalogo.EliminarSp(articulo.Id);

                    CargarGrilla();
                }

            }
            catch (Exception ex)
            {
                Response.Write("<h3>Error: " + ex.Message + "</h3>");
                Response.Write("<h3>DEBUG: Error al seleccionar el artículo.</h3>");

            }
        }

        protected void TxtBuscador_TextChanged(object sender, EventArgs e)
        {
            Catalogo buscador = new Catalogo();
            try
            {
                if (txtBuscador.Text.Length > 2)
                {

                    var filtrobuscado = buscador.ListaSp()
                                                    .Where(x => x.Nombre.ToUpper().Contains(txtBuscador.Text.ToUpper()) ||
                                                                x.Codigo.ToUpper().Contains(txtBuscador.Text.ToUpper()) ||
                                                                x.Marca.Nombre.ToUpper().Contains(txtBuscador.Text.ToUpper()))
                                                    .ToList();

                    GvArticulos.DataSource = filtrobuscado;
                    GvArticulos.DataBind();

                }
                if (txtBuscador.Text == "" || txtBuscador.Text.Length == 1)
                {
                    GvArticulos.DataSource = buscador.ListaSp();
                    GvArticulos.DataBind();

                }

                
            }catch (Exception ex)
            {

                Session.Add("Error", ex.Message);
                Response.Redirect("Error.aspx" + ex.Message, false);

            }

        }


    }
}