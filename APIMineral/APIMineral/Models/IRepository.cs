using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMineral.Models
{
    public interface IRepository
    {
        IEnumerable<Mineral> Minerais { get; }
        Mineral this[int id] { get; }
        Mineral AddMineral(Mineral mineral);
        Mineral UpdateMineral(Mineral mineral);
        void DeleteMineral(int id);
    }
}
