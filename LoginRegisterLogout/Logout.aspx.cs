using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace LoginRegisterLogout
{
    public partial class Logout : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=ANSAAR\\SQLEXPRESS;initial catalog=dbproject;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("LoginForm.aspx");
        }
    }
}