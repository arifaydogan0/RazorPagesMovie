using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(); //Razor Pages deste�i eklendi.
builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesMovieContext") ?? throw new Exception("Connection string 'RazorPagesMovieContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); 
    app.UseHsts();   // Varsayılan HSTS değeri 30 gündür. Bunu production senaryoları için değiştirmek isteyebilirsiniz, bkz. https://aka.ms/aspnetcore-hsts
}

app.UseHttpsRedirection();  //HTTP isteklerini HTTPS'ye yönlendirir.

app.UseStaticFiles();   //HTML, CSS, görüntüler ve JavaScript gibi statik dosyaların kullanımına olanak tan�r.

app.UseRouting();  //Middleware işlem hattına yol eşleştirmesi yapar.

app.UseAuthorization(); //Kullanıcıya g�venli kaynaklara eri�mesi i�in yetkiler. Bu uygulama yetkilendirme kullanm�yor, bu nedenle bu sat�r kald�r�labilir.

app.MapRazorPages();  //Sayfalar için Razor endpoint yönlendirmesini yapılandırıyor.

app.Run();
