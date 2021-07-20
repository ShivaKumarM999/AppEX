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
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //spGetAllUserDetails
            userGridView.DataSource = GetData();
            userGridView.DataBind();
        }

        private DataSet GetData()
        {
            string cs;
            cs = @"server=(localdb)\MSSQLLocalDB;database=POC;integrated security=SSPI";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("spGetAllUserDetails", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet DS = new DataSet();
            da.Fill(DS);
            return DS;
        }
    }
}