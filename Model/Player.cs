using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Model
{
    /*
     * This class defines the player in the game.
     * This class is an absolute mess and can be improved tremendously by breaking down
     * some of the functions. If I had more time I could go back and clean it up.
     */
    public class Player
    {
        public Location CurrentLocation { get; set; }
        public List<Item> inventory = new List<Item>();

        // Default constructor with no paramaters.
        public Player()
        {
        }

        // class methods that deal with the input commands from the user
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

        /*
         * This function deals with the use command and needs to be broken down into smaller components.
         * It basically does numerous checks to make sure that an interactable is usable.
         */
        public string Use(string[] command)
        {
            if (command.Length == 2)
            {
                // "Uses" the interactable if it exists in the location, is useable, and doesnt require an item.
                foreach (Interactable interactable in CurrentLocation.Interactables)
                {
                    if (interactable.Name.ToLower().Equals(command[1].ToLower()))
                    {
                        if (interactable.Useable)
                        {
                            if (interactable.ItemRequired)
                            {
                                return "I need something else.";
                            }
                            else
                            {
                                if (interactable.reward != null)
                                {
                                    inventory.Add(interactable.reward);
                                    interactable.reward = null;
                                    return interactable.RewardDescription;
                                } else
                                {
                                    return "There is nothing else.";
                                }
                            }
                        }
                        else
                        {
                            return "There is nothing to do with that.";
                        }
                    }
                }
                // Uses an item if it exists in the inventory is usable and doesn't require an item.
                foreach (Interactable interactable in inventory)
                {
                    if (interactable.Name.ToLower().Equals(command[1].ToLower()))
                    {
                        if (interactable.Useable)
                        {
                            if (interactable.ItemRequired)
                            {
                                return "I need something else.";
                            }
                            else
                            {
                                if (interactable.reward != null)
                                {
                                    inventory.Add(interactable.reward);
                                }
                                return interactable.RewardDescription;
                            }
                        }
                        else
                        {
                            return "There is nothing to do with that.";
                        }
                    }
                }
                return "I can't use that.";
            } else if (command.Length == 4 && command[2].Equals("on"))
            {
                // Checks to see if interactable exists in players inventory
                foreach (Interactable item in inventory)
                {
                    if (item.GetType().Equals(typeof(Item)) && item.Name.ToLower().Equals(command[1].ToLower()))
                    {
                        // checks to see if interactable exists in current location
                        foreach (Interactable interactable in CurrentLocation.Interactables)
                        {
                            if (interactable.Name.ToLower().Equals(command[3].ToLower()))
                            {
                                if (interactable.Useable)
                                {
                                    if (interactable.ItemRequired)
                                    {
                                        if (item.ID == interactable.ID)
                                        {
                                            if (((Item)item).Destructable)
                                            {
                                                interactable.ItemRequired = false;
                                                interactable.Description = interactable.UsedDescription;
                                                inventory.Remove((Item)item);

                                                if (interactable.reward != null)
                                                {
                                                    inventory.Add(interactable.reward);
                                                    interactable.reward = null;
                                                    return interactable.RewardDescription;
                                                } else if (interactable.LocationUnlock)
                                                {
                                                    if (CurrentLocation.LocationToNorth != null && CurrentLocation.LocationToNorth.ID == interactable.ID)
                                                    {
                                                        CurrentLocation.LocationToNorth.Accessable = true;
                                                    }
                                                    if (CurrentLocation.LocationToEast != null && CurrentLocation.LocationToEast.ID == interactable.ID)
                                                    {
                                                        CurrentLocation.LocationToEast.Accessable = true;
                                                    }
                                                    if (CurrentLocation.LocationToSouth != null && CurrentLocation.LocationToSouth.ID == interactable.ID)
                                                    {
                                                        CurrentLocation.LocationToSouth.Accessable = true;
                                                    }
                                                    if (CurrentLocation.LocationToWest != null && CurrentLocation.LocationToWest.ID == interactable.ID)
                                                    {
                                                        CurrentLocation.LocationToWest.Accessable = true;
                                                    }
                                                    interactable.LocationUnlock = false;
                                                    return interactable.RewardDescription;
                                                }
                                                else
                                                {
                                                    return "There is nothing else.";
                                                }
                                            }
                                        } else
                                        {
                                            return "I can't use this here.";
                                        }
                                    }
                                    else
                                    {
                                        return "I can't use this here.";
                                    }
                                }
                                else
                                {
                                    return "There is nothing to do with that.";
                                }
                            }
                        }
                    }
                }
                return "I can't use it on that.";
            } else
            {
                return "I can't do that.";
            }
        }
    }
}
