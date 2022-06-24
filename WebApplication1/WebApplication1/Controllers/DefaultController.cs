using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
public class DefaultController : Controller
{
    string Baseurl = "https://localhost:44389/";
    public async Task<ActionResult> Index()
    {
        List<Kisiler> EmpInfo = new List<Kisiler>();
        using (var client = new HttpClient())
        {
            //@model IEnumerable<WebApplication1.Models.Kisiler>
            //Passing service base url
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            //Define request data format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Sending request to find web api REST service resource Kisiler using HttpClient
            HttpResponseMessage Res = await client.GetAsync("api/Proje/Veriler");
            //Checking the response is successful or not which is sent using HttpClient
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Kisiler list
                EmpInfo = JsonConvert.DeserializeObject<List<Kisiler>>(EmpResponse);
            }
            //returning the Kisiler list to view
            return View(EmpInfo);
        }
    }
}
