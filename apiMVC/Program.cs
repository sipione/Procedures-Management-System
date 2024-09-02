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
builder.Services.AddScoped<TramiteValidador>();
builder.Services.AddScoped<UsuarioValidador>();
builder.Services.AddScoped<ExpedienteValidador>();

//INJECCION DE CASOSO DE USO
builder.Services.AddScoped<CasoDeUsoTramiteAlta>();
builder.Services.AddScoped<CasoDeUsoTramiteBaja>();
builder.Services.AddScoped<CasoDeUsoTramiteModificacion>();
builder.Services.AddScoped<CasoDeUsoTramiteConsultaTodos>();
builder.Services.AddScoped<CasoDeUsoTramiteConsultaPorEtiqueta>();
builder.Services.AddScoped<CasoDeUsoTramiteConsultaPorExpediente>();
builder.Services.AddScoped<CasoDeUsoExpedienteAlta>();
builder.Services.AddScoped<CasoDeUsoExpedienteBaja>();
builder.Services.AddScoped<CasoDeUsoExpedienteModificacion>();
builder.Services.AddScoped<CasoDeUsoExpedienteConsultaTodos>();
builder.Services.AddScoped<CasoDeUsoExpedienteConsultaPorld>();
builder.Services.AddScoped<CasoDeUsoUsuarioAlta>();
builder.Services.AddScoped<CasoDeUsoUsuarioBaja>();
builder.Services.AddScoped<CasoDeUsoUsuarioModificacion>();
builder.Services.AddScoped<CasoDeUsoUsuarioConsultaTodos>();
builder.Services.AddScoped<CasoDeUsoUsuarioLogin>();

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
