using mftracker_ws.Model;
using mftracker_ws.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mftracker_ws.Repository
{
    public interface IAmcRepository
    {
        IEnumerable<IAmc> GetAllAmcs();

        IAmc GetAmcById(int id);
    }
}
