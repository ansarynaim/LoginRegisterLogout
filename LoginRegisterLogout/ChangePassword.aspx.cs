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
    public partial class ChangePassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=ANSAAR\\SQLEXPRESS;initial catalog=dbproject;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null && Session["ID"].ToString() != "")
            {
                if (!IsPostBack)
                {
                    // page load code to written 
                }
            }

            else
            {
                Response.Redirect("Logout.aspx");
            }
        }

        protected void btnchangepassword_Click(object sender, EventArgs e)
        {
            if(txtnewpassword.Text==txtconfirmnewpassword.Text)
            { 
            con.Open();
            SqlCommand cmd = new SqlCommand("update tblregistration set rpassword='"+txtnewpassword.Text+"' where rid='" + Session["ID"] +"' and rpassword='"+txtoldpassword.Text+"'", con);
            int i=cmd.ExecuteNonQuery();
            con.Close();
                if(i== 0)
                {
                    lblmsg.Text = "Password has not been changed Successfully!!";
                }

                else
                {
                    lblmsg.Text = "Password has been changed Successfully!!";
                }
          
            }
            else
            {
                lblmsg.Text = "Password do not match!!";
            }
        }
    }
}