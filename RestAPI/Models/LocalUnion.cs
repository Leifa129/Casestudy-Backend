using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Models
{
    public class LocalUnion
    {
        public int ID { get; set; }

        public int UnionCountyID { get; set; }
        public virtual UnionCounty RelatedCounty { get; set; }

        public string Name { get; set; }


    }
}
