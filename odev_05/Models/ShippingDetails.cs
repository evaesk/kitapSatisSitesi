using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace odev_05.Models
{
    public class ShippingDetails
    {
        public string UserName { get; set; }
        [Required(ErrorMessage ="Lütfen adres bilgilerinizi giriniz..")]
        public string Adres { get; set; } 
        [Required(ErrorMessage ="Lütfen il bilginizi giriniz..")]
        public string Sehir { get; set; } 
        [Required(ErrorMessage ="Lütfen ilçe bilginizi giriniz..")]
        public string Semt { get; set; }
        [Required(ErrorMessage ="Lütfen mahalle bilginizi giriniz..")]
        public string Mahalle { get; set; }
        [Required(ErrorMessage ="Lütfen postakodu bilginizi giriniz..")]
        public string PostaKodu { get; set; }
    }
}