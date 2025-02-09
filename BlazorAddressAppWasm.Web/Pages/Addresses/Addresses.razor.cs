using BlazorAddressAppWasm.Web.BaseClasses;
using BlazorAddressAppWasm.Web.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BlazorAddressAppWasm.Web.Pages.Addresses
{
    public partial class Addresses : CommonBase
    {
        [Inject]
        private AddressesViewModel AddressesViewModel { get; set; }

        [Inject]
        private ILogger<Addresses> Logger { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await AddressesViewModel.GetAddresses();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while fetching addresses.");
                // Optionally, you can show a user-friendly message or handle the error accordingly
            }
        }
    }
}
