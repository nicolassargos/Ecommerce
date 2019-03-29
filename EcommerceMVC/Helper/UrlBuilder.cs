using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EcommerceMVC.Helper
{
    public class UrlBuilder : IUrlBuilder
    {
        public string BaseUrl => ConfigurationManager.AppSettings["restApiUrl"];
    }
}