using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.PowerBI.Api.Models;
using Oqtane.Models;

namespace Oqtane.PowerBIViewer.Models
{
    [Table("OqtanePowerBIViewer")]
    public class PowerBIViewer : IAuditable
    {
        [Key]
        public int PowerBIViewerId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string ReportId { get; set; }
        public string AuthToken { get; set; }
        public string EmbedUrl { get; set; }
        public EmbedToken EmbedToken { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
