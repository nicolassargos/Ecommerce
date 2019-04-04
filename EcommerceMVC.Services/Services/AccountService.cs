using EcommerceMVC.Helper;
using EcommerceMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EcommerceMVC.Controllers
{
    public class AccountService
    {
        string baseApiUrl { get; }
        HttpClient client = new HttpClient();

        public AccountService(IUrlBuilder urlBuilder)
        {
            baseApiUrl = urlBuilder.BaseUrl;
            
        }

        public void AddHttpAuthenticationHeaders(AccountModel account)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", account.Credentials);
        }


        public void RegisterUserCredentials(AccountModel account)
        {
            if (HttpContext.Current.Session["userCredentials"] == null)
                HttpContext.Current.Session.Add("userCredentials", account);
            else
                HttpContext.Current.Session["userCredentials"] = account;
        }

        public async Task<AccountModel> GetUser(AccountModel account)
        {
            //RegisterUserCredentials(account);

            AddHttpAuthenticationHeaders(account);
            var result = await client.GetAsync(baseApiUrl + "account");
            AccountModel accountReceived = JsonConvert.DeserializeObject<AccountModel>(await result.Content.ReadAsStringAsync());

            if (accountReceived != null)
            {
                accountReceived.IsAuthenticated = true;
                RegisterUserCredentials(accountReceived);
            }
            return accountReceived;
        }
    }
}