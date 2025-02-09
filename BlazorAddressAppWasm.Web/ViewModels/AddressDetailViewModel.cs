using BlazorAddressAppWasm.ClassLibrary.DTOs;
using BlazorAddressAppWasm.ClassLibrary.Models;
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
            GetAddressResponseDTO response = await _addressService.GetAddress(id);
            AddressLoaded?.Invoke(response.AddressDetail);
        }



        public Action<AddressModel>? AddressLoaded { get; set; }

    }
}
