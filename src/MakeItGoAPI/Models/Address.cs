using System.Collections.Generic;

namespace MakeItGoAPI.Models {
    public class Address {
 
        public long AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public string Zip { get; set; }
        public int? DoctorId { get; set; }
        public  Doctor  Doctor { get; set; }
    }
}