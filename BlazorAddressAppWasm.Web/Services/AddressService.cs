
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

        public async Task<List<AddressDTO>> GetAddresses() => await _httpClient.GetFromJsonAsync<List<AddressDTO>>("api/addresses");

        public async Task<AddressDTO> GetAddress(Guid id) => await _httpClient.GetFromJsonAsync<AddressDTO>($"api/addresses/{id}");

        public async Task<ResultDTO> AddAddress(AddressDTO addressDTO)
        {
            ResultDTO resultDTO = new ResultDTO();
            StringContent? content = new StringContent(JsonSerializer.Serialize(addressDTO), Encoding.UTF8, "application/json");
            using HttpResponseMessage? response = await _httpClient.PostAsync("api/addresses", content);

            resultDTO.StatusCode = response.StatusCode;
            return resultDTO;
        }

        public async Task<ResultDTO> UpdateAddress(AddressDTO addressDTO)
        {
            ResultDTO resultDTO = new ResultDTO();
            StringContent? content = new StringContent(JsonSerializer.Serialize(addressDTO), Encoding.UTF8, "application/json");
            //using HttpResponseMessage? response = await _httpClient.PutAsync("api/addresses", content);
            using HttpResponseMessage? response = await _httpClient.PutAsync("api/addresses", content);
            resultDTO.StatusCode = response.StatusCode;
            return resultDTO;
        }

        public async Task<ResultDTO> DeleteAddress(Guid id)
        {
            ResultDTO resultDTO = new ResultDTO();


            using HttpResponseMessage? response = await _httpClient.DeleteAsync("api/addresses" + id);

            resultDTO.StatusCode = response.StatusCode;
            return resultDTO;
        }
    }
}
