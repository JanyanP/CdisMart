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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCuenta_Click(object sender, EventArgs e)
        {
            agregarUser();
        }

        public void agregarUser()
        {
            UserBLL usuario = new UserBLL();
            Users user1 = new Users();
            Users user2 = new Users();

            user1.Name = txtNombre.Text;
            user1.Email = txtEmail.Text;
            user1.UserName = txtUsuario.Text;

            string pswrd = txtContraseña.Text;
            string confirm = txtConfirm.Text;

            try
            {
                if (pswrd == confirm)
                {
                    user1.Password = pswrd;
                }
                else
                {
                    throw new Exception("Confirmacion de contraseña no coincide");
                }


                user2 = usuario.consultarUser(txtUsuario.Text);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('" + usuario + "')", true);
                
                if (user2 != null)
                {
                    throw new Exception("El nombre de usuario ya existe");
                }
                else
                {
                    usuario.agregarUser(user1);
                    Response.Redirect("~/Login.aspx");
                }

            }catch(Exception e)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('" + e.Message + "')", true);
            }

        }

    }
}