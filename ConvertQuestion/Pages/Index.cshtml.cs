using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConvertQuestion.Pages
{
    public class IndexModel : PageModel
    {
        static HttpClient client = new HttpClient();
        private readonly ILogger<IndexModel> _logger;
        public string Chaine { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

           Chaine =  Getstring().GetAwaiter().GetResult();
            
        }

        public async Task<string> Getstring()
        {
            string response = string.Empty;
            using (var client = new HttpClient())
            {
                 response =
                    await client.GetStringAsync("http://appliweather-jhtpro-dev.apps.sandbox.x8i5.p1.openshiftapps.com/weatherforecast");
                //The response object is a string that looks like this:
                //"{ message: 'Hello world!' }"
            }
            
            return response;
        }
    }
}
