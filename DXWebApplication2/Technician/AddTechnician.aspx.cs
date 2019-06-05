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
    public partial class AddTechnician : System.Web.UI.Page
    {
            string conStr = WebConfigurationManager.ConnectionStrings["VehicleDatabaseConnectionString1"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (id != null && !IsPostBack)
            {
                SqlConnection conn = new SqlConnection(conStr);
                string query = "select * from tblTechnician where tecId = @id";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlCommand.Parameters.AddWithValue("@id", id);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {
                    codeTxt.Text = dr["tecCode"].ToString();
                    subtitleTxt.Text = dr["tecSubtitle"].ToString();
                    remarkTxt.Text = dr["tecRemark"].ToString();
                    hourRateTxt.Text = dr["tecHourRate"].ToString();
                }
            }
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                string query = "insert into tblTechnician (tecCode, tecSubtitle, tecHourRate, tecRemark, tecActive) values (@Code, @Subtitle, @HourRate, @Remark,1)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@Code", codeTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Subtitle", subtitleTxt.Text);
                sqlCommand.Parameters.AddWithValue("@HourRate", hourRateTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Remark", remarkTxt.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
                Response.Redirect("TechnicianList.aspx");
            }
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("TechnicianList.aspx");
        }
    }
}