using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mftracker_ws.Repository;
using mftracker_ws.Model.Interface;
using mftracker_ws.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace mftracker_ws.Controllers
{
    [Route("api/[controller]")]
    public class AmcController : Controller
    {
        private readonly IAmcRepository _repository;

        public AmcController(IAmcRepository repository)
        {
            _repository = repository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<IAmc> Get()
        {
            return _repository.GetAllAmcs();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IAmc Get(int id)
        {
            return _repository.GetAmcById(id);
        }
    }
}
