using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class ViewTickets : System.Web.UI.Page
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

            // Create an object and create the work item
            GetWorkItems customer = new GetWorkItems();

            // Declare Lists to hold work item fields
            List<int> resultWIID = new List<int>();
            List<string> resultWIState = new List<string>();
            List<string> resultWITitle = new List<string>();
            List<string> resultWIDescription = new List<string>();
            List<string> resultWISubmittedBy = new List<string>();

            // Retrieve the work item fields
            resultWIID = customer.GetWorkItemsByQuery().Item1;
            resultWIState = customer.GetWorkItemsByQuery().Item2;
            resultWITitle = customer.GetWorkItemsByQuery().Item3;
            resultWIDescription = customer.GetWorkItemsByQuery().Item4;
            resultWISubmittedBy = customer.GetWorkItemsByQuery().Item5;

            List<string> openList = new List<string>();
            List<string> closedList = new List<string>();
            int active_count = 0;
            int closed_count = 0;

            //Populate open items table
            for (int i = 0; i < resultWIID.Count; i++)
            {
                if (resultWIState[i] != "Closed")
                {
                    openList.Add("<strong>ID</strong>: " + resultWIID[i].ToString() + "<br/><strong>State</strong>: " + resultWIState[i] + "<br/><strong>Title</strong>: " + resultWITitle[i] + "<br/><strong>Description</strong>: " + resultWIDescription[i] + "<br/><strong>Submitted By</strong>:" + resultWISubmittedBy[i]);
                    ListRepeater.DataSource = openList;
                    ListRepeater.DataBind();
                    active_count++;
                }

               if (resultWIState[i] == "Closed")
                {
                    closedList.Add("<strong>ID:</strong> " + resultWIID[i].ToString() + "<br/><strong>State:</strong> " + resultWIState[i] + "<br/><strong>Title:</strong> " + resultWITitle[i] + "<br/><strong>Description:</strong> " + resultWIDescription[i] + "<br/><strong>Submitted By:</strong>" + resultWISubmittedBy[i]);
                    Repeater2.DataSource = closedList;
                    Repeater2.DataBind();
                    closed_count++;
                }



            }

            // Set the total tickets in the footer
            lblActiveCount.Text = active_count.ToString();
            lblClosedCount.Text = closed_count.ToString();



        }// End of page load



        protected void btnCloseSupportTicket_Click(object sender, CommandEventArgs e)
        {
            // Create an object and create the work item
            GetWorkItems customer = new GetWorkItems();
            // Declare arrays to hold work item fields
            List<int> resultWIID = new List<int>();
            List<string> resultWIState = new List<string>();
            List<string> resultWITitle = new List<string>();
            List<string> resultWIDescription = new List<string>();
            List<string> resultWISubmittedBy = new List<string>();



            // Retrieve the work item fields
            resultWIID = customer.GetWorkItemsByQuery().Item1;
            resultWIState = customer.GetWorkItemsByQuery().Item2;
            resultWITitle = customer.GetWorkItemsByQuery().Item3;
            resultWIDescription = customer.GetWorkItemsByQuery().Item4;
            resultWISubmittedBy = customer.GetWorkItemsByQuery().Item5;

            // Loop through to correct work item
            for (int i = 0; i < resultWIID.Count; i++)
            {
                if (i.ToString() == e.CommandArgument.ToString())
                {
                    // Call to API to change state of work item
                    UpdateWorkItem update = new UpdateWorkItem();
                    update.UpdateWorkItemMethod(resultWIID[i].ToString(), 1);


                }


            }





        }// End of button click









    }
}