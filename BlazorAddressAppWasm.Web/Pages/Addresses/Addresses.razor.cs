using BlazorAddressAppWasm.Web.BaseClasses;
using BlazorAddressAppWasm.Web.ServiceManager;
using Microsoft.AspNetCore.Components;

namespace BlazorAddressAppWasm.Web.Pages.Addresses
{
    public partial class Addresses : CommonBase
    {
        [Inject]

        private AddressServiceManager AddresServiceManager { get; set; }

        protected override async void OnInitialized()
        {
            await AddresServiceManager.GetAddresses();
        }

    }
}
