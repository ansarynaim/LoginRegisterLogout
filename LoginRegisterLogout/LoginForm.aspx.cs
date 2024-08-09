using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;


namespace LoginRegisterLogout
{
    public partial class LoginForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=ANSAAR\\SQLEXPRESS;initial catalog=dbproject;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblregistration where remail='"+txtemail.Text+"' and rpassword='"+txtpassword.Text+"' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if(dt.Rows.Count == 0 )
            {
                lblmsg.Text = "Login Failed!!";
            }

            else
            {
                Session["ID"]= dt.Rows[0]["rid"];
                Response.Redirect("Home.aspx");
            }
        }
    }
}