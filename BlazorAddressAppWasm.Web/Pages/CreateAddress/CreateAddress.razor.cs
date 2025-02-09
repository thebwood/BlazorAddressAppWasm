using BlazorAddressAppWasm.Web.BaseClasses;
using BlazorAddressAppWasm.Web.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BlazorAddressAppWasm.Web.Pages.CreateAddress
{
    public partial class CreateAddress : CommonBase
    {
        [Inject]

        private AddressViewModel AddressViewModel { get; set; }

    }
}
