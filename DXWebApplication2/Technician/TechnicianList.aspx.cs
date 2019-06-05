using DevExpress.Web;
using System;
using System.Collections;
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
    public partial class TechnicianList : System.Web.UI.Page
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
            string query = "SELECT* FROM tblTechnician where tecActive = 1";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            gvVehicle.DataSource = rd;
            gvVehicle.DataBind();
        }
       
        protected void createBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddTechnician.aspx");
        }

        protected void editBtn_Click(object sender, EventArgs e)
        {
            var editBtn = (Button)sender;
            var row = (GridViewRow)editBtn.NamingContainer;
            string id = row.Cells[0].Text;
            Response.Redirect("EditTechnician.aspx?id=" + id);
        }
        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            var editBtn = (Button)sender;
            var row = (GridViewRow)editBtn.NamingContainer;
            string id = row.Cells[0].Text;
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            string query = "update tblTechnician set tecActive = 0 where tecId=@Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            bindData();
        }
        protected void copyBtn_Click(object sender, EventArgs e)
        {
            var editBtn = (Button)sender;
            var row = (GridViewRow)editBtn.NamingContainer;
            string id = row.Cells[0].Text;
            Response.Redirect("AddTechnician.aspx?id=" + id);
        }
        protected void grid_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
           
        }
        protected void grid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            
        }

        
    }
}