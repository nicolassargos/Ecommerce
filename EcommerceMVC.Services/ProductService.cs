using EcommerceMVC.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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


        public async  Task<HttpResponseMessage> GetProducts()
        {
            //var products = new List<ProductModel>();

            var result = await client.GetAsync(string.Concat(baseApiUrl, "product"));

            return result;
        }
    }
}
