using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Item : Interactable
    {
        public bool Destructable { get; set; }

        public Item(string name, string description, int id, bool destructable = false) : base(name, description, id)
        {
            Destructable = destructable;
        }
}
}
