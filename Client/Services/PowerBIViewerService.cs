using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using Oqtane.PowerBIViewer.Models;

namespace Oqtane.PowerBIViewer.Services
{
    public class PowerBIViewerService : ServiceBase, IPowerBIViewerService, IService
    {
        public PowerBIViewerService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("PowerBIViewer");

        public async Task<Models.PowerBIViewer> GetPowerBIViewerAsync(int ModuleId)
        {
            return await GetJsonAsync<Models.PowerBIViewer>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, ModuleId));
        }        
    }
}
