using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class World
    {
        public static readonly List<Interactable> Interactables = new List<Interactable>();
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Location> Locations = new List<Location>();

        public const int INTERACTABLE_ID_CHEST = 1;

        public const int ITEM_ID_LETTER = 1;
        public const int ITEM_ID_WORN_KEY = 2;

        public const int LOCATION_ID_STARTING_ROOM = 1;
        public const int LOCATION_ID_CROSS_ROADS = 2;

        static World()
        {
            PopulateInteractables(); // Creates all of the interactable objecst in the game
            PopulateItems(); // Creates all of the items that a player can use or pick up in the game
            PopulateLocations(); // Should probably be done last
        }

        private static void PopulateInteractables()
        {
            Interactable chest = new Interactable("Chest", "A sturdy chest locked with a padlock.", 1);

            Interactables.Add(chest);
        }

        private static void PopulateItems()
        {
            Item letter = new Item("Letter", "This letter tells the tale of your capture and of how your only chance of escape " +
                "is to solve the puzzles in the following rooms.", ITEM_ID_LETTER, false);
            Item wornKey = new Item("Key", "A key that has seen a lot of use.", ITEM_ID_WORN_KEY, true);

            Items.Add(letter);
            Items.Add(wornKey);
        }

        private static void PopulateLocations()
        {
            // Create all of the locations in the game.
            Location startingRoom = new Location(LOCATION_ID_STARTING_ROOM, "Starting Room",
                "You wake up with a throbbing pain in your neck and find yourself in a dark room with nothing but an empty syring " +
                "littering the ground, a piece of paper with some writing on it, and a door to the south leading out. " +
                "The last thing you remember is crashing in your bed after a night out at the bar with your friends.", 
                "The door seems to have locked shut as you exited the room. The only thing you can do now is move forward.", false);
            startingRoom.Interactables.Add(ItemByID(ITEM_ID_LETTER));


            Location crossRoads = new Location(LOCATION_ID_CROSS_ROADS, "The CrossRoads",
                "As you leave the room you found yourself in when you woke up, you hear an almost inperceptable click as the door shuts behind you, " +
                "leaving you in another small room with doors leading to every cardinal direction.");
            crossRoads.Interactables.Add(InteractableByID(INTERACTABLE_ID_CHEST));
            crossRoads.Interactables.Add(ItemByID(ITEM_ID_WORN_KEY));

            // Connect all of the rooms in the game.
            startingRoom.LocationToSouth = crossRoads;

            crossRoads.LocationToNorth = startingRoom;

            // Add all of the locations to the static list
            Locations.Add(startingRoom);
            Locations.Add(crossRoads);
        }

        public static Interactable InteractableByID(int id)
        {
            foreach (Interactable interactable in Interactables)
            {
                if (interactable.ID == id)
                {
                    return interactable;
                }
            }

            return null;
        }

        public static Item ItemByID(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public static Location LocationByID(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }

            return null;
        }
    }
}
