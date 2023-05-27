using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        /* 
         * Bu kısımda Dependency Injection yapılıyor.
         * Yapıcı metot, RazorPagesMovieContext'i sayfaya ekliyor. 
         */
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;
        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        /* 
         * Bu kısımda sayfaya tür ve isimle arama yapmamızı sağlayan kodlar eklendi.
         * OnGet metodu içinde hangi Movie'lerin dönüleceği belirlenip sayfa oluşturuluyor.
         */
        [BindProperty(SupportsGet = true)]  //HTTP GET isteklerinin bağlanması için gereklidir.
        public string? SearchString { get; set; }
        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }
        public IList<Movie> Movie { get; set; } = default!;


        /* 
         * Bu kısımda OnGet veya OnGetAsync metoduyla sayfa durumu başlatılır.
         * Burada OnGetAsync metodu sayfa durumunu başlatırken bir Movie listesi döndürür ve görüntüler.
         * Yani bu sayfaya bir GET isteği yapıldığında Movie listesi dönülüyor.
         */
        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Movie orderby m.Genre select m.Genre;  //tüm türleri veritabanından alan bir LINQ sorgusudur.

            var movies = from m in _context.Movie select m;

            if (!string.IsNullOrEmpty(SearchString))
                movies = movies.Where(s => s.Title.Contains(SearchString));

            if (!string.IsNullOrEmpty(MovieGenre))
                movies = movies.Where(x => x.Genre == MovieGenre);

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());  //Türlerin SelectList'i, farklı türler yansıtılarak oluşturulur.
            Movie = await movies.ToListAsync();
        }
    }
}
