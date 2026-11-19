
var builder = WebApplication.CreateBuilder(args);

// Registrar los servicios MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar el manejo de errores
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Configurar solicitudes HTTP
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configurar rutas para todos los ejercicios
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
