using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace WebApplication3
{
    public class UpdateWorkItem
    {




        public void UpdateWorkItemMethod(string workItemID, int number)
        {
            string _personalAccessToken = "bzhjzste65ovvrz3jd5mcvjwjbmp6nzroiskbi22gshbsgo3xj2q";
            string _credentials = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "mwest", _personalAccessToken)));
            string _id = workItemID;    //change to id for a specific work item




            Object[] patchDocument = new Object[1];

            //change some values on a few fields
            if (number == 1)
            {
                patchDocument[0] = new { op = "add", path = "/fields/System.State", value = "Closed" };

            }

            else
            {
                patchDocument[0] = new { op = "add", path = "/fields/System.State", value = "New" };
            }




            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _credentials);

                //serialize the fields array into a json string
                var patchValue = new StringContent(JsonConvert.SerializeObject(patchDocument), Encoding.UTF8, "application/json-patch+json");

                var method = new HttpMethod("PATCH");
                var request = new HttpRequestMessage(method, "https://provisions.visualstudio.com/_apis/wit/workitems/" + _id + "?api-version=2.2") { Content = patchValue };
                var response = client.SendAsync(request).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                }
            }
        }





    }
}