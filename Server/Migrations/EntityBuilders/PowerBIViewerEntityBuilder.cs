using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace Oqtane.PowerBIViewer.Migrations.EntityBuilders
{
    public class PowerBIViewerEntityBuilder : AuditableBaseEntityBuilder<PowerBIViewerEntityBuilder>
    {
        private const string _entityTableName = "OqtanePowerBIViewer";
        private readonly PrimaryKey<PowerBIViewerEntityBuilder> _primaryKey = new("PK_OqtanePowerBIViewer", x => x.PowerBIViewerId);
        private readonly ForeignKey<PowerBIViewerEntityBuilder> _moduleForeignKey = new("FK_OqtanePowerBIViewer_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public PowerBIViewerEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override PowerBIViewerEntityBuilder BuildTable(ColumnsBuilder table)
        {
            PowerBIViewerId = AddAutoIncrementColumn(table,"PowerBIViewerId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> PowerBIViewerId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
