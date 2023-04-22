using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.PowerBIViewer.Migrations.EntityBuilders;
using Oqtane.PowerBIViewer.Repository;

namespace Oqtane.PowerBIViewer.Migrations
{
    [DbContext(typeof(PowerBIViewerContext))]
    [Migration("Oqtane.PowerBIViewer.01.00.00.00")]
    public class InitializeModule : MultiDatabaseMigration
    {
        public InitializeModule(IDatabase database) : base(database)
        {
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new PowerBIViewerEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Create();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new PowerBIViewerEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Drop();
        }
    }
}
