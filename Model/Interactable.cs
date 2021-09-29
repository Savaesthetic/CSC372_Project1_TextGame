using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /*
     * This class defines objects/items in the game world
     */
    public class Interactable
    {
        // Class properties
        // Simple way to define default getter and setter methods for class properties.
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
        public bool Useable { get; set; }
        public bool ItemRequired { get; set; }
        public Item reward { get; set; }
        public string RewardDescription { get; set; }
        public string UsedDescription { get; set; }
        public bool LocationUnlock { get; set; }

        // Constructor that takes a bunch of paramters and even has some default values for a few.
        public Interactable(string name, string description, int id, bool useable = false, bool itemRequired = false, string rewardDescription = null, 
            string usedDescription = null, bool locationUnlock = false)
        {
            Name = name;
            Description = description;
            ID = id;
            Useable = useable;
            ItemRequired = itemRequired;
            RewardDescription = rewardDescription;
            UsedDescription = usedDescription;
            LocationUnlock = locationUnlock;
        }
    }
}
