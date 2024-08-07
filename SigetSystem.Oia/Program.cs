using Blazored.Modal;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SigetSystem.Oia;
using SigetSystem.Oia.Services.Servicios;
using SigetSystem.Oia.Services.Interfaces;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7284") });

builder.Services.AddScoped<ICodigoConformidadService, CodigoConformidadService>();
builder.Services.AddScoped<ICodigoInconformidadService, CodigoInconformidadService>();
builder.Services.AddScoped<ICodigoSigetService, CodigoSigetService>();
builder.Services.AddScoped<IComentariosOIAService, ComentariosOIAService>();
builder.Services.AddScoped<IDepartamentoInstalacion, DepartamentoInstalacionService>();
builder.Services.AddScoped<IEstadoRepresentanteService, EstadoRepresentanteService>();
builder.Services.AddScoped<IGestionReporteInspeccionService, GestionReporteInspeccionService>();
builder.Services.AddScoped<IMunicipioInstalacionService, MunicipioInstalacionService>();
builder.Services.AddScoped<IOrganismoService, OrganismoService>();
builder.Services.AddScoped<IRepresentanteService, RepresentanteService>();
builder.Services.AddScoped<IRequisitoMayorService, RequisitoMayorService>();
builder.Services.AddScoped<IRequisitoMenorService, RequisitoMenorService>();

builder.Services.AddScoped<TituloService>();

builder.Services.AddSweetAlert2();
builder.Services.AddBlazoredModal();

await builder.Build().RunAsync();
