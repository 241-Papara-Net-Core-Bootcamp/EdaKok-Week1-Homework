using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Owner.API.Models
{
    public class OwnerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public string OwnershipType { get; set; }
    }
}
