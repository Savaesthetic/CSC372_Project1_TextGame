using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Interactable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }

        public Interactable(string name, string description, int id)
        {
            Name = name;
            Description = description;
            ID = id;
        }
    }
}
