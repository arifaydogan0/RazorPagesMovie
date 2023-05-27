using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Release Date")]    // Bu öznitelik, bir alanın görünen adını belirtir. Burada, ReleaseDate yerine Release Date.
        [DataType(DataType.Date)] //bu attribute ile saat bilgileri girilmesi gerekmez, zaman değil yalnızca tarih görüntülenir.
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")] //Entity Framework Core'un Price'ı veritabanındaki para birimiyle doğru bir şekilde eşlemesini sağlar.
        public decimal Price { get; set; }
        public string Rating { get; set; } = string.Empty;
    }
}
