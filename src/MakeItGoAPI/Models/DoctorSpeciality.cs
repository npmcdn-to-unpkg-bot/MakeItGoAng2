using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeItGoAPI.Models
{
    public class DoctorSpeciality {
        public long DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public long SpecialityId { get; set; }
        public Speciality Speciality { get; set; }
    }
}
