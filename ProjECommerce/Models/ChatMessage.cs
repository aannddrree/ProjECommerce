using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjECommerce.Models
{
    public class ChatMessage
    {
        public Int64 destination { get; set; }
        public User sender { get; set; }
        public string message { get; set; }
    }
}
