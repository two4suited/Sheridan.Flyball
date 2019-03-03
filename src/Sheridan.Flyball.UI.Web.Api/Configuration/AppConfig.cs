using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheridan.Flyball.UI.Web.Api.Configuration
{
    public class AppConfig
    {
        public bool MigrateDatabase { get; set; }
        public string AppClientId { get; set; }
        public string AuthorityURL { get; set; }
        public string PoolId { get; set; }
        public string AppClientSecret { get; set; }
    }
}
