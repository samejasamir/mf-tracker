using mftracker_ws.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mftracker_ws.Repository
{
    public interface INavRepository
    {
        INav GetLastestNav(int schemeId);

        INav GetNav(int schemeId, string date);
    }
}
