using BlazorAddressAppWasm.ClassLibrary.DTOs;
using BlazorAddressAppWasm.Web.ViewModels.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using BlazorAddressAppWasm.ClassLibrary.Common;

namespace BlazorAddressAppWasm.Web.ViewModels
{
    public class AddressClient : IAddressClient
    {
        private readonly HttpClient _httpClient;
        public IConfiguration _configuration { get; }

        public AddressClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<Result<GetAddressesResponseDTO>> GetAddresses()
        {
            var response = await _httpClient.GetFromJsonAsync<GetAddressesResponseDTO>("api/Addresses");
            return new Result<GetAddressesResponseDTO>(response, true, Error.None);
        }

        public async Task<Result<GetAddressResponseDTO>> GetAddress(Guid id)
        {
            var response = await _httpClient.GetFromJsonAsync<GetAddressResponseDTO>($"api/addresses/{id}");
            return new Result<GetAddressResponseDTO>(response, true, Error.None);
        }

        public async Task<Result> AddAddress(GetAddressResponseDTO addressDTO)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(addressDTO), Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await _httpClient.PostAsync("api/addresses", content);

            return new Result
            {
                StatusCode = response.StatusCode,
                Errors = response.IsSuccessStatusCode ? new List<Error> { Error.None } : new List<Error> { new Error("Error.AddAddress", response.ReasonPhrase) }
            };
        }

        public async Task<Result> UpdateAddress(GetAddressResponseDTO addressDTO)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(addressDTO), Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await _httpClient.PutAsync("api/addresses", content);

            return new Result
            {
                StatusCode = response.StatusCode,
                Errors = response.IsSuccessStatusCode ? new List<Error> { Error.None } : new List<Error> { new Error("Error.UpdateAddress", response.ReasonPhrase) }
            };
        }

        public async Task<Result> DeleteAddress(Guid id)
        {
            using HttpResponseMessage response = await _httpClient.DeleteAsync($"api/addresses/{id}");

            return new Result
            {
                StatusCode = response.StatusCode,
                Errors = response.IsSuccessStatusCode ? new List<Error> { Error.None } : new List<Error> { new Error("Error.DeleteAddress", response.ReasonPhrase) }
            };
        }
    }
}
