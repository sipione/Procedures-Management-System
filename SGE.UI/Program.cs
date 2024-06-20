using SGE.UI.Components;
using SGE.Aplicacion;
using SGE.Repositorios;
using System.IO;
using SGE.Aplicacion.CasosDeUso;

string path = Path.Combine(Directory.GetCurrentDirectory(), "SGE.sqlite");
if (!File.Exists(path))
{
    SGESqlite.Inicializar();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


//INJECCION DE REPORITORIOS
builder.Services.AddDbContext<SGEContexto>();
builder.Services.AddScoped<ITramiteRepositorio, TramiteRepositorioSqLite>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorioSqlite>();
builder.Services.AddScoped<IExpedienteRepositorio, ExpedienteRepositorioSqlite>();

//INJECCION DE SERVICIOS
builder.Services.AddScoped<IServicioAutenticacion, ServicioAutenticacion>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddSingleton<IServicioDeSecion, ServicioDeSecionInterna>();

//INJECCION DE VALIDADORES
builder.Services.AddTransient<TramiteValidador>();
builder.Services.AddTransient<UsuarioValidador>();
builder.Services.AddTransient<ExpedienteValidador>();

//INJECCION DE CASOSO DE USO
builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
builder.Services.AddTransient<CasoDeUsoTramiteBaja>();
builder.Services.AddTransient<CasoDeUsoTramiteModificacion>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaTodos>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaPorEtiqueta>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaPorExpediente>();
builder.Services.AddTransient<CasoDeUsoExpedienteAlta>();
builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();
builder.Services.AddTransient<CasoDeUsoExpedienteModificacion>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaTodos>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaPorld>();
builder.Services.AddTransient<CasoDeUsoUsuarioAlta>();
builder.Services.AddTransient<CasoDeUsoUsuarioBaja>();
builder.Services.AddTransient<CasoDeUsoUsuarioModificacion>();
builder.Services.AddTransient<CasoDeUsoUsuarioConsultaTodos>();
builder.Services.AddTransient<CasoDeUsoUsuarioLogin>();

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
