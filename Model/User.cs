using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    // Veritabanında kullanacağımız kullanıcıların modelini burada oluşturuyoruz.
    public class User
    {
        [Key]
        [Display(Name = "Id")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Ad girilmesi zorunlu bir bilgidir.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Adınız 3 ile 30 karakter arasında olmalıdır.")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad girilmesi zorunlu bir bilgidir.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Soyadınız 3 ile 30 karakter arasında olmalıdır.")]
        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [Display(Name = "Telefon")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Geçerli bir telefon numarası değil.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
    }
}
