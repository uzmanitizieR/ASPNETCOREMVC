using ASPNETCOREMVCPROJE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Veritaban� ba�lant�s�n� ekliyoruz.
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Authentication ve Authorization i�in cookie ekliyoruz.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";  // Giri� yap�lmam��sa y�nlendirilecek sayfa
        options.LogoutPath = "/Account/Logout";  // ��k�� yap�ld���nda y�nlendirilecek sayfa
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);  // �erezin s�resi
        options.SlidingExpiration = true;  // Oturum s�resi dolmadan �nce �erez
        options.AccessDeniedPath = "/Home/AccessDenied";
                                           // 
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Authentication ve Authorization'� ekliyoruz
app.UseRouting();

// Kimlik do�rulama ve yetkilendirmeyi kullan
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
