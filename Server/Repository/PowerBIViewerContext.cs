using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;
using Microsoft.PowerBI.Api.Models;

namespace Oqtane.PowerBIViewer.Repository
{
    public class PowerBIViewerContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.PowerBIViewer> PowerBIViewer { get; set; }

        public PowerBIViewerContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure EmbedToken as a keyless entity
            modelBuilder.Entity<EmbedToken>().HasNoKey();
        }
    }
}
