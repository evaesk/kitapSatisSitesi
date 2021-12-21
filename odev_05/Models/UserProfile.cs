using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace odev_05.Models
{
    public class UserProfile
    {
        public string id { get; set; }
        [Required]
        [DisplayName("Ad")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Soyad")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }
        [Required]
        [DisplayName("E-mail")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli e-mail giriniz...")]
        public string Email { get; set; }
    }
}