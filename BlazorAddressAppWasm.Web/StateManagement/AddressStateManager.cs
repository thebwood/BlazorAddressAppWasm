using BlazorAddressAppWasm.ClassLibrary.DTOs;
using BlazorAddressAppWasm.Web.Services.Interfaces;

namespace BlazorAddressAppWasm.Web.StateManagement
{
    public class AddressStateManager
    {
        private readonly IAddressService _addressService;
        public AddressStateManager(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<List<AddressDTO>> GetAddresses()
        {
            return await _addressService.GetAddresses();
        }

        public async Task<AddressDTO> GetAddress(Guid id)
        {
            return await _addressService.GetAddress(id);
        }
    }
}
