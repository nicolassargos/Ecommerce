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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="urlBuilder"></param>
        public ProductService(IUrlBuilder urlBuilder)
        {
            baseApiUrl = urlBuilder.BaseUrl;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "dXNlcjpwYXNzdw ==");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            var result = await client.GetAsync(string.Concat(baseApiUrl, "product/all"));
            IEnumerable<ProductModel> products = JsonConvert.DeserializeObject< IEnumerable<ProductModel>>(await result.Content.ReadAsStringAsync());
            return products;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // produits par ID
        public async  Task<ProductModel> GetProduct(int id)
        {
            var result = await client.GetAsync(string.Concat(baseApiUrl, "product/" +id));
            ProductModel product = JsonConvert.DeserializeObject<ProductModel>(await result.Content.ReadAsStringAsync());
            return product;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //produit par nom
        public async Task<ProductModel> GetProductByName(string name)
        {
            var result = await client.GetAsync(string.Concat(baseApiUrl, "product/partial/" + name));
            ProductModel product = JsonConvert.DeserializeObject<ProductModel>(await result.Content.ReadAsStringAsync());
            return product;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<ProductModel> CreateProduct(ProductModel product)
        {
            var content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(string.Concat(baseApiUrl, "product"), content);

            if (result.IsSuccessStatusCode)
            {
                ProductModel newProduct = JsonConvert.DeserializeObject<ProductModel>(await result.Content.ReadAsStringAsync());

                return newProduct;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductModel> EditProduct(int id)
        {
            var result = await client.GetAsync(string.Concat(baseApiUrl, "product/" + id));
            ProductModel product = JsonConvert.DeserializeObject<ProductModel>(await result.Content.ReadAsStringAsync());
            return product;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<ProductModel> ModifyProduct(ProductModel product)
        {
            var content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
            var result = await client.PutAsync(string.Concat(baseApiUrl, "product/modify"), content);

            if (result.IsSuccessStatusCode)
            {
                ProductModel newProduct = JsonConvert.DeserializeObject<ProductModel>(await result.Content.ReadAsStringAsync());

                return newProduct;
            }

            return null;
        }


    }
}
