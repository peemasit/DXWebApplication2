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
    public partial class AddVehiclePart : System.Web.UI.Page
    {
        string conStr = WebConfigurationManager.ConnectionStrings["VehicleDatabaseConnectionString1"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (id!=null && !IsPostBack)
            {
                SqlConnection conn = new SqlConnection(conStr);
                string query = "select * from tblVehiclePart where vepId = @id";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlCommand.Parameters.AddWithValue("@id", id);
                DataTable CustomerTable = new DataTable();
                sqlDataAdapter.Fill(CustomerTable);
                foreach (DataRow dr in CustomerTable.Rows)
                {
                    codeTxt.Text = dr["vepCode"].ToString();
                    subtitleTxt.Text = dr["vepSubtitle"].ToString();
                    remarkTxt.Text = dr["vepRemark"].ToString();
                    imageTxt.Text = dr["vepImage"].ToString();
                    fileTxt.Text = dr["vepFile"].ToString();
                    DropDownList1.SelectedValue = dr["vehId"].ToString();
                }
            }
        }
        protected void addVehicle_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                string query = "insert into tblVehiclePart (vepCode, vepSubtitle,vepRemark,vepImage,vepFile,vehId,vepActive) values (@Code, @Subtitle, @Remark, @Image, @File, @FkId, 1)";
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
                Response.Redirect("VehiclePartList.aspx");
            }
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("VehiclePartList.aspx");
        }
    }
}