using BlazorCrud.client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorCrud.client.Services;
using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5086") });

builder.Services.AddScoped<IMovimientoService, MovimientoService>();
builder.Services.AddScoped<ITarjetaService,TarjetaService>();
builder.Services.AddScoped<ITitularService, TitularService>();
builder.Services.AddScoped<ITransaccionService, TransaccionService>();
builder.Services.AddSweetAlert2();


await builder.Build().RunAsync();
