using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mftracker_ws.Model.Interface
{
    public interface IAmc
    {
        int AmcID { get; set; }
        string AmcName { get; set; }

        //List<Scheme> Schemes { get; set; }
    }
}
