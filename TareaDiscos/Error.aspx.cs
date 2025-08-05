using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TareaDiscos
{
	public partial class Error : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(Session["Error"] != null)
            {
                LblErrores.Text = Session["Error"].ToString();
                Session.Remove("Error");
            }
            else
            {
                LblErrores.Text = "Ha ocurrido un error inesperado.";
            }
        }
	}
}