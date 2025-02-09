using BlazorAddressAppWasm.Web.ViewModels.Interfaces;

namespace BlazorAddressAppWasm.Web.ViewModels
{
    public class AddressViewModel
    {
        private readonly IAddressClient _addressService;


        public AddressViewModel(IAddressClient addressService)
        {
            _addressService = addressService;
        }

    }
}
