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
    public partial class AddVehiclePart : System.Web.UI.Page
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
                string query = "insert into tblVehiclePart values (@vepId, @vepSubtitle, @vepImage, @vepRemark, @vepFile, @vehId)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@vepId", idTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vepSubtitle", subtitleTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vepRemark", remarkTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vepImage", imageTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vepFile", fileTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vehId", DropDownList1.SelectedItem.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
                Response.Redirect("VehiclePartList.aspx");
            }
        }
    }
}