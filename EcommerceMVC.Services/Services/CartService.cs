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
        public void RemoveItems(int productId)
        {
            var shpProduct = EcommerceSession.ShoppingCart.shoppingProducts.Single(shp => shp.productId == productId);
            EcommerceSession.ShoppingCart.shoppingProducts.Remove(shpProduct);
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
        /// Changes the quantity of a product in the shopping cart
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        public void ChangeProductQuantity(int productId, int quantity)
        {
            if (productId == 0) throw new ArgumentNullException("L'Id d'un shoppingProduct ne peut pas être nul");
            if (!Exists(productId)) throw new ArgumentOutOfRangeException($"Aucun shoppingProduct n'a été trouvé avec l'Id {productId}");
            if (quantity <= 0)
            {
                RemoveItems(productId);
                return;
            }
            try
            {
                EcommerceSession.ShoppingCart.shoppingProducts.Single(shp => shp.productId == productId).quantity = quantity;
            }
            catch
            {
                throw;
            }
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

        public bool Exists(int productId)
        {
            if (EcommerceSession.ShoppingCart.shoppingProducts.Exists(shp => shp.productId == productId))
                return true;
            else
                return false;
        }

    }
}
