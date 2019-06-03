using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DXWebApplication2.Material
{
    public partial class EditMaterial : System.Web.UI.Page
    {
        string conStr = WebConfigurationManager.ConnectionStrings["VehicleDatabaseConnectionString1"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                SqlConnection conn = new SqlConnection(conStr);
                string query = "select * from tblMaterial where matId = @id";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                string id = Request.QueryString["id"];
                sqlCommand.Parameters.AddWithValue("@id", id);
                DataTable CustomerTable = new DataTable();
                sqlDataAdapter.Fill(CustomerTable);
                foreach (DataRow dr in CustomerTable.Rows)
                {
                    idTxt.Text = dr["matId"].ToString();
                    subtitleTxt.Text = dr["matSubtitle"].ToString();
                    remarkTxt.Text = dr["matRemark"].ToString();
                    imageTxt.Text = dr["matImage"].ToString();
                    fileTxt.Text = dr["matFile"].ToString();
                    priceTxt.Text = dr["matPrice"].ToString();
                }
            }
        }

        protected void editBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                string query = "update tblMaterial set matSubtitle=@Subtitle, matImage=@Image, matRemark=@Remark, matFile=@File,  matPrice=@Price  where matId=@Id";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@Id", idTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Subtitle", subtitleTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Image", imageTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Remark", remarkTxt.Text);
                sqlCommand.Parameters.AddWithValue("@File", fileTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Price", priceTxt.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
                Response.Redirect("MaterialList.aspx");
            }
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("MaterialList.aspx");

        }
    }
}