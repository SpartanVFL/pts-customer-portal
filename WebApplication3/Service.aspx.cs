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
    public partial class Service : Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            if (Session["user"] == null && !Request.Path.EndsWith("Default.aspx"))
            {
                Response.Redirect("/Default", false);
            }

            
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            

        }// End of page load




        protected void btnSubmitSupport_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                showConfirmation.Style["display"] = "block";

                // Declare variables from text boxes to pass to method
                string txtSupportTitleInput = txtSupportTitle.Text;
                string txtSupportDescrInput = txtSupportDescr.Text;
                string submittedBy = Session["user"].ToString();

                // Create an object and create the work item
                CreateWorkItem customer = new CreateWorkItem();
                string result = customer.CreateWorkItemMethod(txtSupportTitleInput, txtSupportDescrInput, submittedBy);

                // Determine if operation failed or not
                if (result != "Error")
                {
                    //Display result in label below submit                   
                    lblResult.Text = "Successfully created a support ticket with title '" + txtSupportTitle.Text + "'.";
                    lblResult.Visible = true;

                    //Clear text boxes
                    txtSupportTitle.Text = "";
                    txtSupportDescr.Text = "";

                   


                }

                else
                {
                    //Display error in label
                    lblResult.Text = "An error has occured. Please try again.";
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Visible = true;
                }


            }// End of isValid
        }// End of button onclick

       



    }// End of class
}// End of namespace
