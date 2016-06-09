using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MakeItGoAPI.Models;
using MakeItGoAPI.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MakeItGoAPI.Controllers
{
    [Route("api/doctor")]
    public class DoctorsController : Controller
    { 
        //private DataContext _context; 
       private readonly ILogger<DoctorsController> _logger;
        ////   [FromServices]
        private DoctorRepository _repository;
 
        public DoctorsController(DoctorRepository repository, ILogger<DoctorsController> logger) {
            _logger = logger;
            _repository = repository; 
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Doctor> Get()
        {
          return  _repository.GetAll();
         
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Doctor Get(int id)
        {
           return _repository.Get(id);
        }

        [HttpPost]
        public  void Post([FromBody]Doctor p) {
              _repository.Add(p);
            
        }


        [HttpPut("{id}")]
        public  void Put(int id, [FromBody]Doctor p) {
              _repository.Update(id, p);
        }

        [HttpDelete("{id}")]
        public Doctor Delete(int id) {
             return _repository.Delete(id);
        }
    }
}
