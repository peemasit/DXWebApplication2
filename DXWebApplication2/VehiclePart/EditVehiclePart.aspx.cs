using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DXWebApplication2.VehiclePart
{
    public partial class EditVehiclePart : System.Web.UI.Page
    {
        string conStr = WebConfigurationManager.ConnectionStrings["VehicleDatabaseConnectionString1"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
                SqlConnection conn = new SqlConnection(conStr);
                string query = "select * from tblVehiclePart where vepId = @id";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                string id = Request.QueryString["id"];
                sqlCommand.Parameters.AddWithValue("@id", id);
                DataTable CustomerTable = new DataTable();
                sqlDataAdapter.Fill(CustomerTable);
                foreach (DataRow dr in CustomerTable.Rows)
                {
                    idTxt.Text = dr["vepId"].ToString();
                    codeTxt.Text = dr["vepCode"].ToString();
                    subtitleTxt.Text = dr["vepSubtitle"].ToString();
                    remarkTxt.Text = dr["vepRemark"].ToString();
                    imageTxt.Text = dr["vepImage"].ToString();
                    fileTxt.Text = dr["vepFile"].ToString();
                }
            }
        }
        private void bindData()
        {
            try
            {
                SqlConnection conn = new SqlConnection(conStr);
                string id = Request.QueryString["id"];
                conn.Open();
                string query = "SELECT* FROM vw_DeVehiclePart where vepId=@id and deVepActive = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader rd = cmd.ExecuteReader();
                gvDetail.DataSource = rd;
                gvDetail.DataBind();
            }
            catch (Exception)
            {
                
            }
            
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                string query = "update tblVehiclePart set vepSubtitle=@Subtitle, vepImage=@Image, vepRemark=@Remark, vepFile=@File,  vehId=@FKId  where vepId=@Id";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@Id", idTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Subtitle", subtitleTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Image", imageTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Remark", remarkTxt.Text);
                sqlCommand.Parameters.AddWithValue("@File", fileTxt.Text);
                //sqlCommand.Parameters.AddWithValue("@FKId", DropDownList1.SelectedValue);
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