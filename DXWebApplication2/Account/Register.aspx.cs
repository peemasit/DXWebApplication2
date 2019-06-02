using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using DXWebApplication2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace DXWebApplication2 {
    public partial class Register : System.Web.UI.Page {
        
        protected void Page_Load(object sender, EventArgs e) {
            
        }

        protected void btnCreateUser_Click(object sender, EventArgs e) {
            string conStr = WebConfigurationManager.ConnectionStrings["VehicleDatabaseConnectionString1"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            if (tbUserName.Text == "" || tbEmail.Text == "" || tbPassword.Text == "" || tbConfirmPassword.Text == "" && tbPassword.Text == tbConfirmPassword.Text)
            {

            }
            else
            {
                string query = "insert into AccountDB values (@username, @password, @email)";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.Parameters.AddWithValue("@username", tbUserName.Text);
                sqlCommand.Parameters.AddWithValue("@password", tbPassword.Text);
                sqlCommand.Parameters.AddWithValue("@email", tbEmail.Text);
                sqlCommand.ExecuteScalar();
                conn.Close();
                Response.Redirect("Login.aspx");
            }

            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            //var user = new ApplicationUser() { UserName = tbUserName.Text, Email = tbEmail.Text };
            //IdentityResult result = manager.Create(user, tbPassword.Text);
            //if (result.Succeeded)
            //{
            //    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            //    //string code = manager.GenerateEmailConfirmationToken(user.Id);
            //    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
            //    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

            //    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //}
            //else
            //{
            //    ErrorMessage.Text = result.Errors.FirstOrDefault();
            //}
        }
    }
}