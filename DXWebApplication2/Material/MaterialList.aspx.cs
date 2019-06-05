

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DXWebApplication2
{
    public partial class MaterialList : System.Web.UI.Page
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
            string query = "SELECT* FROM tblMaterial where matActive = 1";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            gvVehicle.DataSource = rd;
            gvVehicle.DataBind();
        }

        protected void createBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddMaterial.aspx");
        }
        protected void editBtn_Click1(object sender, EventArgs e)
        {
            var editBtn = (Button)sender;
            var row = (GridViewRow)editBtn.NamingContainer;
            string id = row.Cells[0].Text;
            Response.Redirect("EditMaterial.aspx?id=" + id);
        }
        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            var editBtn = (Button)sender;
            var row = (GridViewRow)editBtn.NamingContainer;
            string id = row.Cells[0].Text;
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            string query = "update tblMaterial set matActive = 0 where matId=@Id";
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
            Response.Redirect("AddMaterial.aspx?id=" + id);
        }

        //protected void gvVehicle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    Label l1 = gvVehicle.Rows[e.RowIndex].FindControl("idLbl") as Label;
        //    string conStr = WebConfigurationManager.ConnectionStrings["VehicleDatabaseConnectionString1"].ConnectionString;
        //    SqlConnection conn = new SqlConnection(conStr);
        //    conn.Open();
        //    string query = "delete from tblMaterial where matId=@Id";
        //    SqlCommand cmd = new SqlCommand(query,conn);
        //    cmd.Parameters.AddWithValue("@Id", l1.Text);
        //    cmd.ExecuteNonQuery();
        //    bindData();
        //}
    }
}