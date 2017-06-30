using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApplication3
{
    public class GetWorkItems
    {



        //we need create an object so that we can bind the
        //query results and get the query id
        public class QueryResult
        {
            public string id { get; set; }
            public string name { get; set; }
            public string path { get; set; }
            public string url { get; set; }
        }

        public class WorkItemQueryResult
        {
            public string queryType { get; set; }
            public string queryResultType { get; set; }
            public DateTime asOf { get; set; }
            public Column[] columns { get; set; }
            public Workitem[] workItems { get; set; }
        }



        public class Workitem
        {
            public int id { get; set; }
            public string url { get; set; }
        }

        public class Column
        {
            public string referenceName { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }


        //test

        public class Fields
        {
            [JsonProperty(PropertyName = "System.Id")]
            public int SystemId { get; set; }

            [JsonProperty(PropertyName = "System.State")]
            public string SystemState { get; set; }

            [JsonProperty(PropertyName = "System.Title")]
            public string SystemTitle { get; set; }

            [JsonProperty(PropertyName = "System.Description")]
            public string SystemDescription { get; set; }

            [JsonProperty(PropertyName = "PTSProcess.SubmittedBy")]
            public string SystemSubmittedBy { get; set; }
        }

        public class Value
        {
            public int id { get; set; }
            public int rev { get; set; }
            public Fields fields { get; set; }
            public string url { get; set; }
        }

        public class RootObject
        {
            public int count { get; set; }
            public List<Value> value { get; set; }
        }


        // end test





        public Tuple<List<int>, List<string>, List<string>, List<string>, List<string>> GetWorkItemsByQuery()
        {
            string _personalAccessToken = "bzhjzste65ovvrz3jd5mcvjwjbmp6nzroiskbi22gshbsgo3xj2q";
            string _credentials = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "mwest", _personalAccessToken)));
            var project = "pts";
            var path = "My Queries/nicol_all_supportticket";     //path to the query  

            int count = 0;

            List<int> WIID = new List<int>();
            List<string> WIState = new List<string>();
            List<string> WITitle = new List<string>();
            List<string> WIDescription = new List<string>();
            List<string> WISubmittedBy = new List<string>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://provisions.visualstudio.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _credentials);

                //if you already know the query id, then you can skip this step
                HttpResponseMessage queryHttpResponseMessage = client.GetAsync(project + "/_apis/wit/queries/" + path + "?api-version=2.2").Result;

                if (queryHttpResponseMessage.IsSuccessStatusCode)
                {
                    //bind the response content to the queryResult object
                    QueryResult queryResult = queryHttpResponseMessage.Content.ReadAsAsync<QueryResult>().Result;
                    string queryId = queryResult.id;

                    //using the queryId in the url, we can execute the query
                    HttpResponseMessage httpResponseMessage = client.GetAsync(project + "/_apis/wit/wiql/" + queryId + "?api-version=2.2").Result;

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        WorkItemQueryResult workItemQueryResult = httpResponseMessage.Content.ReadAsAsync<WorkItemQueryResult>().Result;

                        //now that we have a bunch of work items, build a list of id's so we can get details
                        var builder = new System.Text.StringBuilder();
                        foreach (var item in workItemQueryResult.workItems)
                        {
                            builder.Append(item.id.ToString()).Append(",");
                        }

                        //clean up string of id's
                        string ids = builder.ToString().TrimEnd(new char[] { ',' });

                        HttpResponseMessage getWorkItemsHttpResponse = client.GetAsync("_apis/wit/workitems?ids=" + ids + "&fields=System.Id,System.Title,System.State&asOf=" + workItemQueryResult.asOf + "&api-version=2.2").Result;

                        if (getWorkItemsHttpResponse.IsSuccessStatusCode)
                        {
                            var result = getWorkItemsHttpResponse.Content.ReadAsStringAsync().Result;

                            // Deserialize into an object 
                            var customer = JsonConvert.DeserializeObject<RootObject>(result);

                            // Obtain count of work items                       
                            for (int i = 0; i < customer.count; i++)
                            {
                                count++;
                            }

                            

                            // Assign IDs
                            for (int i = 0; i < customer.count; i++)
                            {
                                WIID.Add(customer.value[i].fields.SystemId);
                            }

                            // Assign State
                            for (int i = 0; i < customer.count; i++)
                            {
                                WIState.Add(customer.value[i].fields.SystemState);
                            }

                            // Assign Titles
                            for (int i = 0; i < customer.count; i++)
                            {
                                WITitle.Add(customer.value[i].fields.SystemTitle);
                            }

                            // Assign Descriptions
                            for (int i = 0; i < customer.count; i++)
                            {
                                WIDescription.Add(customer.value[i].fields.SystemDescription);
                            }

                            // Assign Descriptions
                            for (int i = 0; i < customer.count; i++)
                            {
                                WISubmittedBy.Add(customer.value[i].fields.SystemSubmittedBy);
                            }


                        }
                    }
                }
            }
            return Tuple.Create(WIID, WIState, WITitle, WIDescription, WISubmittedBy);
        }// End of GetWorkItemsByQuery




    }
}