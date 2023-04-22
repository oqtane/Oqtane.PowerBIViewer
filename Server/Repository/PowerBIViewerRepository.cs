using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using Oqtane.PowerBIViewer.Models;

namespace Oqtane.PowerBIViewer.Repository
{
    public class PowerBIViewerRepository : IPowerBIViewerRepository, ITransientService
    {
        private readonly PowerBIViewerContext _db;

        public PowerBIViewerRepository(PowerBIViewerContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.PowerBIViewer> GetPowerBIViewers(int ModuleId)
        {
            return _db.PowerBIViewer.Where(item => item.ModuleId == ModuleId);
        }

        public Models.PowerBIViewer GetPowerBIViewer(int PowerBIViewerId)
        {
            return GetPowerBIViewer(PowerBIViewerId, true);
        }

        public Models.PowerBIViewer GetPowerBIViewer(int PowerBIViewerId, bool tracking)
        {
            if (tracking)
            {
                return _db.PowerBIViewer.Find(PowerBIViewerId);
            }
            else
            {
                return _db.PowerBIViewer.AsNoTracking().FirstOrDefault(item => item.PowerBIViewerId == PowerBIViewerId);
            }
        }

        public Models.PowerBIViewer AddPowerBIViewer(Models.PowerBIViewer PowerBIViewer)
        {
            _db.PowerBIViewer.Add(PowerBIViewer);
            _db.SaveChanges();
            return PowerBIViewer;
        }

        public Models.PowerBIViewer UpdatePowerBIViewer(Models.PowerBIViewer PowerBIViewer)
        {
            _db.Entry(PowerBIViewer).State = EntityState.Modified;
            _db.SaveChanges();
            return PowerBIViewer;
        }

        public void DeletePowerBIViewer(int PowerBIViewerId)
        {
            Models.PowerBIViewer PowerBIViewer = _db.PowerBIViewer.Find(PowerBIViewerId);
            _db.PowerBIViewer.Remove(PowerBIViewer);
            _db.SaveChanges();
        }
    }
}
