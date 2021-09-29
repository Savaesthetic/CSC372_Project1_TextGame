using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /*
     * This class builds the world of the game. It is static as only one world can exist per game
     * and we want the world to be created on startup.
     */
    public static class World
    {
        // Everything in a static class must be static as well.
        public static List<Interactable> Interactables = new List<Interactable>();
        public static List<Item> Items = new List<Item>();
        public static List<Location> Locations = new List<Location>();

        // Const defines a constant variable which can't be modified, also counts as static.
        public const int ITEM_ID_LETTER = 1;
        public const int ITEM_ID_WORN_KEY = 2;
        public const int ITEM_ID_HANDLE = 3;

        public const int INTERACTABLE_ID_POSTER = 1;
        public const int INTERACTABLE_ID_CHEST = 2;
        public const int INTERACTABLE_ID_WINDOW = 3;

        public const int LOCATION_ID_STARTING_ROOM = 1;
        public const int LOCATION_ID_CROSS_ROADS = 2;
        public const int LOCATION_ID_EXIT = 3;

        static World()
        {
            PopulateItems(); // Creates all of the items that a player can use or pick up in the game
            PopulateInteractables(); // Creates all of the interactable objecst in the game
            PopulateLocations(); // Creates all of the locations in the game
        }

        private static void PopulateItems()
        {
            Item letter = new Item("Letter", "This letter tells the tale of my capture and of how my only chance of escape " +
                "is to solve the puzzles in the following rooms.", ITEM_ID_LETTER, false);

            Item wornKey = new Item("Key", "A key that has seen a lot of use.", ITEM_ID_WORN_KEY, true);

            Item handle = new Item("Handle", "A handle that seems to belong to a window", ITEM_ID_HANDLE, true);

            Items.Add(letter);
            Items.Add(wornKey);
            Items.Add(handle);
        }

        private static void PopulateInteractables()
        {
            Interactable poster = new Interactable("Poster", "A poster depicting the artist FM Attack.", INTERACTABLE_ID_POSTER, true, false, 
                "I feel behind the poster and find a key.");
            poster.reward = ItemByID(ITEM_ID_WORN_KEY);

            Interactable chest = new Interactable("Chest", "A sturdy chest locked with a padlock.", INTERACTABLE_ID_CHEST, true, true, 
                "I unlock the padlock with your key and open the chest to find a handle.", "An unlocked chest with nothing inside.");
            chest.reward = ItemByID(ITEM_ID_HANDLE);

            Interactable window = new Interactable("Window", "A reinforced window on the south wall with a view to the outside. " +
                "It is missing a handle.", INTERACTABLE_ID_WINDOW, true, true, "I attached the handle and am now able to open and exit " +
                "through the window.", "A window large enough to escape through.", true);

            Interactables.Add(poster);
            Interactables.Add(chest);
            Interactables.Add(window);
        }

        private static void PopulateLocations()
        {
            Location startingRoom = new Location(LOCATION_ID_STARTING_ROOM, "Starting Room",
                "You wake up with a throbbing pain in your neck and find yourself in a dark room with nothing but an empty syring " +
                "littering the ground, a piece of paper with some writing on it, and a door to the south leading out. " +
                "The last thing you remember is crashing in your bed after a night out at the bar with your friends.", 
                "The door seems to have locked shut as you exited the room. The only thing you can do now is move forward.", false);
            startingRoom.Interactables.Add(ItemByID(ITEM_ID_LETTER));


            Location crossRoads = new Location(LOCATION_ID_CROSS_ROADS, "The CrossRoads",
                "As you leave the room you found yourself in when you woke up, you hear an almost inperceptable click as the door shuts behind you, " +
                "leaving you in another small room with a few objects and a window.");
            crossRoads.Interactables.Add(InteractableByID(INTERACTABLE_ID_CHEST));
            crossRoads.Interactables.Add(InteractableByID(INTERACTABLE_ID_POSTER));
            crossRoads.Interactables.Add(InteractableByID(INTERACTABLE_ID_WINDOW));

            Location exit = new Location(LOCATION_ID_EXIT, "Outside",
                "You have made it out of the very easy puzzle room demo; congratulations!", "I can't open the window.", false);

            // Connect all of the rooms in the game.
            startingRoom.LocationToSouth = crossRoads;

            crossRoads.LocationToNorth = startingRoom;
            crossRoads.LocationToSouth = exit;

            // Add all of the locations to the static list
            Locations.Add(startingRoom);
            Locations.Add(crossRoads);
            Locations.Add(exit);
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
