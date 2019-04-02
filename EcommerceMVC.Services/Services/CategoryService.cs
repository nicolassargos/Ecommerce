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
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "dXNlcjpwYXNzdw ==");
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategories()
        {
            var result = await client.GetAsync(string.Concat(baseApiUrl, "category/all"));

            if (result.IsSuccessStatusCode)
            {
                IEnumerable<CategoryModel> categories = JsonConvert.DeserializeObject<IEnumerable<CategoryModel>>(await result.Content.ReadAsStringAsync());

            return categories;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CategoryModel>> GetCategoryHierarchy(int id)
        {
            var result = await client.GetAsync(string.Concat(baseApiUrl, "category"));

            if (result.IsSuccessStatusCode)
            {
                IEnumerable<CategoryModel> categories = JsonConvert.DeserializeObject<IEnumerable<CategoryModel>>(await result.Content.ReadAsStringAsync());

                return categories;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        public async Task<CategoryModel> CreateCategory(CategoryModel category)
        {
            var content = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(string.Concat(baseApiUrl, "category"), content);

            if (result.IsSuccessStatusCode)
            {
                CategoryModel newCategory = JsonConvert.DeserializeObject<CategoryModel>(await result.Content.ReadAsStringAsync());

                return newCategory;
            }

            return null;
        }

        public async Task<CategoryModel> UpdateCategory(CategoryModel category)
        {
            var content = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");
            var result = await client.PutAsync(string.Concat(baseApiUrl, "category/", category.id.ToString()), content);

            if (result.IsSuccessStatusCode)
            {
                CategoryModel newCategory = JsonConvert.DeserializeObject<CategoryModel>(await result.Content.ReadAsStringAsync());

                return newCategory;
            }

            return null;
        }

        /// <summary>
        /// Retourne tous les produits d'une catégorie par son id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductModel>> GetProductsByCategory(int id)
        {
            var content = new StringContent(JsonConvert.SerializeObject(id.ToString()), Encoding.UTF8, "application/json");
            var result = await client.GetAsync(string.Concat(baseApiUrl, "product/category/", id.ToString()));

            if (result.IsSuccessStatusCode)
            {
                IEnumerable<ProductModel> newCategory = JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(await result.Content.ReadAsStringAsync());

                return newCategory;
            }

            return null;
        }

        public async Task<HttpResponseMessage> DeleteCategory(int id)
        {
            var content = new StringContent(JsonConvert.SerializeObject(id.ToString()), Encoding.UTF8, "application/json");
            var result = await client.DeleteAsync(string.Concat(baseApiUrl, "category/", id.ToString()));

            return result;

            //if (!result.IsSuccessStatusCode)
            //{

                //IEnumerable<ProductModel> newCategory = JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(await result.Content.ReadAsStringAsync());

                //return newCategory;
            //}

            //return null;
        }

    }
}
