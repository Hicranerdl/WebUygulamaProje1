using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebUygulamaProje1.Models
{
    public class KitapTuru
    {
        [Key]   //set primary key anlamına gelir .Eğer id  yi "Id" şeklinde tanımlarsan  [Key] kısmını yazmasanda microsoft primary key olarak aLgılar .
        public int Id { get; set; }

        [Required(ErrorMessage ="Kitap Tür Adı Boş Bırakılamaz!")]  //not null anlamına gelir
        [MaxLength(25)]
        [DisplayName("Kitap Türü Adı")]
        public string Ad { get; set; }


    }
}
