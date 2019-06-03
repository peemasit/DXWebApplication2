using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DXWebApplication2
{
    public partial class AddCompositionPart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void addBtn_Click(object sender, EventArgs e)
        {
            string conStr = WebConfigurationManager.ConnectionStrings["VehicleDatabaseConnectionString1"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                string query = "insert into tblCompositionPart values (@copId, @copSubtitle, @copImage, @copRemark, @copFile, @vepId)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@copId", idTxt.Text);
                sqlCommand.Parameters.AddWithValue("@copSubtitle", subtitleTxt.Text);
                sqlCommand.Parameters.AddWithValue("@copRemark", remarkTxt.Text);
                sqlCommand.Parameters.AddWithValue("@copImage", imageTxt.Text);
                sqlCommand.Parameters.AddWithValue("@copFile", fileTxt.Text);
                sqlCommand.Parameters.AddWithValue("@vepId", DropDownList1.SelectedItem.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
                Response.Redirect("CompositionPartList.aspx");
            }
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompositionPartList.aspx");
        }
    }
}