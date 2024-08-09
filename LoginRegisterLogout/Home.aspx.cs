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
    public partial class Home : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=ANSAAR\\SQLEXPRESS;initial catalog=dbproject;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null && Session["ID"].ToString() !="") 
            {
                if (!IsPostBack)
                {
                    GridView();
                }
            }

            else
            {
                Response.Redirect("Logout.aspx");
            }
            
        }

        public void GridView()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblregistration where rid='" + Session["ID"] +"' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvregistration.DataSource = dt;
            gvregistration.DataBind();
            lblname.Text = dt.Rows[0]["rname"].ToString();
        }

    }
}