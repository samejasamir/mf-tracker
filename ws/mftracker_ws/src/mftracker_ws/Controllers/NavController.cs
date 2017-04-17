using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mftracker_ws.Repository;
using mftracker_ws.Model.Interface;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace mftracker_ws.Controllers
{
    [Route("api/[controller]")]
    public class NavController : Controller
    {
        private readonly INavRepository _navRepository = null;

        public NavController(INavRepository navRepos)
        {
            _navRepository = navRepos;
        }

        // GET: api/values
        [HttpGet("{schemeid}")]
        public INav Get(int schemeid)
        {
            return _navRepository.GetLastestNav(schemeid);
        }

        // GET api/values/5
        [HttpGet("{schemeid}/{date}")]
        public INav Get(int schemeid, string date)
        {
            return _navRepository.GetNav(schemeid, date);
        }

    }
}
