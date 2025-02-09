using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorAddressAppWasm.Web.BaseClasses
{
    public class CommonBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }


    }
}
