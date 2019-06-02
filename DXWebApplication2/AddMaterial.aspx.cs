using DXWebApplication2.Controller;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DXWebApplication2
{
    public partial class AddMaterial : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void addVehicle_Click(object sender, EventArgs e)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["VehicleDatabaseConnectionString1"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                string query = "insert into tblMaterial values (@matId, @matSubtitle, @matImage, @matRemark, @matFile, @matPrice)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@matId", idTxt.Text);
                sqlCommand.Parameters.AddWithValue("@matSubtitle", subtitleTxt.Text);
                sqlCommand.Parameters.AddWithValue("@matImage", imageTxt.Text);
                sqlCommand.Parameters.AddWithValue("@matRemark", remarkTxt.Text);
                sqlCommand.Parameters.AddWithValue("@matFile", fileTxt.Text);
                sqlCommand.Parameters.AddWithValue("@matPrice", priceTxt.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
                Response.Redirect("MaterialList.aspx");
            }
        }
    }
}