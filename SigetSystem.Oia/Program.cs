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

await builder.Build().RunAsync();
