using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mftracker_ws.Model.Interface
{
    public interface IScheme
    {
        int SchemeID { get; set; }

        int AmcID { get; set; }

        string SchemeName { get; set; }

        string SchemeISIN { get; set; }

        string SchemeCode { get; set; }

        string SchemeType { get; set; }

        //List<Nav> Navs { get; set; }
    }
}
