using BlazorAddressAppWasm.Web.BaseClasses;
using BlazorAddressAppWasm.Web.ServiceManager;
using Microsoft.AspNetCore.Components;

namespace BlazorAddressAppWasm.Web.Pages.CreateAddress
{
    public partial class CreateAddress : CommonBase
    {
        [Inject]

        private AddressServiceManager AddresServiceManager { get; set; }

    }
}
