using System;
using System.Collections.Generic;
using System.Linq;
using RealTimeDashboard.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http; 
using System.Threading.Tasks;

namespace RealTimeDashboard.Data
{
    public class GetApi
    {
        public async Task<string> Getpacklist()
        {
            PackListDetails payload = new PackListDetails();
            string json = JsonConvert.SerializeObject(payload);
            StringContent payloadContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage responseTask = null;
            using (HttpClient client = new HttpClient())
            {
                //responseTask = await client.GetAsync("https://reqres.in/api/users?page=2");
                responseTask = await client.PostAsync("http://10.5.50.197:82/api/Dispatchgate/allgateso", payloadContent);
                if (responseTask.IsSuccessStatusCode)
                {
                   return  responseTask.Content.ReadAsStringAsync().Result;    
                }
            }
            return "No Content Found waiting for the Packlist.";

        }
    }
}
