using Lightspeed.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace Lightspeed
{
    public class LightSpeed
    {
        private readonly string API_KEY;
        private readonly string CLIENT_ID;
        private readonly string USER;
        private readonly string PASSWORD;
        private readonly string BASE_URL;
        private readonly string API_URL;

        public LightSpeed()
        {
            this.API_KEY = ConfigurationManager.AppSettings["API_KEY"];
            this.CLIENT_ID = ConfigurationManager.AppSettings["CLIENT_ID"];
            this.USER = ConfigurationManager.AppSettings["USER"];
            this.PASSWORD = ConfigurationManager.AppSettings["PASSWORD"];
            this.BASE_URL = string.Format("https://api.merchantos.com/API/Account/{0}/", CLIENT_ID);
            this.API_URL = BASE_URL + "{0}.json?callback=";
        }

        public Item GetItem(int itemId)
        {
            return Get<Item>(string.Format(API_URL + "&limit=200&load_relations=[\"Images\",\"Category\"]", "Item/" + itemId), "Item").Result;
        }

        public Image GetItemImage(int itemId)
        {
            return Get<Image>(string.Format(API_URL, "Item/" + itemId + "/Image"), "Image").Result;
        }

        public ICollection<Item> GetItems()
        {
            return Get<ICollection<Item>>(string.Format(API_URL + "&limit=200&load_relations=[\"Images\",\"Category\"]", "Item"), "Item").Result;
        }

        public ICollection<Category> GetAllCategories()
        {
            return Get<ICollection<Category>>(string.Format(API_URL, "Category"), "Category").Result;
        }

        private async Task<TResult> Get<TResult>(string url, string key)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
            ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", USER, PASSWORD))));
            HttpResponseMessage response = await client.GetAsync(string.Format(url));
            var stream = await response.Content.ReadAsStreamAsync();
            StreamReader reader = new StreamReader(stream);
            JavaScriptSerializer js = new JavaScriptSerializer();

            var tmpObj = js.Deserialize<dynamic>(reader.ReadToEnd());
            TResult obj = js.Deserialize<TResult>(js.Serialize(tmpObj[key]));
            reader.Close();
            return obj;
        }
    }
}
