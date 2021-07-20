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
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                userName.Text = Session["UserName"].ToString();
                user.Text = Session["UserName"].ToString();
            }
            

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@UserName";
            parameter.Value = Session["UserName"].ToString();

            SetData("spGetUserDetails", parameter);

        }

        private void SetData(string SPName, SqlParameter SPParameter)
        {
            string cs;
            object result = "";
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
                    firstName.Text = reader.GetValue(0).ToString();
                    lastName.Text= reader.GetValue(1).ToString();
                    email.Text= reader.GetValue(4).ToString();
                    gender.Text= reader.GetValue(5).ToString();
                    dateOfBirth.Text= reader.GetValue(6).ToString();
                    country.Text= reader.GetValue(7).ToString();
                    state.Text= reader.GetValue(8).ToString();
                    phone.Text= reader.GetValue(9).ToString();
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            con.Close();
        }
    }
}