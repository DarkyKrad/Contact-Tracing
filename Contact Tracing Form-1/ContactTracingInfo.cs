using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Tracing_Form_1
{
    class ContactTracingInfo
    {
        public string FullName { get; set; }
        public DateTime DToV { get; set; }
        public string CompleteAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string Temperature { get; set; }
        public string RoV { get; set; }
        public bool Question1 { get; set; }
        public bool Question2 { get; set; }
        public bool Question3 { get; set; }
        public bool Question4 { get; set; }

    }
}
