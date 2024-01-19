using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using SigetSystem.Server;
using SigetSystem.Server.Models.Contexto;
using SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Independientes;
using SigetSystem.Server.Repositorio.MetodoAplicado.Implementacion.Padres;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Hijas;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Independientes;
using SigetSystem.Server.Repositorio.MetodoAplicado.Interfaces.Padres;
using SigetSystem.Server.Repositorio.MetodoGenerico.Implementacion;
using SigetSystem.Server.Repositorio.MetodoGenerico.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

builder.Services.AddDbContext<SigetDbContext>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("QuerySql")));

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

builder.Services.AddAutoMapper(typeof(MappingConfig));

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

builder.Services.AddTransient(typeof(IMetodoGenerico<>), typeof(MetodoGenerico<>));
builder.Services.AddTransient(typeof(IMetodoLookupGenerico<>), typeof(MetodoLookupGenerico<>));

builder.Services.AddScoped<IMetodoComentarioSiget, MetodoComentarioSiget>();
builder.Services.AddScoped<IMetodoOrganismo, MetodoOrganismo>();
builder.Services.AddScoped<IMetodoPersonal, MetodoPersonal>();
builder.Services.AddScoped<IMetodoReporteInspeccion, MetodoReporteInspeccion>();
builder.Services.AddScoped<IMetodoRepresentante, MetodoRepresentante>();
builder.Services.AddScoped<IMetodoRequisitoMayor, MetodoRequisitoMayor>();
builder.Services.AddScoped<IMetodoRequisitoMenor, MetodoRequisitoMenor>();
builder.Services.AddScoped<IMetodoBitacora, MetodoBitacora>();
builder.Services.AddScoped<IMetodoJobReporte, MetodoJobReporte>();
builder.Services.AddScoped<IMetodoCodigoConformidad, MetodoCodigoConformidad>();
builder.Services.AddScoped<IMetodoCodigoSiget, MetodoCodigoSiget>();
builder.Services.AddScoped<IMetodoComentariosInconformidad, MetodoComentarioInconformidad>();
builder.Services.AddScoped<IMetodoDepartamentoInstalacion, MetodoDepartamentoInstalacion>();
builder.Services.AddScoped<IMetodoEstadoAcreditacion, MetodoEstadoAcreditacion>();
builder.Services.AddScoped<IMetodoEstadoComentario, MetodoEstadoComentario>();
builder.Services.AddScoped<IMetodoEstadoPersonal, MetodoEstadoPersonal>();
builder.Services.AddScoped<IMetodoEstadoReporte, MetodoEstadoReporte>();
builder.Services.AddScoped<IMetodoEstadoRepresentante, MetodoEstadoRepresentante>();
builder.Services.AddScoped<IMetodoMunicipioInstalacion, MetodoMunicipioInstalacion>();
builder.Services.AddScoped<IMetodoRangoPersonal, MetodoRangoPersonal>();
builder.Services.AddScoped<IMetodoTipoConformidad, MetodoTipoConformidad>();


//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|
//activacion de cores

builder.Services.AddCors(opciones =>
{
    opciones.AddPolicy("nuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
    });
});

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|
// configuracion HangFire

var ConnectionString = builder.Configuration.GetConnectionString("QuerySql");
builder.Services.AddHangfire(config => config
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(ConnectionString, new SqlServerStorageOptions
        {
            CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            QueuePollInterval = TimeSpan.Zero,
            UseRecommendedIsolationLevel = true,
            DisableGlobalLocks = true
        }));

builder.Services.AddHangfireServer();

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|
//espacio de activacion de servicios

app.UseCors("nuevaPolitica");

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|
// proceso de hagnfire

app.UseHangfireDashboard();

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
