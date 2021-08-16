using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Chemical :Product
    {
        public string LabName { get; set; }
        //public string City { get; set; }
        //public string StreetAddress { get; set; }
        public Adress LabAddress { get; set; }

    }
}
