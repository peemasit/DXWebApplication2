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
    public partial class EditVehicle : System.Web.UI.Page
    {
        string conStr = WebConfigurationManager.ConnectionStrings["VehicleDatabaseConnectionString1"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                SqlConnection conn = new SqlConnection(conStr);
                string query = "select * from tblVehicle where vehId = @id";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                string id = Request.QueryString["id"];
                sqlCommand.Parameters.AddWithValue("@id", id);
                DataTable CustomerTable = new DataTable();
                sqlDataAdapter.Fill(CustomerTable);
                foreach (DataRow dr in CustomerTable.Rows)
                {
                    idTxt.Text = dr["vehId"].ToString();
                    subtitleTxt.Text = dr["vehSubtitle"].ToString();
                    remarkTxt.Text = dr["vehRemark"].ToString();
                    imageTxt.Text = dr["vehImage"].ToString();
                    fileTxt.Text = dr["vehFile"].ToString();
                    DropDownList1.SelectedValue = dr["vetSubtitle"].ToString();
                }
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                string query = "update tblVehicle set vehSubtitle=@vehSubtitle, vehImage=@vehImage, vehRemark=@vehRemark, vehFile=@vehFile,  vetSubtitle=@vetSubtitle  where vehId=@vehId";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@vehId", idTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vehSubtitle", subtitleTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vehImage", imageTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vehRemark", remarkTxt.Text);
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