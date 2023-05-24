[Bu Sayfada Referans Alınan Projenin Orijinali](https://learn.microsoft.com/tr-tr/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-7.0&tabs=visual-studio)
# Asp.NET Core Razor Pages
Razor Pages, Asp.NET Core ile server tabanlı UI web uygulaması geliştirme çerçevesidir. Burada bir uygulama geliştirilerek proje dosyaları incelenecektir.  
Yeni bir Asp.NET Core Web App projesi başlatınca karşımıza şuna benzer bir proje geliyor.  

![](https://learn.microsoft.com/tr-tr/aspnet/core/tutorials/razor-pages/razor-pages-start/_static/6/se.png?view=aspnetcore-7.0)
## Proje Dosyaları
### Pages klasörü
Razor Pagesi ve destekleyici dosyaları içerir. Her razor page, bir dosya çiftidir(.cshtml, .cshtml.cs).
- `.cshtml` => Razor sözdizimini kullanan, C# koduyla HTML işaretlemisini içeren dosya.
- `.cshtml.cs` => Sayfa olaylarını işleyen C# koduna sahip dosya.
- `_Layout.cshtml` => Tüm sayfalarda ortaktır ve proje içinde çoğu yerde ortaklaşa kullanılacak bir şablon oluşturmak için kullanılır. Burada sayfanın üst kısmındaki gezinti menüsünü ve sayfanın en altındaki telif hakkı bildirimini ayarlar. Destekleyici dosyaların alt çizgiyle başlayan adları vardır.
### wwwroot klasörü
HTML dosyaları, JavaScript dosyaları ve CSS dosyaları gibi statik varlıklar içerir.
### appsettings.json
Bağlantı dizeleri gibi yapılandırma verilerini içerir.
### Program.cs
Bu dosyadaki kod satırları önceden yapılandırılmış varsayılanlarla bir WebApplicationBuilder oluşturur, DI konteynerına Razor Pages desteğini ekler ve uygulamayı derler. Servis ekleme ve routing ile ilgili tüm işlemleri ve yapılandırmaları burada yaparız.

## Geliştirme Süreci
1. Veri Modeli Eklenmesi: 
   - Proje içerisine Models adında bir klasör ekledim, bu klasör modelleri tutacak. Models klasörüme Movie adında sınıf ekliyorum ve özelliklerini tanımlıyorum.
2. Veri Modelinin İskelesinin Eklenmesi (Scaffold):
   - Projedeki Pages klasörü altına Movies adında yeni klasör ekledim. Bu Movies klasörüne sağ tıklayıp Add -> New Scaffold Item -> Razor Pages using Entity Framework (CRUD) seçiyoruz.
   - Açılan pencerede Model class olarak Movie sınıfını seçiyoruz, DbContext class için + ya basarak RazorPagesMovie.Data.RazorPagesMovieContext oluşturduk ve add tıkladık.
   - Bu işlem sonrasında Pages/Movies dizininde Create, Delete, Details, Edit, Index isimli razor page dosyaları ve Data/RazorPagesMovieContext.cs dosyaları otomatik olarak oluşturuldu ve Program.cs e ekstra bir kaç satır kod eklendi.
3. EF'nin migration özeliğini kullanarak ilk db şemasını oluşturma
   - Tools -> Nuget Package Manager -> Package Manager Consoler seçiyoruz ve PMC'de `Add-Migration InitialCreate` ve ardından `Update-Database` komutlarını giriyoruz. *(Burada Add-Migration komutu ilk veritabanı şemasını oluşturmak için kod üretir. Şema, DbContext'te belirtilen modeli temel alır. InitialCreate bağımsız değişkeni, migrationu adlandırmak için kullanılır. Herhangi bir ad kullanılabilir, ancak kural gereği migrationu açıklayan bir ad seçilir.Update-Database komutu uygulanmamış migrationlarda Up yöntemini çalıştırır. Bu durumda komut, veritabanını oluşturan `Migrations/<time-stamp>_InitialCreate.cs` dosyasında Up yöntemini çalıştırır.)*
