using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace odev_05.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [DisplayName("Eski Şifre")]
        public string OldPassword { get; set; }
        [Required]
        [DisplayName("Yeni Şifre")]
        [StringLength(50,MinimumLength =5,ErrorMessage ="Girdiğiniz şifre en az 5 karakter olmalıdır...")]
        public string NewPassword { get; set; }
        [Required]
        [DisplayName("Yeni Şifre Tekrarı")]
        [Compare("NewPassword",ErrorMessage ="Girdiğiniz şifreler aynı olmalıdır..")]
        public string ConNewPassword { get; set; }
    }
}