using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Oqtane.PowerBIViewer
{
    public class Interop
    {
        private readonly IJSRuntime _jsRuntime;

        public Interop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        internal ValueTask<object> CreateReport(
           ElementReference reportContainer,
           string accessToken,
           string embedUrl,
           string embedReportId)
        {
                return _jsRuntime.InvokeAsync<object>(
                "Oqtane.PowerBIViewer.showReport",
                reportContainer, false, accessToken, embedUrl,
                embedReportId);
        }

    }
}
