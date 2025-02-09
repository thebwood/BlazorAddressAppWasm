using BlazorAddressAppWasm.ClassLibrary.DTOs;
using BlazorAddressAppWasm.ClassLibrary.Models;
using BlazorAddressAppWasm.Web.ViewModels.Interfaces;

namespace BlazorAddressAppWasm.Web.ViewModels
{
    public class AddressesViewModel
    {
        private readonly IAddressClient _addressService;

        public AddressesViewModel(IAddressClient addressService)
        {
            _addressService = addressService;
        }

        public async Task GetAddresses()
        {
            try
            {
                GetAddressesResponseDTO response = await _addressService.GetAddresses();
                List<AddressModel> addressViewModels = response.AddressList.Select(dto => MapToAddressModel(dto)).ToList();
                OnAddressesLoaded(addressViewModels);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error, show a message to the user, etc.)
                Console.WriteLine($"Error fetching addresses: {ex.Message}");
            }
        }

        private AddressModel MapToAddressModel(AddressDTO dto)
        {
            return new AddressModel
            {
                Id = dto.Id ?? Guid.Empty, // Handle nullable Guid
                StreetAddress = dto.StreetAddress,
                StreetAddress2 = dto.StreetAddress2,
                City = dto.City,
                State = dto.State,
                PostalCode = dto.PostalCode
            };
        }

        public Action<List<AddressModel>>? AddressesLoaded;

        protected virtual void OnAddressesLoaded(List<AddressModel> addresses)
        {
            AddressesLoaded?.Invoke(addresses);
        }
    }
}
