using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableLibrary
{
   public class Bar
    {
        public String name { get; set; }

        public int barId { get; set; }

        public String logoPath { get; set; }

        public String address { get; set; }

        public List<HashSet<String>> barHours{ get; set; }

    }
}
