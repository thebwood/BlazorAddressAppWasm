
using BlazorAddressAppWasm.ClassLibrary.Classes;
using BlazorAddressAppWasm.ClassLibrary.DTOs;
using BlazorAddressAppWasm.Web.Services.Interfaces;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace BlazorAddressAppWasm.Web.Services
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;

        public IConfiguration _configuration { get; }
        public AddressService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _httpClient.BaseAddress = new Uri(_configuration["AddressApiUrl"]);
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<GetAddressesResponseDTO> GetAddresses() => await _httpClient.GetFromJsonAsync<GetAddressesResponseDTO>("api/addresses");

        public async Task<GetAddressResponseDTO> GetAddress(Guid id) => await _httpClient.GetFromJsonAsync<GetAddressResponseDTO>($"api/addresses/{id}");

        public async Task<Result> AddAddress(GetAddressResponseDTO addressDTO)
        {
            Result resultDTO = new Result();
            StringContent? content = new StringContent(JsonSerializer.Serialize(addressDTO), Encoding.UTF8, "application/json");
            using HttpResponseMessage? response = await _httpClient.PostAsync("api/addresses", content);

            resultDTO.StatusCode = response.StatusCode;
            return resultDTO;
        }

        public async Task<Result> UpdateAddress(GetAddressResponseDTO addressDTO)
        {
            Result resultDTO = new Result();
            StringContent? content = new StringContent(JsonSerializer.Serialize(addressDTO), Encoding.UTF8, "application/json");
            //using HttpResponseMessage? response = await _httpClient.PutAsync("api/addresses", content);
            using HttpResponseMessage? response = await _httpClient.PutAsync("api/addresses", content);
            resultDTO.StatusCode = response.StatusCode;
            return resultDTO;
        }

        public async Task<Result> DeleteAddress(Guid id)
        {
            Result resultDTO = new Result();


            using HttpResponseMessage? response = await _httpClient.DeleteAsync("api/addresses" + id);

            resultDTO.StatusCode = response.StatusCode;
            return resultDTO;
        }
    }
}
