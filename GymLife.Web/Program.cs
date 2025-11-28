using GymLife.Web.Data; // DbContext'inin bulunduğu namespace
using GymLife.Web.Services; // ApiService burada olacaksa ekle
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ MVC Controller + Views servisi ekleniyor
builder.Services.AddControllersWithViews();

// 2️⃣ Veritabanı bağlantısı (SQL Server)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3️⃣ API istekleri için HttpClient servisi (ApiService için gerekli)
builder.Services.AddHttpClient<APIService>();

// 4️⃣ Geliştirme ortamı için Swagger (isteğe bağlı)
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// 5️⃣ Ortam kontrolü
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // güvenli HTTPS protokolü
}
else
{
    // Geliştirme modunda Swagger açmak istersen:
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

// 6️⃣ Middleware pipeline
app.UseHttpsRedirection();
app.UseStaticFiles(); // wwwroot altındaki CSS, JS, img dosyaları için

app.UseRouting();

app.UseAuthorization();

// 7️⃣ MVC Route ayarı (Default Home/Index)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 8️⃣ Uygulama başlatma
app.Run();