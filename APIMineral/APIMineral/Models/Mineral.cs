using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMineral.Models
{
    public class Mineral
    {
        public int MineralId { get; set; }
        public string MineralName { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
