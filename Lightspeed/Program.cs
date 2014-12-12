using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Configuration;

namespace Lightspeed
{
    class Program
    {

        static void Main(string[] args)
        {

            var x = new LightSpeed();
            var y = x.GetItem(4);
            var z = y.Result;
        }

    }


    public class LightSpeed
    {

        public async Task<Item> GetItem(int itemId)
        {
            string API_KEY = ConfigurationManager.AppSettings["API_KEY"];
            string API_URL =
                       string.Format("https://api.merchantos.com/API/Account/{0}/Item/{1}.json?callback=", 
                       ConfigurationManager.AppSettings["CLIENT_ID"], itemId);
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
            ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}",
                ConfigurationManager.AppSettings["USER"], 
                ConfigurationManager.AppSettings["PASSWORD"]))));
            HttpResponseMessage response = await client.GetAsync(string.Format(API_URL, itemId));
            var stream = await response.Content.ReadAsStreamAsync();
            StreamReader reader = new StreamReader(stream);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var tmpNestObject = js.Deserialize<dynamic>(reader.ReadToEnd());
            Item obj = js.Deserialize<Item>(js.Serialize(tmpNestObject["Item"]));
            reader.Close();
            return obj;
        }


        public class Item
        {
            public int itemId { get; set; }
            public double systemSku { get; set; }
            public decimal defaultCost { get; set; }
            public string description { get; set; }
        }
    }
}
