using System.Collections.Generic;
using Oqtane.PowerBIViewer.Models;

namespace Oqtane.PowerBIViewer.Repository
{
    public interface IPowerBIViewerRepository
    {
        IEnumerable<Models.PowerBIViewer> GetPowerBIViewers(int ModuleId);
        Models.PowerBIViewer GetPowerBIViewer(int PowerBIViewerId);
        Models.PowerBIViewer GetPowerBIViewer(int PowerBIViewerId, bool tracking);
        Models.PowerBIViewer AddPowerBIViewer(Models.PowerBIViewer PowerBIViewer);
        Models.PowerBIViewer UpdatePowerBIViewer(Models.PowerBIViewer PowerBIViewer);
        void DeletePowerBIViewer(int PowerBIViewerId);
    }
}
