using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using Oqtane.Repository;
using Oqtane.PowerBIViewer.Repository;

namespace Oqtane.PowerBIViewer.Manager
{
    public class PowerBIViewerManager : MigratableModuleBase, IInstallable, IPortable
    {
        private readonly IPowerBIViewerRepository _PowerBIViewerRepository;
        private readonly IDBContextDependencies _DBContextDependencies;

        public PowerBIViewerManager(IPowerBIViewerRepository PowerBIViewerRepository, IDBContextDependencies DBContextDependencies)
        {
            _PowerBIViewerRepository = PowerBIViewerRepository;
            _DBContextDependencies = DBContextDependencies;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new PowerBIViewerContext(_DBContextDependencies), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new PowerBIViewerContext(_DBContextDependencies), tenant, MigrationType.Down);
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.PowerBIViewer> PowerBIViewers = _PowerBIViewerRepository.GetPowerBIViewers(module.ModuleId).ToList();
            if (PowerBIViewers != null)
            {
                content = JsonSerializer.Serialize(PowerBIViewers);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.PowerBIViewer> PowerBIViewers = null;
            if (!string.IsNullOrEmpty(content))
            {
                PowerBIViewers = JsonSerializer.Deserialize<List<Models.PowerBIViewer>>(content);
            }
            if (PowerBIViewers != null)
            {
                foreach(var PowerBIViewer in PowerBIViewers)
                {
                    _PowerBIViewerRepository.AddPowerBIViewer(new Models.PowerBIViewer { ModuleId = module.ModuleId, Name = PowerBIViewer.Name });
                }
            }
        }
    }
}
