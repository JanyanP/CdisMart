using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CdisMart_BLL;
using CdisMart_DAL;
using System.Data;

namespace CdisMart
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (usuarioValido())
            {
                Response.Redirect("~/Subastas/Lista_de_subasta.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Sesion", "alert('Usuario y/o contraseña incorrectos.')", true);
            }
        }


        public bool usuarioValido()
        {
            bool acceso = false;

            UserBLL user = new UserBLL();
            Users usuario1 = new Users();

            usuario1=user.consultarUser(txtUsuario.Text);
            string contraseña = txtContraseña.Text;

            if (usuario1!=null)
            {
                if (usuario1.Password == contraseña)
                {
                    Session["Usuario"] = usuario1;
                    Session["Nombre"] = usuario1.Name;
                    Session["ID"] = usuario1.UserId;
                    Session["UserName"] = usuario1.UserName;
                    acceso = true;
                }

            }
            return acceso;

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registro.aspx");
        }
    }
}