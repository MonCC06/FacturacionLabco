using FacturacionLabco_AccesoDatos;
using FacturacionLabco_Utilidades;
using FacturacionLabco_Utilidades.Utilidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AplicationDbContext>(options =>
                                                options.UseSqlServer(
                                                builder.Configuration.GetConnectionString("DefaultConnection")));


//Lo modificamos para agregar al servicio la asignacion de roles de usuario
builder.Services.AddIdentity<IdentityUser, IdentityRole>().
    AddDefaultTokenProviders().AddDefaultUI().
    AddEntityFrameworkStores<AplicationDbContext>();


//Servivio de SendGrid correos

builder.Services.AddTransient<IEmailSender, EmailSender>();

// Add services to the container.
builder.Services.AddControllersWithViews();


// A?ade el servicio HttpContextAccessor al contenedor de servicios
builder.Services.AddHttpContextAccessor();


builder.Services.AddSession(Options =>
{
    // Establece el tiempo de inactividad antes de que la sesi?n expire
    Options.IdleTimeout = TimeSpan.FromMinutes(10);

    // Configura la cookie de sesi?n para que sea accesible solo a trav?s de HTTP
    Options.Cookie.HttpOnly = true;

    // Marca la cookie de sesi?n como esencial, lo que significa que no se ver? afectada por las pol?ticas de consentimiento de cookies
    Options.Cookie.IsEssential = true;
});

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

app.UseSession();//este el pipeline para utlizar el servicio de sesiones 

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
