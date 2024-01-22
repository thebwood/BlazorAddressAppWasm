using BlazorAddressAppWasm.ClassLibrary.DTOs;
using BlazorAddressAppWasm.ClassLibrary.ViewModels;
using BlazorAddressAppWasm.Web.Pages.Addresses;
using BlazorAddressAppWasm.Web.Services.Interfaces;

namespace BlazorAddressAppWasm.Web.ServiceManager
{
    public class AddressServiceManager
    {
        private readonly IAddressService _addressService;


        public AddressServiceManager(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task GetAddresses()
        {
            GetAddressesResponseDTO response = await _addressService.GetAddresses();
            AddressesLoaded?.Invoke(response.AddressList);
        }

        public async Task GetAddress(Guid id)
        {
            GetAddressResponseDTO response =  await _addressService.GetAddress(id);
            AddressLoaded?.Invoke(response.AddressDetail);
        }


        public Action<List<AddressViewModel>>? AddressesLoaded { get; set; }

        public Action<AddressViewModel>? AddressLoaded { get; set; }
    }
}
