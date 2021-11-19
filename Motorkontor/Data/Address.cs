using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Motorkontor.Data
{
    public class Address
    {
        public int AdressId { get; set; }
        public string StreetAndNo { get; set; }
        public int ZipcodeId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
