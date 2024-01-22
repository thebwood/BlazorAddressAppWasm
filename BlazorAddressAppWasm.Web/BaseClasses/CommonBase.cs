using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorAddressAppWasm.Web.BaseClasses
{
    public class CommonBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public JSRuntime JScript { get; set; }

        public async void ConsoleLog(string message)
        {
            await JScript.InvokeVoidAsync("console.log", message);
        }


        public async void ConsoleError(string message)
        {
            await JScript.InvokeVoidAsync("console.error", message);
        }

        public async void ConsoleWarn(string message)
        {
            await JScript.InvokeVoidAsync("console.warn", message);
        }

        public async void ConsoleInfo(string message)
        {
            await JScript.InvokeVoidAsync("console.info", message);
        }

    }
}
