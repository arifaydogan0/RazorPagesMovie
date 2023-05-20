using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(); //Razor Pages deste�i eklendi.
builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();  //HTTP isteklerini HTTPS'ye y�nlendirir.

app.UseStaticFiles();   //HTML, CSS, g�r�nt�ler ve JavaScript gibi statik dosyalar�n kullan�m�na olanak tan�r.

app.UseRouting();  //Middleware i�lem hatt�na yol e�le�tirmesi yapar.

app.UseAuthorization(); //Kullan�c�y� g�venli kaynaklara eri�mesi i�in yetkiler. Bu uygulama yetkilendirme kullanm�yor, bu nedenle bu sat�r kald�r�labilir.

app.MapRazorPages();  //Sayfalar i�in Razor endpoint y�nlendirmesini yap�land�r�yor.

app.Run();
