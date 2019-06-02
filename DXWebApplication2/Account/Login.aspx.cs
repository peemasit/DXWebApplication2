using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace DXWebApplication2 {
    public partial class Login : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e) {
            string conStr = WebConfigurationManager.ConnectionStrings["VehicleDatabaseConnectionString1"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            string query = "select * from AccountDB where username = @username and password = @password";
            SqlCommand sqlCommand = new SqlCommand(query, conn);
            conn.Open();
            sqlCommand.Parameters.AddWithValue("@username", tbUserName.Text);
            sqlCommand.Parameters.AddWithValue("@password", tbPassword.Text);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                Response.Write("Your username or password incorrectly, Please check and try again.");
                Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn.aspx?ReturnUrl={0}&RememberMe={1}",
                Request.QueryString["ReturnUrl"],
                false),
                true);
            }
            conn.Close();

            //if (IsValid)
            //{
            //    // Validate the user password
            //    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //    var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            //    // This doen't count login failures towards account lockout
            //    // To enable password failures to trigger lockout, change to shouldLockout: true
            //    var result = signinManager.PasswordSignIn(tbUserName.Text, tbPassword.Text, isPersistent: false, shouldLockout: false);

            //    switch (result)
            //    {
            //        case SignInStatus.Success:
            //            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //            break;
            //        case SignInStatus.LockedOut:
            //            Response.Redirect("~/Account/Lockout.aspx");
            //            break;
            //        case SignInStatus.RequiresVerification:
            //            Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn.aspx?ReturnUrl={0}&RememberMe={1}",
            //                                            Request.QueryString["ReturnUrl"],
            //                                            false),
            //                              true);
            //            break;
            //        case SignInStatus.Failure:
            //        default:
            //            tbUserName.ErrorText = "Invalid user";
            //            tbUserName.IsValid = false;
            //            break;
            //    }
            //}
        }
    }
}