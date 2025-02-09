using BlazorAddressAppWasm.ClassLibrary.Models;
using BlazorAddressAppWasm.Web.BaseClasses;
using BlazorAddressAppWasm.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;


namespace BlazorAddressAppWasm.Web.Pages.Addresses.Components
{
    public partial class AddressGrid : CommonBase, IDisposable
    {
        [Parameter]
        public AddressesViewModel AddressesViewModel { get; set; }

        private List<AddressModel> _addresses = new();
        [Inject]
        public ILogger<AddressGrid> Logger { get; set; }

        protected override void OnInitialized()
        {

            AddressesViewModel.AddressesLoaded += OnAddressesLoaded;
        }

        private void OnAddressesLoaded(List<AddressModel> list)
        {
            _addresses = list ?? new();
            StateHasChanged();
        }

        public void Dispose()
        {
            AddressesViewModel.AddressesLoaded -= OnAddressesLoaded;
        }


        public void EditAddress(Guid id)
        {
            NavigationManager.NavigateTo($"/addresses/{id}");
        }

        public void DeleteAddress(Guid id)
        {
            // Implement delete functionality here
        }
    }
}
