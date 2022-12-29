using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public class GlobalVariables
    {
        public static HttpClient WebApiClient = new HttpClient();

        public static string APIAddress = ConfigurationManager.AppSettings["APIAddress"];
        static GlobalVariables() 
        {
            WebApiClient.BaseAddress = new Uri(APIAddress);
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}