using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace RestAPI.Models
{
    public class UnionCounty
    {
    
        public int ID { get; set; }

        public string Name { get; set; }
  
        public string County { get; set; }
        public virtual ICollection<LocalUnion> LocalUnions { get; set; }
    }
}
