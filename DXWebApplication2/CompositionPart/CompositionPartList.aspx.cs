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
    public partial class CompositionPartList : System.Web.UI.Page
    {
        string conStr = WebConfigurationManager.ConnectionStrings["VehicleDatabaseConnectionString1"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }
        }
        private void bindData()
        {
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            string query = "SELECT* FROM tblCompositionPart";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            gvVehicle.DataSource = rd;
            gvVehicle.DataBind();
        }
        protected void createBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCompositionPart.aspx");
        }

        protected void editBtn_Click(object sender, EventArgs e)
        {
            var editBtn = (Button)sender;
            var row = (GridViewRow)editBtn.NamingContainer;
            string id = row.Cells[0].Text;
            Response.Redirect("EditCompositionPart.aspx?id=" + id);
        }
        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            var editBtn = (Button)sender;
            var row = (GridViewRow)editBtn.NamingContainer;
            string id = row.Cells[0].Text;
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            string query = "delete from tblCompositionPart where copId=@Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            bindData();
        }
    }
}