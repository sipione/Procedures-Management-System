using SGE.UI.Components;
using SGE.Aplicacion;
using SGE.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTransient<IExpedienteRepositorio, ExpedienteRepositorioArchivo>();
builder.Services.AddTransient<ITramiteRepositorio, TramiteRepositorioArchivo>();
builder.Services.AddTransient<IUsuarioRepositorio, UsuarioRepositorioProvisorio>();
builder.Services.AddTransient<IServicioAutenticacion, ServicioAutenticacion>();
builder.Services.AddTransient<IServicioAutorizacion, ServicioAutorizacion>();

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
