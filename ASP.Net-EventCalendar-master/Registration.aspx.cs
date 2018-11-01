using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
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
        }
    }

    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        if (Page.IsPostBack)    ///
        {                       /// checks for validation regardless if the user has javascript
            Page.Validate();    /// enabled or not
            if (Page.IsValid)   ///
            {
                // creating a new salt using a method placed in the master page
                String salt = CreateSalt(256);

                // checking to see if the user exists
                if (CheckForUser(txtEmail.Text) == true)
                {
                    this.ShowError("A user with this email already exists, please use another email");
                }
                else if (CheckForUser(txtEmail.Text) == false)
                {
                    // if email doesn't exist, use linq to sql to insert a new user into the database
                    User newUser = new User
                    {
                        // THIS NEEDS CHANGED AFTER SYSTEM IS PUT INTO PLACE!!!!!!!
                        UserID = Convert.ToInt32(txtID.Text),
                        UserEmail = txtEmail.Text,
                        UserPass = PasswordHash(txtPassword.Text, salt),
                        UserSalt = salt
                    };
                    // linq to sql to perform the insert into database
                    using (DBContextDataContext db = new DBContextDataContext())
                    {
                        db.Users.InsertOnSubmit(newUser);

                        db.SubmitChanges();

                        // sets the session id for the new user so they can update their information
                        Session["ID"] = (from x in db.Users where x.UserEmail == txtEmail.Text select x.UserID).FirstOrDefault();
                    }
                    // sending them to the customer page to update their informaition
                    Response.Redirect("~/Customer.aspx");
                }
                else
                {
                    Response.Redirect("~/Register.aspx");   // sent back to registration if failed
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

    // method to generate a random salt for every user who registers
    public static string CreateSalt(int size)
    {
        //Generate a cryptographic random number.
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);

        // Return a Base64 string representation of the random number.
        return Convert.ToBase64String(buff);
    }

    // method to check if user exists in the database
    public bool CheckForUser(string email)
    {
        using (DBContextDataContext db = new DBContextDataContext())
        {
            var qry = (from x in db.Users where x.UserEmail.Equals(email) select x);

            Session["name"] = qry.Count();

            if (qry.Count() != 0)
            {
                return true;
            }
            else
                return false;
        }

    }

    // method to set error message if there is an error that occurs
    void ShowError(string ErrorMessage)
    {
        this.lblErrorMessage.Text = ErrorMessage + "<p>";
    }
}