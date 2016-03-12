using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace opssau2
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void Registrate(object sender, EventArgs eventArgs)
        {
            var teamName = login_field.Value;
            var cityName = "-".Equals(cityDropDown.Text) ? city_text.Value : cityDropDown.Text;

            var captainName = captain_name.Value;
            var captainEmail = captain_email.Value;
            var captainPhone = captain_number.Value;

            var secondName = second.Value;

            var thirdName = third.Value;

            int captainId = DatabaseHelper.InsertPersonAndReturnId(captainName, true, captainEmail, captainPhone);
            int secondId = DatabaseHelper.InsertPersonAndReturnId(secondName, false, null, null);
            int thirdId = DatabaseHelper.InsertPersonAndReturnId(thirdName, false, null, null);

            if (!DatabaseHelper.ContainsCity(cityName))
            {
                DatabaseHelper.InsertCity(cityName);
            }

            DatabaseHelper.InsertTeam(teamName, captainName, secondName, thirdName, cityName);

            Response.Redirect("Registration.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            GridView3.Visible = true;
        }
    }
}