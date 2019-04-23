using EcommerceMVC.Common.Models;
using EcommerceMVC.Helper;
using EcommerceMVC.Models;
using EcommerceMVC.Services.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceMVC.Services
{
    public class CartService
    {
        string baseApiUrl { get; }
        HttpClient client = new HttpClient();

        AccountService accountService;
        RoutingService routingService;


        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="urlBuilder"></param>
        public CartService(IUrlBuilder urlBuilder)
        {
            baseApiUrl = urlBuilder.BaseUrl;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "dXNlcjpwYXNzdw ==");
            accountService = new AccountService(urlBuilder);
            routingService = new RoutingService();
        }


        /// <summary>
        /// Ajoute un produit du panier (ShoppingCart) en session
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        public async void AddItems(ShoppingCartModel cart, int productId, int quantity)
        {
            var result = await client.GetAsync($"{baseApiUrl}product/{productId}");
            ShoppingCartModel shoppingCart = JsonConvert.DeserializeObject<ShoppingCartModel>(await result.Content.ReadAsStringAsync());
        }


        /// <summary>
        /// Retire un produit du panier (ShoppingCart) en session
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        public void RemoveItems(ShoppingCartModel cart, int productId, int quantity)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Vide le panier (ShoppingCart) stocké session
        /// </summary>
        public void EmptyCart()
        {
            EcommerceSession.ShoppingCart = new ShoppingCartModel();
        }

        //TODO: créer un service Payment
        /// <summary>
        /// Envoie le montant de la transaction à effectuer à l'API de paiement
        /// Récupère un id de transaction (guid)
        /// et redirige vers la page de formulaire de saisie de la carte de crédit
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public async Task<string> GetPaymentAuthorizationId(ShoppingCartModel cart)
        {

            var payment = new PaymentPromessModel()
            {
                amount = cart.totalAmount
            };

            var json = JsonConvert.SerializeObject(payment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage result;

            try
            {
                result = await client.PostAsync(routingService.PaymentAuthorizationUrl, content);
            }
            catch
            {
                throw;
            }

            if (!result.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Unable to get an authorization for this transaction");
            }

            IEnumerable<string> paymentAuthId = new Collection<string>();

            result.Headers.TryGetValues("guid", out paymentAuthId);
            // Redirige vers la page de saisie des données de Carte de Crédit
            var CreditCardCFormUrl = routingService.GetPaymentMvcCCFormUrl(paymentAuthId.ElementAt(0));

            return (CreditCardCFormUrl);
        }


        /// <summary>
        /// Vérifie le status d'une transaction et 
        /// renvoie true si la transaction a été acceptée par l'API de paiement
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        public async Task<bool> CheckPayment(string paymentId)
        {
            if (string.IsNullOrEmpty(paymentId)) throw new NullReferenceException();

            try
            {
                var result = await client.GetAsync(routingService.GetPaymentStatusCheckUrl(paymentId));
                if (result.IsSuccessStatusCode)
                {
                    return await result.Content.ReadAsAsync<bool>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return false;
        }

    }
}
