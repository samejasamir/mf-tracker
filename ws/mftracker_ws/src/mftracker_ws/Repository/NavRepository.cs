using mftracker_ws.DatabaseContext;
using mftracker_ws.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace mftracker_ws.Repository
{
    public class NavRepository : INavRepository
    {
        private MutualFundContext _dbContext;

        public NavRepository(MutualFundContext dbContext)
        {
            _dbContext = dbContext;
        }

        public INav GetLastestNav(int schemeId)
        {
            return _dbContext.Navs
                .Where(w => w.SchemeID == schemeId)
                .OrderByDescending(o => o.NavDate)
                .Include(s=>s.Scheme)
                .FirstOrDefault();
        }

        public INav GetNav(int schemeId, string date)
        {
            return _dbContext.Navs
                .Include(s => s.Scheme)
                .FirstOrDefault(o => o.NavDate == DateTime.Parse(date) 
                && o.SchemeID == schemeId);
        }
    }
}
