using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [StringLength(60, MinimumLength = 3)]  //Max uzunlugu 60, minimum uzunluğu 3 olmalı. 
        [Required]  //Bu attribute, bu propertynin bir değeri olması gerektiğini bildirir.
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Release Date")]    // Bu öznitelik, bir alanın görünen adını belirtir. Burada, ReleaseDate yerine Release Date.
        [DataType(DataType.Date)] //bu attribute ile saat bilgileri girilmesi gerekmez, zaman değil yalnızca tarih görüntülenir.
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]  //Sadece harf kullanılmalıdır, ilk harf büyük, sayılar yazılırken whitespace'e izin verilir,  özel karakterlere izin verilmez.
        [Required]
        [StringLength(30)]
        public string Genre { get; set; } = string.Empty;

        [Range(1, 100)]    //Price değeri 0-100 aralığında olmalı.
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")] //Entity Framework Core'un Price'ı veritabanındaki para birimiyle doğru bir şekilde eşlemesini sağlar.
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]   //İlk harf büyük, sonraki boşluklarda özel karakterlere ve sayılara izin verir. 
        [StringLength(5), Required] //Bu satırda attributelerin tek satırda yazma örneği gösterilmiştir.
        public string Rating { get; set; } = string.Empty;
    }
}
