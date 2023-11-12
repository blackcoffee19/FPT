using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EmployeeWcf.Models
{
    [DataContract]
    public class EmployeeContact 
    {
        [DataMember]
        public string EmployeeId { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int? Age { get; set; }
    }
}