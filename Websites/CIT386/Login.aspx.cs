using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Script used to prevent jquery error
        if (!IsPostBack)
        {
            string JQueryVer = "1.7.1";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-" + JQueryVer + ".min.js",
                DebugPath = "~/Scripts/jquery-" + JQueryVer + ".js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            });

            this.DataBind();
        }
    }

    // Button for login action
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        if (Page.IsPostBack)    ///
        {                       /// Ensures validation happens regardless if the user has javascript
            Page.Validate();    /// enabled or not
            if (Page.IsValid)   ///
            {
                // linq to sql that logs the user in
                using (DBContextDataContext db = new DBContextDataContext())
                {
                    // set textbox values to string variables
                    string email = Email.Text;
                    string pass = Password.Text;

                    // Capturing user salt from database
                    var retrivedSalt = (from s in db.Users where (email == s.UserEmail) select s.UserSalt).FirstOrDefault();
                    // Combining password and salt fields to recreate user passoword for verification
                    string unhashedPW = PasswordHash(pass, retrivedSalt.ToString());

                    // if using the email and password provided brings back any records, set the
                    // id, name, and is admin boolean to session variables
                    if (db.Users.Any(u => u.UserEmail == email && u.UserPass == unhashedPW) == true)
                    {
                        Session["id"] = (from x in db.Users where email == x.UserEmail select x.UserID).FirstOrDefault();
                        Session["name"] = (from x in db.Users where email == x.UserEmail select x.UserFirst).FirstOrDefault();
                        Session["isInstructor"] = (from x in db.Users where email == x.UserEmail select x.IsInstructor).FirstOrDefault();
                        this.DataBind();
                        Response.Redirect("~/Customer.aspx");
                    }
                    else
                        Response.Redirect("~/Login.aspx");
                }

            }
        }


    }

    public static string PasswordHash(string pwd, string salt)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(pwd + salt);
        SHA256Managed shaString = new SHA256Managed();
        byte[] hash = shaString.ComputeHash(bytes);
        StringBuilder hex = new StringBuilder(hash.Length * 2);
        foreach (byte b in hash)
            hex.AppendFormat("{0:x2}", b);

        return hex.ToString();
    }
}