using BlazorAddressAppWasm.ClassLibrary.Common;
using BlazorAddressAppWasm.ClassLibrary.DTOs;
using BlazorAddressAppWasm.ClassLibrary.Models;
using BlazorAddressAppWasm.Web.Mappers;
using BlazorAddressAppWasm.Web.ViewModels.Interfaces;

namespace BlazorAddressAppWasm.Web.ViewModels
{
    public class AddressDetailViewModel
    {
        private readonly IAddressClient _addressService;

        public AddressDetailViewModel(IAddressClient addressService)
        {
            _addressService = addressService;
        }

        public async Task GetAddress(Guid id)
        {
            Result<GetAddressResponseDTO>? response = await _addressService.GetAddress(id);

            if (response == null || response.Value == null)
            {
                AddressLoaded?.Invoke(null);
                return;
            }
            AddressLoaded?.Invoke(AddressMapper.MapToAddressModel(response.Value.Address));
        }

        public async Task CreateAddress(AddressModel address)
        {
            var addressDTO = new GetAddressResponseDTO
            {
                Address = new AddressDTO
                {
                    Id = address.Id,
                    StreetAddress = address.StreetAddress,
                    StreetAddress2 = address.StreetAddress2,
                    City = address.City,
                    State = address.State,
                    PostalCode = address.PostalCode
                }
            };
            var result = await _addressService.AddAddress(addressDTO);
            AddressCreated?.Invoke(result.Success);
        }

        public async Task UpdateAddress(AddressModel address)
        {
            var addressDTO = new GetAddressResponseDTO
            {
                Address = new AddressDTO
                {
                    Id = address.Id,
                    StreetAddress = address.StreetAddress,
                    StreetAddress2 = address.StreetAddress2,
                    City = address.City,
                    State = address.State,
                    PostalCode = address.PostalCode
                }
            };
            var result = await _addressService.UpdateAddress(addressDTO);
            AddressUpdated?.Invoke(result.Success);
        }

        public Action<AddressModel>? AddressLoaded { get; set; }
        public Action<bool>? AddressCreated { get; set; }
        public Action<bool>? AddressUpdated { get; set; }
    }
}
