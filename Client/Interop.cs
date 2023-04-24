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
           bool isEdit,
           string accessToken,
           string embedUrl,
           string embedReportId)
        {
                return _jsRuntime.InvokeAsync<object>(
                "PowerBIViewer.showReport",
                reportContainer, isEdit, accessToken, embedUrl,
                embedReportId);
        }

    }
}
