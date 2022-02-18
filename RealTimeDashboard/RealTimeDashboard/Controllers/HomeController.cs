using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RealTimeDashboard.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TableDependency.SqlClient;
using Microsoft.Extensions.Configuration;
using TableDependency.SqlClient.Base.EventArgs;
using RealTimeDashboard.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace RealTimeDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<SignalServer> _context;
        private readonly IConfiguration configuration;
        GetApi _helper = new GetApi(); 
        string connectionstring = "";

        public HomeController(IConfiguration config, IHubContext<SignalServer> context)
        {
            configuration = config;
            _context = context;         
        }
            
        private void _dependency_Onerror(object sender, ErrorEventArgs e)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "RealTimeDashboard";
                eventLog.WriteEntry(e.Message, EventLogEntryType.Error, 101, 1);
            }
            
        }

        private async void _dependency_Onchanged(object sender, RecordChangedEventArgs<Numbers> e)
        {
            //long number = 0;
            //using (SqlConnection con = new SqlConnection(connectionstring))
            //{
            //    con.Open();
            //    SqlCommand objSqlCommand = new SqlCommand("SELECT Top 1 Number  FROM  dbo.Numbers  order by Id desc", con);
            //    try
            //    {
            //        number = Convert.ToInt64(objSqlCommand.ExecuteScalar());
            //      await  _context.Clients.All.SendAsync("RefreshEmployees", number);
            //    }
            //    catch (Exception ex)
            //    {
            //        con.Close();
            //    }
            //}

            using (System.IO.StreamReader r = new System.IO.StreamReader("D:/NetCore/RealTimeDashboard/RealTimeDashboard/Json/json1.json"))
            {
                string json = r.ReadToEnd();
                await _context.Clients.All.SendAsync("RefreshEmployees", json);
            }

            //PackListDetails payload = new PackListDetails();
            //string json = JsonConvert.SerializeObject(payload);
            //StringContent payloadContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            //HttpResponseMessage responseTask = null;
            //using (HttpClient client = new HttpClient())
            //{
            //    //responseTask = await client.GetAsync("https://reqres.in/api/users?page=2");
            //    responseTask = await client.PostAsync("http://10.5.50.197:82/api/Dispatchgate/allgateso", payloadContent);
            //    if (responseTask.IsSuccessStatusCode)
            //    {
            //      var data = responseTask.Content.ReadAsStringAsync().Result;
            //      await  _context.Clients.All.SendAsync("RefreshEmployees", data);
            //    }
            //}                                        
        }
        public IActionResult Index()
        {
            connectionstring = configuration.GetConnectionString("Getconnection");
            var _dependency = new SqlTableDependency<Numbers>(connectionstring);
            _dependency.OnChanged += _dependency_Onchanged;
            _dependency.OnError += _dependency_Onerror;
            _dependency.Start();
            return View();
        }      
        public async Task<IActionResult> GetJson()
        {
            using (System.IO.StreamReader r = new  System.IO.StreamReader("D:/NetCore/RealTimeDashboard/RealTimeDashboard/Json/json.json"))
            {
                 string json =  r.ReadToEnd();
                 return  Ok( json);
            }
           
          //  return Ok(await _helper.Getpacklist());         
        }

        public IActionResult data()
        {
            return View();
        }
    }
    
}

