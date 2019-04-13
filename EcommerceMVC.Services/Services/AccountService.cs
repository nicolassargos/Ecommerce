using EcommerceMVC.Helper;
using EcommerceMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace EcommerceMVC.Services
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
            //if (HttpContext.Current.Session["userCredentials"] == null)
            //    HttpContext.Current.Session.Add("userCredentials", account);
            //else
                HttpContext.Current.Session["userCredentials"] = account;
        }

        public void Logout()
        {
            HttpContext.Current.Session["userCredentials"] = new AccountModel();
        }

        public async Task<AccountModel> GetUser(AccountModel account)
        {
            AddHttpAuthenticationHeaders(account);
            var result = await client.GetAsync(baseApiUrl + "account");
            AccountModel accountReceived = JsonConvert.DeserializeObject<AccountModel>(await result.Content.ReadAsStringAsync());

            if (result.IsSuccessStatusCode && accountReceived != null)
            {
                accountReceived.IsAuthenticated = true;
                RegisterUserCredentials(accountReceived);
                RegisterUserRole(accountReceived);

            }
            return accountReceived;
        }

        private void RegisterUserRole(AccountModel account)
        {
            if (!string.IsNullOrWhiteSpace(account.Role)&& !string.IsNullOrEmpty(account.Role))
            {
                var authenticationTicket = new FormsAuthenticationTicket(1, account.Login, DateTime.Now, DateTime.Now.AddMinutes(15), true, account.Role);
                var identity = new FormsIdentity(authenticationTicket);

                var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, account.Login),
                                new Claim(ClaimTypes.AuthenticationMethod, AuthenticationMethods.Password),
                                new Claim(ClaimTypes.Role, account.Role)
                            };
                var principal = new ClaimsPrincipal(new[] { new ClaimsIdentity(claims, "Basic") });

                //Thread.CurrentPrincipal =   new GenericPrincipal(new GenericIdentity(   "Bob", "Passport"), rolesArray);
                //HttpContext.Current.User = new GenericPrincipal( identity, new string[] { account.Role });
                //Thread.CurrentPrincipal = new GenericPrincipal( identity, new string[] { account.Role });
                SetPrincipal(new GenericPrincipal(new GenericIdentity("admin", "Basic"), new string[] { account.Role }));
            }
        }

        private void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = (GenericPrincipal)principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = (GenericPrincipal)principal;
            }
        }

    }
}