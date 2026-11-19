
using DSWI_T1_05.Data;
using DSWI_T1_05.Repositories.Interfaces;
using DSWI_T1_05.Repositories.Implementations;
using DSWI_T1_05.Services.Interfaces;
using DSWI_T1_05.Services.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de MVC
builder.Services.AddControllersWithViews();

var connectionString =
    builder.Configuration.GetConnectionString("ClinicaConnection");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "No se encontró la cadena de conexión ClinicaConnection."
    );
}

builder.Services.AddDbContext<ClinicaBDContext>(options =>
    options.UseSqlServer(connectionString)
);

// Inyección de dependencias - Repositories
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<ICitaRepository, CitaRepository>();

// Inyección de dependencias - Services
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<ICitaService, CitaService>();

var app = builder.Build();

// Configuración del entorno
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configuración de rutas MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
