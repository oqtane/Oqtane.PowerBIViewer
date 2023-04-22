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

        public async Task<List<Models.PowerBIViewer>> GetPowerBIViewersAsync(int ModuleId)
        {
            List<Models.PowerBIViewer> PowerBIViewers = await GetJsonAsync<List<Models.PowerBIViewer>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId));
            return PowerBIViewers.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.PowerBIViewer> GetPowerBIViewerAsync(int PowerBIViewerId, int ModuleId)
        {
            return await GetJsonAsync<Models.PowerBIViewer>(CreateAuthorizationPolicyUrl($"{Apiurl}/{PowerBIViewerId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.PowerBIViewer> AddPowerBIViewerAsync(Models.PowerBIViewer PowerBIViewer)
        {
            return await PostJsonAsync<Models.PowerBIViewer>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, PowerBIViewer.ModuleId), PowerBIViewer);
        }

        public async Task<Models.PowerBIViewer> UpdatePowerBIViewerAsync(Models.PowerBIViewer PowerBIViewer)
        {
            return await PutJsonAsync<Models.PowerBIViewer>(CreateAuthorizationPolicyUrl($"{Apiurl}/{PowerBIViewer.PowerBIViewerId}", EntityNames.Module, PowerBIViewer.ModuleId), PowerBIViewer);
        }

        public async Task DeletePowerBIViewerAsync(int PowerBIViewerId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{PowerBIViewerId}", EntityNames.Module, ModuleId));
        }
    }
}
