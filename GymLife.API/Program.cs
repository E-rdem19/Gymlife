using GymLife.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Veritabanı bağlantısı (appsettings.json içindeki ConnectionString ile)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 Controller ve API servisi
builder.Services.AddControllers();

// 🔹 Swagger (API test arayüzü)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Geliştirme ortamında Swagger aktif
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔹 HTTPS yönlendirme
app.UseHttpsRedirection();

// 🔹 Yetkilendirme (ileride JWT eklersen aktif olacak)
app.UseAuthorization();

// 🔹 Controller yönlendirmeleri
app.MapControllers();

// 🔹 Uygulamayı çalıştır
app.Run();
