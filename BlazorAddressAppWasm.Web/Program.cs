using BlazorAddressAppWasm.Web;
using BlazorAddressAppWasm.Web.ViewModels;
using BlazorAddressAppWasm.Web.ViewModels.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Polly;
using Polly.Extensions.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddPresentation(builder.HostEnvironment.BaseAddress);

await builder.Build().RunAsync();
