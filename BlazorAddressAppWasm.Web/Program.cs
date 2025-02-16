using BlazorAddressAppWasm.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddPresentation(builder.HostEnvironment.BaseAddress);
builder.Services.AddMudServices();

await builder.Build().RunAsync();
