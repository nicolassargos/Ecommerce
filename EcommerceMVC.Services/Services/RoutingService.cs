using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceMVC.Services.Services
{
    public class RoutingService
    {
        public static readonly string PaymentApiBaseUrl = "https://localhost:44348/";
        public static readonly string PaymentMvcBaseUrl = "https://localhost:44387/";
        public string PaymentAuthorizationUrl => $"{PaymentApiBaseUrl}api/Payments";

        public RoutingService()
        {

        }

        public string GetPaymentMvcCCFormUrl(string paymentAuthId)
        {
            return $"{PaymentMvcBaseUrl}Payment?paymentId={paymentAuthId}";
        }

        public string GetPaymentStatusCheckUrl(string paymentId)
        {
            return $"{PaymentApiBaseUrl}api/Payments/check/{paymentId}";
        }

    }
}
