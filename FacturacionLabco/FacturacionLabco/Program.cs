using FacturacionLabco_AccesoDatos;
using FacturacionLabco_AccesoDatos.Datos.Repositorio.IRepositorio;
using FacturacionLabco_AccesoDatos.Datos.Repositorio;
using FacturacionLabco_Utilidades;
using FacturacionLabco_Utilidades.Utilidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using FacturacionLabco_AccesoDatos.Datos;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AplicationDbContext>(options =>
                                                options.UseSqlServer(
                                                builder.Configuration.GetConnectionString("DefaultConnection")));

//Lo modificamos para agregar al servicio la asignacion de roles de usuario
builder.Services.AddIdentity<IdentityUser, IdentityRole>().
    AddDefaultTokenProviders().AddDefaultUI().
    AddEntityFrameworkStores<AplicationDbContext>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Identity/Account/Login"; // Aquí pones la ruta del login
                    options.AccessDeniedPath = "/Identity/Account/AccessDenied"; // Página de acceso denegado
                });

builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
//Servicio de TipoAplicacionRepositorio
builder.Services.AddScoped<IDetalleRepositorio, DetalleRepositorio>();
//Servicio de ProductoRepositorio
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
//Servicio de OrdeRepositorio
builder.Services.AddScoped<IFacturaRepositorio, FacturaRepositorio>();
//Servicio de OrdeDetalleRepositorio
builder.Services.AddScoped<IMarcaRepositorio, MarcaRepositorio>();
//Servicio de UsuarioAplicacionRepositorio
builder.Services.AddScoped<IUsuarioAplicacionRepositorio, UsuarioAplicacionRepositorio>();
builder.Services.AddScoped<ITrabajadorRepositorio, TrabajadorRepositorio>();
builder.Services.AddScoped<IVehiculoRepositorio, VehiculoRepositorio>();



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

app.MapGet("/", async context =>
{
    // Si el usuario no está autenticado, redirige al login
    if (!context.User.Identity.IsAuthenticated)
    {
        context.Response.Redirect("/Identity/Account/Login");
        return;
    }

    // Si está autenticado, se puede redirigir a la página de inicio
    context.Response.Redirect("/Factura/Index");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Factura}/{action=Index}/{id?}");

app.Run();
