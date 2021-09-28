using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LockedMessage { get; set; }
        public bool Accessable { get; set; }
        public Location LocationToNorth { get; set; }
        public Location LocationToEast { get; set; }
        public Location LocationToSouth { get; set; }
        public Location LocationToWest { get; set; }
        public List<Interactable> Interactables = new List<Interactable>();

        public Location(int id, string name, string description, string lockedMessage = null, bool accessable = true)
        {
            ID = id;
            Name = name;
            Description = description;
            LockedMessage = lockedMessage;
            Accessable = accessable;
        }

        public string visibleInteractables()
        {
            string result = "In the room there is ";

            if (!Interactables.Any())
            {
                return result + "nothing.";
            }

            foreach(Interactable interactable in Interactables)
            {
                result += "a " + interactable.Name + ", ";
            }
            return result;
        }
    }
}
