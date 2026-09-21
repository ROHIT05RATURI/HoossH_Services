using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<HoossH_Service_DAL.Repositories.IAuthRepository, HoossH_Service_DAL.Repositories.LoginRepository>();
builder.Services.AddScoped<HoossH_Service_DAL.Repo.IAttendanceRepository, HoossH_Service_DAL.Repo.AttendanceRepository>();

// 1. COOKIE AUTHENTICATION (Login ke liye)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.LogoutPath = "/Login/Logout";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });

// 2. SESSION (Aapke purane variables / Layout.cshtml ko crash hone se bachane ke liye)
builder.Services.AddDistributedMemoryCache(); // <-- Ye line miss ho gayi thi
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// MIDDLEWARE ORDER (Ye order bahut zaroori hai)
app.UseSession();        // 1. Pehle Session
app.UseAuthentication(); // 2. Phir Authentication (Claims)
app.UseAuthorization();  // 3. Phir Authorization

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();