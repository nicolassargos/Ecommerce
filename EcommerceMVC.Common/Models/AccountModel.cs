using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceMVC.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Credentials => Convert.ToBase64String((Encoding.ASCII.GetBytes($"{Login}:{Password}")));
    }
}
