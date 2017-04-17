using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mftracker_ws.Model.Interface;
using mftracker_ws.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace mftracker_ws.Repository
{
    public class AmcRepository : IAmcRepository
    {
        private readonly MutualFundContext _dbContext;

        public AmcRepository(MutualFundContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<IAmc> GetAllAmcs()
        {
            return _dbContext.Amcs;
        }

        public IAmc GetAmcById(int id)
        {
            return _dbContext.Amcs.Where(x => x.AmcID == id)
                .Include(y => y.Schemes)
                .FirstOrDefault();
        }
    }
}
