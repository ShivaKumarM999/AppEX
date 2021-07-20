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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            message.Visible = false;
            ageCheck.Visible = false;

            if (!IsPostBack)
            {
                country.DataSource = GetData("spGetCountry", null);
                country.DataBind();
                ListItem liCountry = new ListItem("-- Select Country --", "-1");
                country.Items.Insert(0, liCountry);

                ListItem liState = new ListItem("-- Select State --", "-1");
                state.Items.Insert(0, liState);

                state.Enabled = false;

                #region connectingToCountry
                //using (SqlConnection con = new SqlConnection(cs))
                //{
                //    SqlCommand cmd = new SqlCommand("Select CountryId, CountryName from Country", con);
                //    con.Open();
                //    SqlDataReader rdr = cmd.ExecuteReader();
                //    country.DataTextField = "CountryName";
                //    country.DataValueField = "CountryId";
                //    country.DataSource = rdr;
                //    country.DataBind();
                //    ListItem liCountry = new ListItem("-- Select Country --", "-1");
                //    country.Items.Insert(0, liCountry);
                //}
                #endregion
            }
        }

        protected void signUp_Click(object sender, EventArgs e)
        {
            string user = "";

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@UserName";
            parameter.Value = userName.Text;

            user = GetSingleValue("spCheckUserExists", parameter);

            if (user == "")
            {
                int success = InsertData("InsertUser");
                Response.Redirect("SignIn.aspx");
            }
            else
            {
                message.Visible = true;
                message.Text = user + ", User already exists, Please enter new User Name";
            }
        }

        protected void country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (country.SelectedValue == "-1")
            {
                state.SelectedIndex = 0;
                state.Enabled = false;
            }
            else
            {
                state.Enabled = true;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@CountryId";
                parameter.Value = country.SelectedValue;

                state.DataSource = GetData("spGetStateByCountryId", parameter);
                state.DataBind();

                ListItem liCountry = new ListItem("-- Select State --", "-1");
                state.Items.Insert(0, liCountry);

                getPhoneCode();
            }
        }

        protected void dateOfBirth_TextChanged(object sender, EventArgs e)
        {
            string selected;
            string[] getYear;
            int year;
            string date;
            int age;

            selected = dateOfBirth.Text;
            getYear = selected.Split('-');
            year = Convert.ToInt32(getYear[0]);
            date = DateTime.Now.ToString("yyyy");
            age = Convert.ToInt32(date) - year;

            if (age < 19)
            {
                dateOfBirth.Text = "";
                ageCheck.Visible = true;
                ageCheck.Text = "Age should minimum 18";
            }
        }

        private DataSet GetData(string SPName, SqlParameter SPParameter)
        {
            string cs;
            cs = @"server=(localdb)\MSSQLLocalDB;database=POC;integrated security=SSPI";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(SPName, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (SPParameter != null)
            {
                da.SelectCommand.Parameters.Add(SPParameter);
            }
            DataSet DS = new DataSet();
            da.Fill(DS);
            return DS;
        }

        private string GetSingleValue(string SPName, SqlParameter SPParameter)
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
            while (reader.Read())
            {
                result = reader[0].ToString();
            }
            con.Close();
            return result;
        }

        private int InsertData(string SPName)
        {
            string cs;
            int result;
            cs = @"server=(localdb)\MSSQLLocalDB;database=POC;integrated security=SSPI";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(SPName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            // add parameters and their values
            cmd.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar, 50).Value = firstName.Text;
            cmd.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar, 50).Value = lastName.Text;
            cmd.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar, 50).Value = userName.Text;
            cmd.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = Enrypt(password.Text);
            cmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 50).Value = email.Text;
            cmd.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar, 50).Value = phone.Text;
            cmd.Parameters.Add("@Gender", System.Data.SqlDbType.VarChar, 15).Value = gender.SelectedValue;
            cmd.Parameters.Add("@DateOfBirth", System.Data.SqlDbType.Date).Value = dateOfBirth.Text;
            cmd.Parameters.Add("@CountryId", System.Data.SqlDbType.Int).Value = country.SelectedValue;
            cmd.Parameters.Add("@StateId", System.Data.SqlDbType.Int).Value = state.SelectedValue;

            // open connection, execute command and close connection
            con.Open();
            result = cmd.ExecuteNonQuery();
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

        public string Enrypt(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        private void getPhoneCode()
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@CountryId";
            parameter.Value = country.SelectedValue;

            phone.Text = GetSingleValue("spGetPhoneCodeByCountryId", parameter);
        }
    }
}