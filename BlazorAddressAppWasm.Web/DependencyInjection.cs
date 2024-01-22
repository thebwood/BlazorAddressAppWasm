using BlazorAddressAppWasm.Web.Services;
using BlazorAddressAppWasm.Web.Services.Interfaces;
using BlazorAddressAppWasm.Web.StateManagement;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace BlazorAddressAppWasm.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, string baseAddress)
        {
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });

            AsyncRetryPolicy<HttpResponseMessage> retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
            services.AddHttpClient<IAddressService, AddressService>()
                .AddPolicyHandler(retryPolicy);


            services.AddScoped<AddressStateManager>();
            return services;
        }
    }
}
