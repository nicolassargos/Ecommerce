using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceMVC.Models
{
    public class PaymentModel
    {
        public int id { get; set; }
        public string guid { get; set; }
        public string cardNumber { get; set; }
        public string cardholderName { get; set; }
        public string cvv { get; set; }
        public DateTime expiryDate { get; set; }
        public decimal paymentAmount { get; set; }
    }
}