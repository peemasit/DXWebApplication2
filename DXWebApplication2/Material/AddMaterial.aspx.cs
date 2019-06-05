
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
    public partial class AddMaterial : System.Web.UI.Page
    {
        string conStr = WebConfigurationManager.ConnectionStrings["VehicleDatabaseConnectionString1"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (id != null && !IsPostBack)
            {
                SqlConnection conn = new SqlConnection(conStr);
                string query = "select * from tblMaterial where matId = @id";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlCommand.Parameters.AddWithValue("@id", id);
                DataTable CustomerTable = new DataTable();
                sqlDataAdapter.Fill(CustomerTable);
                foreach (DataRow dr in CustomerTable.Rows)
                {
                    codeTxt.Text = dr["matCode"].ToString();
                    subtitleTxt.Text = dr["matSubtitle"].ToString();
                    remarkTxt.Text = dr["matRemark"].ToString();
                    imageTxt.Text = dr["matImage"].ToString();
                    fileTxt.Text = dr["matFile"].ToString();
                    priceTxt.Text = dr["matPrice"].ToString();
                }
            }
        }
        protected void addVehicle_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(conStr);
            try
            {
                string query = "insert into tblMaterial (matCode, matSubtitle, matRemark, matImage, matFile, matPrice, matActive) values (@Code, @Subtitle, @Remark, @Image, @File, @Price, 1)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@Code", codeTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Subtitle", subtitleTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Remark", remarkTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Image", imageTxt.Text);
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