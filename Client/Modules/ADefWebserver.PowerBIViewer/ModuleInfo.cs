using Oqtane.Models;
using Oqtane.Modules;

namespace Oqtane.PowerBIViewer
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "PowerBIViewer",
            Description = "PowerBIViewer",
            Version = "1.0.0",
            ServerManagerType = "Oqtane.PowerBIViewer.Manager.PowerBIViewerManager, Oqtane.PowerBIViewer.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "Oqtane.PowerBIViewer.Shared.Oqtane",
            PackageName = "Oqtane.PowerBIViewer" 
        };
    }
}
