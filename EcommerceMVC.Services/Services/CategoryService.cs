using EcommerceMVC.Models;
using EcommerceMVC.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace EcommerceMVC.Services.Services
{
    public class CategoryService
    {

        string baseApiUrl { get; }
        HttpClient client = new HttpClient();

        public CategoryService(IUrlBuilder urlBuilder)
        {
            baseApiUrl = urlBuilder.BaseUrl;
            //client.BaseAddress = new Uri(baseApiUrl);
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategories()
        {
            //var products = new List<ProductModel>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "dXNlcjpwYXNzdw ==");
            var result = await client.GetAsync(string.Concat(baseApiUrl, "category/all"));

            if (result.IsSuccessStatusCode)
            {
                IEnumerable<CategoryModel> categories = JsonConvert.DeserializeObject<IEnumerable<CategoryModel>>(await result.Content.ReadAsStringAsync());

            return categories;
            }

            return null;
        }
    }
}
