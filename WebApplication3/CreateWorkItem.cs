using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System.Web.UI;

namespace WebApplication3
{
    public class CreateWorkItem : Page
    {
        
        


        public string CreateWorkItemMethod(string wiTitle, string wiDescription, string wiSubmittedBy)
        {
    

            //Define variables
            string workItemTitle = wiTitle;
            string workItemDescription = wiDescription;

            //encode your personal access token   
            string personalAccessToken = "bzhjzste65ovvrz3jd5mcvjwjbmp6nzroiskbi22gshbsgo3xj2q";
            string credentials = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "mwest", personalAccessToken)));

            //Create an object for the Json payload 
            Object[] patchDocument = new Object[4];
            patchDocument[0] = new { op = "add", path = "/fields/System.Title", value = workItemTitle };
            patchDocument[1] = new { op = "add", path = "/fields/System.AreaPath", value = "pts\\nicol-managed-services" };
            patchDocument[2] = new { op = "add", path = "/fields/System.Description", value = workItemDescription };
            patchDocument[3] = new { op = "add", path = "/fields/PTSProcess.SubmittedBy", value = wiSubmittedBy };

            //use the httpclient 
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                //serialize the fields array into a json string
                var patchValue = new StringContent(JsonConvert.SerializeObject(patchDocument), Encoding.UTF8, "application/json-patch+json");

                //Send a PATCH request to vsts
                var method = new HttpMethod("PATCH");
                var request = new HttpRequestMessage(method, "https://provisions.visualstudio.com/pts/_apis/wit/workitems/$Support%20Ticket?api-version=1.0") { Content = patchValue };
                var response = client.SendAsync(request).Result;



                //if the response is successfull, set the result to the workitem object
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    string workItemResult = "Support ticket has been created!";
                    return workItemDescription;

                }

                return workItemDescription = "Error";

            }

        }
    }
}