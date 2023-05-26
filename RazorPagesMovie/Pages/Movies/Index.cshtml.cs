
using Microsoft.AspNetCore.Mvc.RazorPages;
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
         * Bu kısımda OnGet veya OnGetAsync metoduyla sayfa durumu başlatılır.
         * Burada OnGetAsync metodu sayfa durumunu başlatırken bir Movie listesi döndürür ve görüntüler.
         * Yani bu sayfaya bir GET isteği yapıldığında Movie listesi dönülüyor.
         */
        public IList<Movie> Movie { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                Movie = await _context.Movie.ToListAsync();
            }
        }
    }
}
