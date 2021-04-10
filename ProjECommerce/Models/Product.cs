using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjECommerce.Models
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Descrição")]
        public string Description { get; set; }

        [DisplayName("Data de criação")]
        public DateTime DateCreated { get; set; }

        [DisplayName("Imagem")]
        public  string ImageDescription { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

    }
}
