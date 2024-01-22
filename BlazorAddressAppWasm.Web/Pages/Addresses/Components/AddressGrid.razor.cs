

using BlazorAddressAppWasm.ClassLibrary.ViewModels;
using BlazorAddressAppWasm.Web.BaseClasses;
using BlazorAddressAppWasm.Web.ServiceManager;
using Microsoft.AspNetCore.Components;


namespace BlazorAddressAppWasm.Web.Pages.Addresses.Components
{
    public partial class AddressGrid : CommonBase, IDisposable
    {
        private List<AddressViewModel> _addressList { get; set; }

        [Parameter]
        public AddressServiceManager AddressServiceManager { get; set; }

        public AddressGrid()
        {
            _addressList = new List<AddressViewModel>();
        }

        private void OnAddressesLoaded(List<AddressViewModel> addressList)
        {
            _addressList = addressList;
            StateHasChanged();
        }


        public void EditAddress(Guid id)
        {
            NavigationManager.NavigateTo($"/addressedit/{id}");
        }


        public void DeleteAddress(Guid id)
        {

        }

        protected override void OnInitialized()
        {
            AddressServiceManager.AddressesLoaded += OnAddressesLoaded;
        }


        public void Dispose()
        {
            AddressServiceManager.AddressesLoaded -= OnAddressesLoaded;
        }
    }
}
