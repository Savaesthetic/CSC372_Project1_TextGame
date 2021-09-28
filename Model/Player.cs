using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Model
{
    public class Player
    {
        public Location CurrentLocation { get; set; }
        public List<Item> inventory = new List<Item>();

        public Player()
        {

        }

        public string MoveTo(string[] command)
        {
            if (command.Length == 2)
            {
                switch (command[1])
                {
                    case "north":
                        if (CurrentLocation.LocationToNorth != null)
                        {
                            if (CurrentLocation.LocationToNorth.Accessable)
                            {
                                CurrentLocation = CurrentLocation.LocationToNorth;
                                return CurrentLocation.Description;
                            }
                            return CurrentLocation.LocationToNorth.LockedMessage;
                        }
                        break;
                    case "east":
                        if (CurrentLocation.LocationToEast != null)
                        {
                            if (CurrentLocation.LocationToEast.Accessable)
                            {
                                CurrentLocation = CurrentLocation.LocationToEast;
                                return CurrentLocation.Description;
                            }
                            return CurrentLocation.LocationToEast.LockedMessage;
                        }
                        break;
                    case "south":
                        if (CurrentLocation.LocationToSouth != null)
                        {
                            if (CurrentLocation.LocationToSouth.Accessable)
                            {
                                CurrentLocation = CurrentLocation.LocationToSouth;
                                return CurrentLocation.Description;
                            }
                            return CurrentLocation.LocationToSouth.LockedMessage;
                        }
                        break;
                    case "west":
                        if (CurrentLocation.LocationToWest != null)
                        {
                            if (CurrentLocation.LocationToWest.Accessable)
                            {
                                CurrentLocation = CurrentLocation.LocationToWest;
                                return CurrentLocation.Description;
                            }
                            return CurrentLocation.LocationToWest.LockedMessage;
                        }
                        break;
                }
            }
            return "You can not go there.";
        }

        public string Inspect(string[] command)
        {
            if (command.Length == 2)
            {
                // Checks to see if interactable exists in the current location
                foreach (Interactable interactable in CurrentLocation.Interactables)
                {
                    if (interactable.Name.ToLower().Equals(command[1].ToLower()))
                    {
                        return interactable.Description;
                    }
                }
                // Checks to see if interactable exists in players inventory
                foreach (Interactable interactable in inventory)
                {
                    if (interactable.Name.ToLower().Equals(command[1].ToLower()))
                    {
                        return interactable.Description;
                    }
                }
            }
            return "I can't see that.";
        }

        public string Grab(string[] command)
        {
            if (command.Length == 2)
            {
                // Checks to see if interactable exists in the current location
                foreach (Interactable interactable in CurrentLocation.Interactables)
                {
                    if (interactable.GetType().Equals(typeof(Item)) && interactable.Name.ToLower().Equals(command[1].ToLower()))
                    {
                        inventory.Add((Item)interactable);
                        CurrentLocation.Interactables.Remove(interactable);
                        return "I've picked up a " + interactable.Name;
                    }
                }
            }
            return "I can't pick that up.";
        }

        public string Inventory(string[] command)
        {
            if (command.Length == 1)
            {
                string result = "I have ";

                if (!inventory.Any())
                {
                    return result + "nothing.";
                }

                foreach (Item item in inventory)
                {
                    result += "a " + item.Name + ", ";
                }
                return result;
            }
            return "I don't understand that command.";
        }

        public string Use(string[] command)
        {
            if ((command.Length == 2) || (command.Length == 4 && command[2].Equals("on")))
            {
                return "valid command";
            }
            return "I can not do that.";
        }
    }
}
