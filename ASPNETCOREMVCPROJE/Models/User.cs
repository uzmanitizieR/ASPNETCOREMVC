using System;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCOREMVCPROJE.Models
{
    public class User
    {
        [Key] // Birincil anahtar
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Ad ve Soyad gereklidir.")]
        [StringLength(50, ErrorMessage = "Ad ve Soyad en fazla 50 karakter olabilir.")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        [StringLength(30, ErrorMessage = "Kullanıcı adı en fazla 30 karakter olabilir.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Şifre en az 6, en fazla 20 karakter olmalıdır.")]
        public string Password { get; set; } // Şifre şifrelenmiş olarak saklanmalı.

        [Required]
        public bool Locked { get; set; } = false;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Rol gereklidir.")] // Role alanı zorunlu olacak.
        [StringLength(20, ErrorMessage = "Rol en fazla 20 karakter olabilir.")]
        public string Role { get; set; } = "User"; // Varsayılan değer "User"
    }
}
