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
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {
                    idTxt.Text = dr["vehId"].ToString();
                    codeTxt.Text = dr["vehCode"].ToString();
                    subtitleTxt.Text = dr["vehSubtitle"].ToString();
                    remarkTxt.Text = dr["vehRemark"].ToString();
                    imageTxt.Text = dr["vehImage"].ToString();
                    fileTxt.Text = dr["vehFile"].ToString();
                    DropDownList1.SelectedValue = dr["vetId"].ToString();
                }
            }
        }
        private void bindData()
        {
            SqlConnection conn = new SqlConnection(conStr);
            string id = Request.QueryString["id"];
            conn.Open();
            string query = "SELECT* FROM vw_DeVehiclePart where vepId=@id and deVepActive = 1";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader rd = cmd.ExecuteReader();
            //gvDetail.DataSource = rd;
            //gvDetail.DataBind();
        }
        protected void updateBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                string query = "update tblVehicle set vehCode=@vehCode, vehSubtitle=@vehSubtitle, vehImage=@vehImage, vehRemark=@vehRemark, vehFile=@vehFile,  vetId=@vetId  where vehId=@vehId";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@vehId", idTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vehCode", codeTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vehSubtitle", subtitleTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vehImage", imageTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vehRemark", remarkTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vehFile", fileTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vetId", DropDownList1.SelectedValue);
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