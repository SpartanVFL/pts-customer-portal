using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class Service : _Default
    {

        new void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnSubmitSupport_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {

                // Declare variables from text boxes to pass to method
                string txtSupportTitleInput = txtSupportTitle.Text;
                string txtSupportDescrInput = txtSupportDescr.Text;

                // Create an object and create the work item
                CreateWorkItem customer = new CreateWorkItem();
                string result = customer.CreateWorkItemMethod(txtSupportTitleInput, txtSupportDescrInput);

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
    }
}
