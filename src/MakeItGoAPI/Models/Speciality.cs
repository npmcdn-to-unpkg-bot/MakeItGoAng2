using System.Collections.Generic;

namespace MakeItGoAPI.Models {
    public class Speciality {
        public long SpecialityId { get; set; }
        public string SpecialityName { get; set; }
        public List<DoctorSpeciality> DoctorSpecialities { get; set; }
    }
}