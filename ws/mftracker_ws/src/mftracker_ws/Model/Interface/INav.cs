using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mftracker_ws.Model.Interface
{
    public interface INav
    {
        int NavID { get; set; }

        int SchemeID { get; set; }

        DateTime NavDate { get; set; }

        double NavValue { get; set; }

        double NavRepurchase { get; set; }

        double NavSale { get; set; }
    }
}
