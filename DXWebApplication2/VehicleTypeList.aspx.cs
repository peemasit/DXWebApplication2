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
    public partial class VehicleTypeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindingData();
            }
        }

        void bindingData()
        {
            gvVehicleType.DataSource = getDataList();
            gvVehicleType.DataBind();
        }
        public DataSet getDataList()
        {
            string conStr = WebConfigurationManager.ConnectionStrings["VehicleDatabaseConnectionString1"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            DataSet ds = new DataSet();
            string query = "SELECT* FROM tblVehicleType";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(ds);
            return ds;
        }

        protected void createBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddVehicleType.aspx");
        }

        protected void editBtn_Click(object sender, EventArgs e)
        {

        }
        protected void deleteBtn_Click(object sender, EventArgs e)
        {

        }
    }
}