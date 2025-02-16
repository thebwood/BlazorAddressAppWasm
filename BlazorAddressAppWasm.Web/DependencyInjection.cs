using BlazorAddressAppWasm.Web.Common;
using BlazorAddressAppWasm.Web.ViewModels;
using BlazorAddressAppWasm.Web.ViewModels.Interfaces;
using Microsoft.Extensions.Options;
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

            // Add HttpClient with retry policy and exception handling
            services.AddHttpClient<IAddressClient, AddressClient>((serviceProvider, client) => {
                ApiSettings? apiSettings = serviceProvider.GetRequiredService<IOptions<ApiSettings>>().Value;
                client.BaseAddress = new Uri(baseAddress);

            })
                .AddPolicyHandler(retryPolicy); // Attach the retry policy

            services.AddSingleton<UIStateViewModel>();
            services.AddTransient<AddressesViewModel>();
            services.AddTransient<AddressDetailViewModel>();

            // Register the custom DelegatingHandler
            services.AddTransient<ExceptionMiddleware>();

            return services;
        }
    }
    public class ExceptionMiddleware : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await base.SendAsync(request, cancellationToken);
                response.EnsureSuccessStatusCode();
                return response;
            }
            catch (HttpRequestException ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("An error occurred while sending the request.", ex);
            }
        }
    }
}
