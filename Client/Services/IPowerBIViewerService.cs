using System.Collections.Generic;
using System.Threading.Tasks;
using Oqtane.PowerBIViewer.Models;

namespace Oqtane.PowerBIViewer.Services
{
    public interface IPowerBIViewerService 
    {
        Task<List<Models.PowerBIViewer>> GetPowerBIViewersAsync(int ModuleId);

        Task<Models.PowerBIViewer> GetPowerBIViewerAsync(int PowerBIViewerId, int ModuleId);

        Task<Models.PowerBIViewer> AddPowerBIViewerAsync(Models.PowerBIViewer PowerBIViewer);

        Task<Models.PowerBIViewer> UpdatePowerBIViewerAsync(Models.PowerBIViewer PowerBIViewer);

        Task DeletePowerBIViewerAsync(int PowerBIViewerId, int ModuleId);
    }
}
