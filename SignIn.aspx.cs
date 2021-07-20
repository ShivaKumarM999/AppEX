using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppEx
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            message.Visible = false;
        }

        protected void login_Click(object sender, EventArgs e)
        {
            string pwd = "";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@UserName";
            parameter.Value = userName.Text;

            pwd = GetData("spGetUserDetails", parameter);
            pwd = Decrypt(pwd);
            if (pwd != "")
            {
                if (pwd != password.Text)
                {
                    message.Visible = true;
                    message.Text = "Please enter valid password";
                }
                else
                {
                    Session["UserName"] = userName.Text;
                    Response.Redirect("UserDetails.aspx");
                }
            }

        }

        protected void retrivePassword_Click(object sender, EventArgs e)
        {
            string pwd = "";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@UserName";
            parameter.Value = userName.Text;

            pwd = GetData("spGetUserDetails", parameter);
            pwd = Decrypt(pwd);

            message.Visible = true;
            message.Text = "Your Password is " + pwd;
        }

        private string GetData(string SPName, SqlParameter SPParameter)
        {
            string cs;
            string result = "";
            SqlDataReader reader;
            cs = @"server=(localdb)\MSSQLLocalDB;database=POC;integrated security=SSPI";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(SPName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (SPParameter != null)
            {
                cmd.Parameters.Add(SPParameter);
            }

            con.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = reader.GetString(3);
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            con.Close();
            return result;
        }

        public string Decrypt(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);

            }
            catch (FormatException fe)
            {
                decrypted = fe.Message;
            }
            return decrypted;
        }

        
    }
}