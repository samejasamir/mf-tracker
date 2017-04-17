using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using mftracker_ws.Model.Interface;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace mftracker_ws.Model
{
    [Table("amc")]
    public class Amc : IAmc
    {        
        public int AmcID { get; set; }        
        public string AmcName { get; set; }

        public List<Scheme> Schemes { get; set; } = new List<Scheme>();
    }
}
