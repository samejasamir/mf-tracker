using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mftracker_ws.ConfigManager
{
    public class Config
    {
        public readonly string ConnectionString = string.Empty;

        public Config(IConfiguration config)
        {
            ConnectionString = String.Format(config.GetConnectionString("mftrackerdb"), 
                config["dbservername"], 
                config["dbuserid"], 
                config["dbpassword"],
                config["dbname"]);
        }
    }
}
