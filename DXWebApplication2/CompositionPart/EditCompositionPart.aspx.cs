using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DXWebApplication2.CompositionPart
{
    public partial class EditCompositionPart : System.Web.UI.Page
    {
        string conStr = WebConfigurationManager.ConnectionStrings["VehicleDatabaseConnectionString1"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                SqlConnection conn = new SqlConnection(conStr);
                string query = "select * from tblCompositionPart where copId = @id";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                string id = Request.QueryString["id"];
                sqlCommand.Parameters.AddWithValue("@id", id);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow dr in dataTable.Rows)
                {
                    idTxt.Text = dr["copId"].ToString();
                    codeTxt.Text = dr["copCode"].ToString();
                    subtitleTxt.Text = dr["copSubtitle"].ToString();
                    remarkTxt.Text = dr["copRemark"].ToString();
                    imageTxt.Text = dr["copImage"].ToString();
                    fileTxt.Text = dr["copFile"].ToString();
                    DropDownList1.SelectedValue = dr["vepId"].ToString();
                }
            }
        }

        protected void editBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                string query = "update tblCompositionPart set copCode=@Code, copSubtitle=@Subtitle, copImage=@Image, copRemark=@Remark, copFile=@File,  vepId=@FKId  where copId=@Id";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@Id", idTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Code", codeTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Subtitle", subtitleTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Image", imageTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Remark", remarkTxt.Text);
                sqlCommand.Parameters.AddWithValue("@File", fileTxt.Text);
                sqlCommand.Parameters.AddWithValue("@FKId", DropDownList1.SelectedValue);
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