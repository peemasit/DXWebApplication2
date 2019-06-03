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
    public partial class EditVehicleType : System.Web.UI.Page
    {
        string conStr = WebConfigurationManager.ConnectionStrings["VehicleDatabaseConnectionString1"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(conStr);
                string query = "select * from tblVehicleType where vetSubtitle = @sub";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                string id = Request.QueryString["sub"];
                sqlCommand.Parameters.AddWithValue("@sub", id);
                DataTable CustomerTable = new DataTable();
                sqlDataAdapter.Fill(CustomerTable);
                foreach (DataRow dr in CustomerTable.Rows)
                {
                    subtitleTxt.Text = dr["vetSubtitle"].ToString();
                    remarkTxt.Text = dr["vetRemark"].ToString();
                    imageTxt.Text = dr["vetImage"].ToString();
                }
            }
            
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                string query = "update tblVehicleType set vetImage=@vetImage, vetRemark=@vetRemark where vetSubtitle=@vetSubtitle";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@vetSubtitle", subtitleTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vetImage", imageTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vetRemark", remarkTxt.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
                Response.Redirect("VehicleTypeList.aspx");
            }
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("VehicleTypeList.aspx");
        }
    }
}