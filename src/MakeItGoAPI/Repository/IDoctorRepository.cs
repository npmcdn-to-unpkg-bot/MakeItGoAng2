using MakeItGoAPI.Controllers;
using MakeItGoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeItGoAPI.Repository {
    public class DoctorRepository :IRepository<Doctor, int> {

        private DataContext _context;
        private readonly ILogger<DoctorsController> _logger;
        public DoctorRepository(DataContext context, ILogger<DoctorsController> logger) {
            _logger = logger;
            _context = context;
        }

        public void Add(Doctor obj) {
            _context.Doctors.Add(obj);
            _context.SaveChanges();
        }

        public Doctor Delete(int id) {
            var d = _context.Doctors.FirstOrDefault(o => o.DoctorId == id);
            if(d != null) {
                _context.Doctors.Remove(d);
                _context.SaveChanges();
            }
            return d;
        }

        public Doctor Get(int id) {
            var d = _context.Doctors.FirstOrDefault(o => o.DoctorId == id);
            return (d != null) ? d : null;

        }

        public IEnumerable<Doctor> GetAll() {
            return _context.Doctors.ToList();

        }

        public void Update(int id, Doctor obj) {

            var d = _context.Doctors.Attach(obj);
            d.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

        }


    }
}
     