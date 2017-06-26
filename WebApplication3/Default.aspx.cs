using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WebApplication3
{
    public partial class _Default : Page
    {
        public string user, pass;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ValidationClick(object sender, EventArgs e)
        {
            user = email.Text;
            pass = pwd.Text;
            string[] cred = new string[] { };

            // check if empty
            if (user == "" || pass == "")
            {
                Response.Write("<script>alert('Please enter username and password');</script>");
                return;
            }


            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "pts-app-dev-sql1.database.windows.net";
                builder.UserID = "dbadmin";
                builder.Password = "pt5db@dmin";
                builder.InitialCatalog = "customer-service-portal";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select * from CSP_AUTH where CSP_USER = '" + user + "';");
                    string sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user1.Text = reader.GetString(1);
                                pass1.Text = reader.GetString(2);
                                
                            }

                            if (pass != pass1.Text)
                            {
                                pass1.Text = "Username or password entered is invalid. Try again.";
                            }
                            else
                            {
                                Response.Redirect("/Service");
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch(SqlException ex)
            {
                // message error
                user1.Text = Convert.ToString(ex);
            }

            

        }


    }
}