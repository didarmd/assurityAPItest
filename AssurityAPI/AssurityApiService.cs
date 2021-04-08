using AssurityAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace AssurityAPI
{
    public class AssurityApiService
    {
        static string ApiBaseUrl = "https://api.tmsandbox.co.nz/v1/Categories/6328/Details.json?catalogue=false";

        public static Category GetCategory()
        {
            Category category = null;
            HttpWebRequest request = WebRequest.Create(ApiBaseUrl) as HttpWebRequest;

            //request.Accept = "application/xrds+xml";  
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
            {
                string responseText = reader.ReadToEnd();

                if (!string.IsNullOrWhiteSpace(responseText))
                {
                    category = JsonConvert.DeserializeObject<Category>(responseText);
                }
            }

            return category;

        }
    }
}
