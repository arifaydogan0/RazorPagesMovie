var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(); //Razor Pages desteði eklendi.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();  //HTTP isteklerini HTTPS'ye yönlendirir.

app.UseStaticFiles();   //HTML, CSS, görüntüler ve JavaScript gibi statik dosyalarýn kullanýmýna olanak tanýr.

app.UseRouting();  //Middleware iþlem hattýna yol eþleþtirmesi yapar.

app.UseAuthorization(); //Kullanýcýyý güvenli kaynaklara eriþmesi için yetkiler. Bu uygulama yetkilendirme kullanmýyor, bu nedenle bu satýr kaldýrýlabilir.

app.MapRazorPages();  //Sayfalar için Razor endpoint yönlendirmesini yapýlandýrýyor.

app.Run();
