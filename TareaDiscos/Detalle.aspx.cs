using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TareaDiscos
{
	public partial class Detalle : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Catalogo catalogos = new Catalogo();
			try
			{
                if (!IsPostBack)
                { 
					ddCategoria.DataSource = catalogos.ObtenerCategorias();
					ddCategoria.DataTextField = "Nombre";
					ddCategoria.DataValueField = "Id";
                    ddCategoria.DataBind();
					ddMarca.DataSource = catalogos.ObtenerMarcas();
					ddMarca.DataTextField = "Nombre";
                    ddMarca.DataValueField = "Id";
                    ddMarca.DataBind();
                
                    if (Request.QueryString["Codigo"] != null)
                    {
                    string codigo = (Request.QueryString["Codigo"]).ToString();
                    Articulo articulo = catalogos.FiltroCodigo(codigo);
                    if (articulo != null)
                    {
                        txtCodigo.Text = (articulo.Codigo).ToString();
                        txtNombre.Text = (articulo.Nombre).ToString();
                        txtDescripcion.Text = (articulo.Descripcion).ToString();
                        txtPrecio.Text = ((int)articulo.Precio).ToString();
                        txtUrl.Text = (articulo.ImagenUrl).ToString();
                        ddCategoria.SelectedValue = articulo.Categoria.Id.ToString();
                        ddMarca.SelectedValue = articulo.Marca.Id.ToString();
                        txtCodigo.ReadOnly = true;
                        }
                    else
                    {
                        Session.Add("Error", "Articulo no encontrado");
                        Response.Redirect("Error.aspx");
                    }
                }
                }

            }
			catch(Exception ex) 
			{
				Session.Add("Error", ex.Message);
                Response.Redirect("Error.aspx"+ex.Message);
            }

        }

        protected void BtnAceptarr_Click(object sender, EventArgs e)
        {
            LblErroresCd.Text = "";
            LblErroresNb.Text = "";
            LblErroresDp.Text = "";
            LblErrorUrl.Text = "";
            if (!Page.IsValid) return;



            try
			{
            Articulo a = new Articulo();
			
			a.Codigo = (txtCodigo.Text);
			a.Nombre = (txtNombre.Text);
			a.Descripcion = (txtDescripcion.Text);
			a.Precio = int.Parse((txtPrecio.Text));
			a.ImagenUrl = txtUrl.Text;
			a.Categoria = new Categorias();
            a.Categoria.Id = int.Parse((ddCategoria.SelectedValue));
			a.Marca = new Marcas();
            a.Marca.Id = int.Parse((ddMarca.SelectedValue));
            
            Catalogo catalogos = new Catalogo();
                bool existe = catalogos.ExisteCodigo(a.Codigo.ToString());
                bool Editar = Request.QueryString["Codigo"] != null;

                if ((txtCodigo.Text).Length > 50 || (txtCodigo.Text == "")) { LblErroresCd.Text = "No superior a 50 caracteres, ni vacio"; return; }
                if ((txtNombre.Text).Length > 50) { LblErroresNb.Text = "No superior a 50 caracteres, ni vacio"; return; }
                if ((txtDescripcion.Text).Length > 150) { LblErroresDp.Text = "No superior a 250 caracteres, ni vacio"; return; }
                if ((txtUrl.Text).Length > 1000) { LblErrorUrl.Text = "No superior a 250 caracteres, ni vacio"; return; }

                if (Editar)
                {
                    var original = catalogos.FiltroCodigo(a.Codigo);
                    a.Id = original.Id;

                    catalogos.ModificarSp(a);
                    Response.Redirect("Modificar.aspx", false);

                }
                else
                {
                    if (existe)
                    {
                        LblErroresCd.Text = "El código de producto ya existe.";
                        return;
                    }
                    else
                    {
                        catalogos.AgregarSp(a);
                        Response.Redirect("Modificar.aspx", false);

                    }
                }



            }
            catch (Exception ex)
			{  Session.Add("Error", ex.Message);
                Response.Redirect("Error.aspx");

            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Modificar.aspx");
        }
    }
}