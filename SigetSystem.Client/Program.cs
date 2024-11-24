using Blazored.LocalStorage;
using Blazored.Modal;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Radzen;
using SigetSystem.Client;
using SigetSystem.Client.Services.Interfaces;
using SigetSystem.Client.Services.Servicios;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

builder.Services.AddHttpClient("ApiSiget", options => 
{
    options.BaseAddress = new Uri("https://localhost:7284/");

}).AddHttpMessageHandler<CustomHttpHandler>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7284") });

builder.Services.AddScoped<ICodigoConformidadService, CodigoConformidadService>();
builder.Services.AddScoped<ICodigoSigetService, CodigoSigetService>();
builder.Services.AddScoped<IComentarioInconformidadService, ComentarioInconformidadService>();
builder.Services.AddScoped<IComentarioSigetService, ComentarioSigetService>();
builder.Services.AddScoped<IDepartamentoInstalacionService, DepartamentoInstalacionService>();
builder.Services.AddScoped<IEstadoAcreditacionService, EstadoAcreditacionService>();
builder.Services.AddScoped<IEstadoComentarioService, EstadoComentarioService>();
builder.Services.AddScoped<IEstadoPersonalService, EstadoPersonalService>();
builder.Services.AddScoped<IEstadoReporteService, EstadoReporteService>();
builder.Services.AddScoped<IEstadoRepresentanteService, EstadoRepresentanteService>();
builder.Services.AddScoped<IMunicipioInstalacionService, MunicipioInstalacionService>();
builder.Services.AddScoped<IOrganismoService, OrganismoService>();
builder.Services.AddScoped<IPersonalService, PersonalService>();
builder.Services.AddScoped<IRangoPersonalService, RangoPersonalService>();
builder.Services.AddScoped<IReporteInspeccionService, ReporteInspeccionService>();
builder.Services.AddScoped<IRepresentanteService, RepresentanteService>();
builder.Services.AddScoped<IRequisitoMayorService, RequisitoMayorService>();
builder.Services.AddScoped<IRequisitoMenorService, RequisitoMenorService>();
builder.Services.AddScoped<ITipoConformidadService, TipoConformidadService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddSingleton<IHubRegistroService ,HubRegistroService>();
builder.Services.AddSingleton<IHubActualizacionService, HubActualizacionService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped<TituloService>();
builder.Services.AddScoped<UsuarioService>();


//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

builder.Services.AddSweetAlert2();
builder.Services.AddBlazoredModal();
builder.Services.AddRadzenComponents();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomHttpHandler>();

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

await builder.Build().RunAsync();
