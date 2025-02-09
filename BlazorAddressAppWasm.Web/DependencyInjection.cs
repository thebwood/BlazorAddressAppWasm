using BlazorAddressAppWasm.Web.ViewModels;
using BlazorAddressAppWasm.Web.ViewModels.Interfaces;
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

            AsyncRetryPolicy<HttpResponseMessage>? retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError() // Handles 5xx and 408 errors
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt));

            // Add HttpClient with retry policy
            services.AddHttpClient<IAddressClient, AddressClient>()
                .AddPolicyHandler(retryPolicy); // Attach the retry policy


            services.AddTransient<AddressesViewModel>();
            services.AddTransient<AddressDetailViewModel>();


            return services;
        }
    }
}
