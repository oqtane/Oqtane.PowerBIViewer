using System.Collections.Generic;
using System.Threading.Tasks;
using Oqtane.PowerBIViewer.Models;

namespace Oqtane.PowerBIViewer.Services
{
    public interface IPowerBIViewerService 
    {
        Task<Models.PowerBIViewer> GetPowerBIViewerAsync(int ModuleId);
    }
}
