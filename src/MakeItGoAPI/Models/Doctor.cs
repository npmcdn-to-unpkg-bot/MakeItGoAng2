using System.Collections.Generic;

namespace MakeItGoAPI.Models {
    
    public class Doctor {
        public long DoctorId { get; set; }
        public string Title { get; set; } 
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<DoctorSpeciality> DoctorSpecialities { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
