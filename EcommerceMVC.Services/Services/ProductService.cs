using EcommerceMVC.Helper;
using EcommerceMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EcommerceMVC.Services
{
    public class ProductService
    {
        string baseApiUrl { get; }
        HttpClient client = new HttpClient();

        public ProductService(IUrlBuilder urlBuilder)
        {
            baseApiUrl = urlBuilder.BaseUrl;
        }


        public async  Task<ProductModel> GetProducts(int id)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "dXNlcjpwYXNzdw ==");

            var result = await client.GetAsync(string.Concat(baseApiUrl, "product/" +id));
            ProductModel product = JsonConvert.DeserializeObject<ProductModel>(await result.Content.ReadAsStringAsync());
            return product;
        }
        
        public async Task<ProductModel> GetProductByName(string name)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "dXNlcjpwYXNzdw ==");

            var result = await client.GetAsync(string.Concat(baseApiUrl, "product/partial/" + name));
            ProductModel product = JsonConvert.DeserializeObject<ProductModel>(await result.Content.ReadAsStringAsync());
            return product;
        }
    }
}
