using ApplicationIdentity2.Context;
using ApplicationIdentity2.Implementation.Identity;
using ApplicationIdentity2.Implementation.Repositories;
using ApplicationIdentity2.Implementation.Services;
using ApplicationIdentity2.Interfaces.Identity;
using ApplicationIdentity2.Interfaces.Repositories;
using ApplicationIdentity2.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationIdentityContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationIdentityContext"),
                b => b.MigrationsAssembly(typeof(ApplicationIdentityContext).Assembly.FullName))); 

builder.Services.AddScoped<IUserRepository, UserStore>();
builder.Services.AddScoped<IRoleRepository, RoleStore>();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
   .AddCookie(config =>
   {
       config.LoginPath = "/auth/login";
       config.Cookie.Name = "DevLightAuth";
       config.LogoutPath = "/auth/logout";
       config.ExpireTimeSpan = TimeSpan.FromMinutes(2);
       config.AccessDeniedPath = "/auth/login";

   });
builder.Services.AddAuthorization();
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

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
