using System.ComponentModel.DataAnnotations;

namespace ASPNETCOREMVCPROJE.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        [StringLength(30, ErrorMessage = "Kullanıcı adı en fazla 30 karakter olabilir.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Şifre en az 6, en fazla 10 karakter olmalıdır.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifreyi tekrar giriniz.")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Şifre en az 6, en fazla 10 karakter olmalıdır.")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Ad Soyad gereklidir.")]
        public string NameSurname { get; set; }
    }
}
