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
     
        public string user_entered, pass_entered, fname, lname, db_user, db_pass, trigger;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("/Service", false);
            }
        }


        public void ValidationClick(object sender, EventArgs e)
        {
            user_entered = email.Text;
            pass_entered = pwd.Text;
            
            // check if empty
            if (user_entered == "" || pass_entered == "")
            {
                Response.Write("<script>alert('Please enter username and password');</script>");
                
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
                    sb.Append("select * from CSP_AUTH where CSP_USER = '" + user_entered + "';");
                    string sql = sb.ToString();

                    using (SqlCommand a_command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader a_reader = a_command.ExecuteReader())
                        {
                            while (a_reader.Read())
                            {
                                db_user = a_reader.GetString(1);
                                db_pass = a_reader.GetString(2);
                                fname = a_reader.GetString(3);
                                lname = a_reader.GetString(4);
                                trigger = a_reader.GetString(5);

                            }
                            // if password is not correct, prompt user to try again else start session and redirect to /service page
                            if (pass_entered != db_pass)
                            {
                                pass1.Text = "Username or password entered is invalid. Try again.";
                                
                            }
                            else 
                            {
                                Session["user"] = user_entered;
                                Response.Redirect("/Service");
                            }
                            /* // update trigger column to 1 and redirect to /service page 
                            else if (trigger == "0" || pass_entered == db_pass)
                            {
                                connection.Close();
                                connection.Open();
                                sb = new StringBuilder();
                                sb.Append("update CSP_AUTH set CSP_TRIGGER = '0' where CSP_USER = '" + user_entered + "';");
                                sql = sb.ToString();

                                using (SqlCommand b_command = new SqlCommand(sql, connection))
                                {
                                    using (SqlDataReader b_reader = b_command.ExecuteReader())
                                    {
                                        Response.Redirect("/Service");
                                    }
                                }
                            }
                            */
                        }
                        connection.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                // message error
                user1.Text = Convert.ToString(ex);
            }

            

        }


    }
}