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
        string paymentApiUrl = "https://localhost:44348/";
        string paymentMvcUrl = "https://localhost:44387/";

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

        //TODO: créer un service Payment
        public async Task<string> GetPaymentAuthorizationId(ShoppingCartModel cart)
        {

            string apiUrl = string.Concat(paymentApiUrl, "api/Payments");

            var payment = new PaymentModel()
            {
                expiryDate = DateTime.Now,
                paymentAmount = cart.totalAmount
            };


            var json = JsonConvert.SerializeObject(payment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage result;

            try
            {
                result = await client.PostAsync(apiUrl, content);
            }
            catch (Exception ex)
            {
                throw;
            }

            string paymentAuthId="";

            if (result.IsSuccessStatusCode)
            {
                paymentAuthId = await result.Content.ReadAsStringAsync();
            }

            var redirectUrl = $"{paymentMvcUrl}Payment?paymentId={paymentAuthId}";

            return (redirectUrl);
        }
    }
}
