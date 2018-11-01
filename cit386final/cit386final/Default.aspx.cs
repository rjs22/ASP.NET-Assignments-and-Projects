using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cit386final
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            using(DBContextDataContext db = new DBContextDataContext())
            {
                var result = (from x in db.zips where x.zip1 == Convert.ToInt32(txtsearch.Text) select x).FirstOrDefault();
                if(result != null)
                {
                    var count = (from x in db.zips where x.state == result.state select x).Count();
                    var state = (from x in db.states where x.name == result.state select x).FirstOrDefault();
                    lblnumber.Visible = true;
                    lblstcity.Visible = true;
                    imgState.Visible = true;
                    lblstcity.Text = "You Live in: " + result.city + ", " + state.abbrv;
                    lblnumber.Text = "There are: " + (count - 1) + " other zip codes in " + result.state;
                    imgState.ImageUrl = "states/state-" + state.abbrv.Replace(" ","-") + ".png";
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Zipcode does not exist";
                }
            }
        }
    }
}