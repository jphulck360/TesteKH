using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMineral.Models
{
    public class Repository : IRepository
    {
        private Dictionary<int, Mineral> minerais;

        public Repository()
        {
            minerais = new Dictionary<int, Mineral>();

            new List<Mineral>
            {
                new Mineral {
                    MineralId = 1,
                    MineralName = "Ouro",
                    Description = "É um metal de transição brilhante, amarelo, denso, maleável, dúctil (trivalente e univalente) que não reage com a maioria dos produtos químicos.",
                    Completed = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Mineral {
                    MineralId = 2,
                    MineralName = "Jaspe",
                    Description = "Mineral opaco, polimorfo de SiO2 e variação criptocristalina do quartzo de coloração vermelha, amarela ou variada.",
                    Completed = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            }.ForEach(m => AddMineral(m));
        }

        public Mineral this[int id] => minerais.ContainsKey(id) ? minerais[id] : null;

        public IEnumerable<Mineral> Minerais => minerais.Values;

        public Mineral AddMineral(Mineral mineral)
        {
            if(mineral.MineralId == 0)
            {
                int key = minerais.Count;
                while (minerais.ContainsKey(key))
                {
                    key++;
                };
                mineral.MineralId = key;
            }
            minerais[mineral.MineralId] = mineral;
            return mineral;
        }

        public void DeleteMineral(int id)
        {
            minerais.Remove(id);
        }

        public Mineral UpdateMineral(Mineral mineral)
        {
            AddMineral(mineral);
            return mineral;
        }
    }
}
