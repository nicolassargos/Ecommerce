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

namespace EcommerceMVC.Services.Services
{
    public class CartService
    {
        string baseApiUrl { get; }
        HttpClient client = new HttpClient();

        public CartService(IUrlBuilder urlBuilder)
        {
            baseApiUrl = urlBuilder.BaseUrl;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "dXNlcjpwYXNzdw ==");
        }

        public async void AddItems(ShoppingCartModel cart, int productId, int quantity)
        {
            var result = await client.GetAsync($"{baseApiUrl}product/{productId}");
            ShoppingCartModel shoppingCart = JsonConvert.DeserializeObject<ShoppingCartModel>(await result.Content.ReadAsStringAsync());
        }

        public void RemoveItems(ShoppingCartModel cart, int productId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
