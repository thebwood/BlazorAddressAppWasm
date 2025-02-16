using BlazorAddressAppWasm.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace BlazorAddressAppWasm.Web.Layout
{
    public partial class MainLayout : LayoutComponentBase, IDisposable
    {
        [Inject]
        private UIStateViewModel _viewModel{ get; set; } = default!;

        private bool _drawerOpen = false;

        protected override async Task OnInitializedAsync()
        {
            _viewModel.PropertyChanged += OnPropertyChanged;
        }

        private async void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }

        private void ToggleDrawer()
        {
            _drawerOpen = !_drawerOpen;
        }

        public void Dispose()
        {
            _viewModel.PropertyChanged -= OnPropertyChanged;
        }
    }
}
