using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DXWebApplication2
{
    public partial class AddVehicle : System.Web.UI.Page
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
                string query = "insert into tblVehicle values (@vehId, @vehSubtitle, @vehRemark, @vehImage, @vehFile, @vetSubtitle)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@vehId", idTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vehSubtitle", subtitleTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vehRemark", remarkTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vehImage", imageTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vehFile", fileTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vetSubtitle", DropDownList1.SelectedItem.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
                Response.Redirect("VehicleList.aspx");
            }
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("VehicleList.aspx");
        }
    }
}