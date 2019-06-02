using DXWebApplication2.Controller;
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
    public partial class MaterialList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }
        }
        void bindData()
        {
            gvVehicle.DataSource = getDataList();
            gvVehicle.DataBind();
        }
        public DataSet getDataList()
        {
            string conStr = WebConfigurationManager.ConnectionStrings["VehicleDatabaseConnectionString1"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            DataSet ds = new DataSet();
            string query = "SELECT* FROM tblMaterial";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(ds);
            return ds;
        }

        protected void createBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddMaterial.aspx");
        }

        protected void editBtn_Click(object sender, EventArgs e)
        {

        }
        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var deleteBtn = (Button)sender;
                var row = (GridViewRow)deleteBtn.NamingContainer;
                //var img = (Image)row.FindControl("img");
                //string pathImg = Server.MapPath("~") + img.ImageUrl;
                //if (File.Exists(pathImg))
                //{
                //    File.Delete(pathImg);
                //}
                string id = row.Cells[0].Text;
                delete(id);
                bindData();
                showAlertSuccess("alertDelSuccess", "Delete success");
            }
            catch (SqlException sqlEx)
            {
                showAlertError("alertSqlErr", sqlEx.Message);
            }
            catch (Exception ex)
            {
                showAlertError("alertErr", ex.Message);
            }
        }
        public void delete(string id)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["VehicleDatabaseConnectionString1"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            string cmdText = "DELETE FROM tblMaterial WHERE matId = " + id;
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
    }
}