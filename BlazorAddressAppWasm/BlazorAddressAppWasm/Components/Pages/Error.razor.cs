using BlazorAddressAppWasm.ClassLibrary.BaseClasses;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace BlazorAddressAppWasm.Server.Components.Pages
{
    public partial class Error : CommonBase
    {
        [CascadingParameter]
        private HttpContext? HttpContext { get; set; }

        private string? RequestId { get; set; }
        private bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        protected override void OnInitialized() =>
            RequestId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;

    }
}
