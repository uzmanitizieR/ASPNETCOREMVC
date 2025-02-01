using ASPNETCOREMVCPROJE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Veritabaný baðlantýsýný ekliyoruz.
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Authentication ve Authorization için cookie ekliyoruz.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";  // Giriþ yapýlmamýþsa yönlendirilecek sayfa
        options.LogoutPath = "/Account/Logout";  // Çýkýþ yapýldýðýnda yönlendirilecek sayfa
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);  // Çerezin süresi
        options.SlidingExpiration = true;  // Oturum süresi dolmadan önce çerez
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

// Authentication ve Authorization'ý ekliyoruz
app.UseRouting();

// Kimlik doðrulama ve yetkilendirmeyi kullan
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
