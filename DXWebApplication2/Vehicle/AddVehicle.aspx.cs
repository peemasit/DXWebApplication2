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
        string conStr = WebConfigurationManager.ConnectionStrings["VehicleDatabaseConnectionString1"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (id != null && !IsPostBack)
            {
                SqlConnection conn = new SqlConnection(conStr);
                string query = "select * from tblVehicle where vehId = @id";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlCommand.Parameters.AddWithValue("@id", id);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {
                    codeTxt.Text = dr["vehCode"].ToString();
                    subtitleTxt.Text = dr["vehSubtitle"].ToString();
                    remarkTxt.Text = dr["vehRemark"].ToString();
                    imageTxt.Text = dr["vehImage"].ToString();
                    fileTxt.Text = dr["vehFile"].ToString();
                    DropDownList1.SelectedValue = dr["vetId"].ToString();
                }
            }
        }

        protected void addVehicle_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                string query = "insert into tblVehicle (vehCode, vehSubtitle,vehRemark,vehImage,vehFile,vetId,vehActive) values (@Code, @Subtitle, @Remark, @Image, @File, @FkId, 1)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@Code", codeTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Subtitle", subtitleTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Remark", remarkTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Image", imageTxt.Text);
                sqlCommand.Parameters.AddWithValue("@File", fileTxt.Text);
                sqlCommand.Parameters.AddWithValue("@FkId", DropDownList1.SelectedValue);
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