using SGE.UI.Components;
using SGE.Aplicacion;
using SGE.Repositorios;
using System.IO;

string path = Path.Combine(Directory.GetCurrentDirectory(), "SGE.sqlite");
if (!File.Exists(path))
{
    SGESqlite.Inicializar();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<SGEContexto>();

builder.Services.AddScoped<IExpedienteRepositorio, ExpedienteRepositorioSqlite>();
builder.Services.AddScoped<ITramiteRepositorio, TramiteRepositorioSqLite>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorioSqlite>();
builder.Services.AddScoped<IServicioAutenticacion, ServicioAutenticacion>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
