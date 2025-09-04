using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using FavoritosNegocio;

namespace TareaDiscos
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListArticulos { get; set; }

        public Articulo Artdetallado { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            Catalogo catalogos = new Catalogo();
            ListArticulos = catalogos.ListaSp();

            if (!IsPostBack)
            {

                cblCategorias.DataSource = catalogos.ObtenerCategorias();
                cblCategorias.DataTextField = "Nombre";
                cblCategorias.DataValueField = "Id";
                cblCategorias.DataBind();
                cblMarcas.DataSource = catalogos.ObtenerMarcas();
                cblMarcas.DataTextField = "Nombre";
                cblMarcas.DataValueField = "Id";
                cblMarcas.DataBind();
                RepetidorArticulos.DataSource = ListArticulos;
                RepetidorArticulos.DataBind();


            }
        }

        protected void BtnDetalle_Click(object sender, EventArgs e)
        {
            string valor = ((LinkButton)sender).CommandArgument;
            Response.Redirect("DescArticulo.aspx?Codigo=" + valor);

        }



        protected void TxtBuscador_TextChanged(object sender, EventArgs e)
        {
            Catalogo buscador = new Catalogo();
            try
            {
                if (TxtBuscador.Text.Length > 1)
                {
                    List<string> Filcategorias = new List<string>();
                    List<string> Filmarcas = new List<string>();
                    Catalogo filtrocat = new Catalogo();
                    try
                    {
                        foreach (ListItem i in cblCategorias.Items)
                        {
                            if (i.Selected)
                            {
                                Filcategorias.Add(i.Text.ToString());
                            }
                        }
                        foreach (ListItem i in cblMarcas.Items)
                        {
                            if (i.Selected)
                            {
                                Filmarcas.Add(i.Text.ToString());
                            }
                        }

                        var filtrobuscado = filtrocat.FiltroMultiple(Filmarcas, Filcategorias)
                                                        .Where(x => x.Nombre.ToUpper().Contains(TxtBuscador.Text.ToUpper()) ||
                                                                    x.Codigo.ToUpper().Contains(TxtBuscador.Text.ToUpper()) ||
                                                                    x.Marca.Nombre.ToUpper().Contains(TxtBuscador.Text.ToUpper()))
                                                        .ToList();

                        RepetidorArticulos.DataSource = filtrobuscado;
                        RepetidorArticulos.DataBind();


                        if (TxtBuscador.Text == "" || TxtBuscador.Text.Length == 1)
                        {
                            RepetidorArticulos.DataSource = buscador.Lista();
                            RepetidorArticulos.DataBind();

                        }

                    }
                    catch (Exception ex)
                    {
                        Session.Add("Error", ex.Message);
                        Response.Redirect("Error.aspx" + ex.Message, false);
                    }


                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                // Puedes registrar el error o mostrar un mensaje al usuario
                Console.WriteLine("Error: " + ex.Message);

            }
            finally
            {
                RepetidorArticulos.DataBind();



            }
        }

        protected void btfiltro_Click(object sender, EventArgs e)
        {
            List<string> Filcategorias = new List<string>();
            List<string> Filmarcas = new List<string>();
            Catalogo filtrocat = new Catalogo();
            try
            {
                foreach (ListItem i in cblCategorias.Items)
                {
                    if (i.Selected)
                    {
                        Filcategorias.Add(i.Text.ToString());
                    }
                }
                foreach (ListItem i in cblMarcas.Items)
                {
                    if (i.Selected)
                    {
                        Filmarcas.Add(i.Text.ToString());
                    }
                }
                RepetidorArticulos.DataSource = filtrocat.FiltroMultiple(Filmarcas, Filcategorias);
                RepetidorArticulos.DataBind();



            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.Message);
                Response.Redirect("Error.aspx" + ex.Message, false);
            }


        }


        protected void btcancela_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void LbAgregarFav_Click(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                int IdArticulo = int.Parse(((LinkButton)sender).CommandArgument);
                Usuario usuario = (Usuario)Session["Usuario"];
                Favorito favoritos = new Favorito();

                int resultado = 0; 
                int Existe = favoritos.AgregarFavorito(usuario.Id, IdArticulo, resultado); 


            }

        }
    }
}