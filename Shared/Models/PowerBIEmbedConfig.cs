using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.PowerBI.Api.Models;

namespace Oqtane.PowerBIViewer.Shared.Models
{
    public class PowerBIEmbedConfig
    {
        public string Id { get; set; }
        public string EmbedUrl { get; set; }
        public EmbedToken EmbedToken { get; set; }

        public int MinutesToExpiration
        {
            get
            {
                var minutesToExpiration = EmbedToken.Expiration - DateTime.UtcNow;
                return minutesToExpiration.Minutes;
            }
        }
    }
}
