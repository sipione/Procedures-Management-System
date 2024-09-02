using SGE.Aplicacion;
using SGE.Repositorios;
using System.IO;
using SGE.Aplicacion.CasosDeUso;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

string path = Path.Combine(Directory.GetCurrentDirectory(), "SGE.sqlite");

// Configuracion del DbContext
builder.Services.AddDbContext<SGEContexto>(); 


using (var dbContext = builder.Services.BuildServiceProvider().GetRequiredService<SGEContexto>())
{
    if (!File.Exists(path)){
        SGESqlite.Inicializar(dbContext);
    }
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// INJECCION DE REPOSITORIOS
builder.Services.AddScoped<ITramiteRepositorio, TramiteRepositorioSqLite>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorioSqlite>();
builder.Services.AddScoped<IExpedienteRepositorio, ExpedienteRepositorioSqlite>();

//INJECCION DE SERVICIOS
builder.Services.AddScoped<IServicioAutenticacion, ServicioAutenticacion>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddScoped<IServicioDeSecion, ServicioDeSecionInterna>();

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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
