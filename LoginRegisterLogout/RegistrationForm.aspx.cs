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
    public partial class RegistrationForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=ANSAAR\\SQLEXPRESS;initial catalog=dbproject;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GridView();
            }
        }

        public void Clear()
        {
            txtname.Text = "";
            txtemail.Text = "";
            txtpassword.Text = "";
            txthobby.Text = "";
        }

        public void GridView()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblregistration  ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            gvregistration.DataSource = dt;
            gvregistration.DataBind();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tblregistration (rname,remail,rpassword,rhobby)values('" + txtname.Text + "','" + txtemail.Text + "','" + txtpassword.Text + "','" + txthobby.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView();
            Clear();


        }
    }
}