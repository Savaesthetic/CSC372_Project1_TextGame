using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /* 
     * This class defines an item that is able to be picked up by the user.
     * This class is a subclass or derived class of its superclass or baseclass Interactable.
     */
    public class Item : Interactable
    {
        public bool Destructable { get; set; }

        // This constructor also calls its baseclass constructor with : base(arguments).
        public Item(string name, string description, int id, bool destructable = false) : base(name, description, id)
        {
            Destructable = destructable;
        }
}
}
