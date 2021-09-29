using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace CSC372_Project1
{
    /*
     * This is the class that handles all of the input and output from the gui.
     */
    public partial class TextGame : Form
    {
        // Creates a player for the game playthrough
        private Player _player;

        public TextGame()
        {
            InitializeComponent();

            /*
             * Create a new Player and set the starting elements and text
             * This can probably be handled better so that I dont have to manually set starting location and
             * output text
             */
            _player = new Player();
            _player.CurrentLocation = World.LocationByID(World.LOCATION_ID_STARTING_ROOM);
            output.AppendText(_player.CurrentLocation.Description + Environment.NewLine + Environment.NewLine);
            output.AppendText(_player.CurrentLocation.visibleInteractables() + Environment.NewLine + Environment.NewLine);
            output.AppendText("[Type help at any time for information on available commands.]" + Environment.NewLine + Environment.NewLine);
        }

        // Event called everytime the text inside the userInput textbox is modified
        private void userInput_TextChanged(object sender, EventArgs e)
        {
        }

        /* 
         * Event called when focus is on userInput textBox and a key is pressed down.
         * We use this command to take command input.
         */
        private void userInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // KeyChar takes in ascii values so we have to mask the Enter key
            if (e.KeyChar == (char)Keys.Enter)
            {
                string input = userInput.Text;
                string inputLower = input.ToLower();
                string[] inputComponents = inputLower.Split(' ');

                output.Text += ">   " + userInput.Text + Environment.NewLine;
                userInput.Clear();

                // This switch statement handles the different commands that we are able to recieve from the user
                switch (inputComponents[0])
                {
                    case "go":
                        output.AppendText(_player.MoveTo(inputComponents) + Environment.NewLine + Environment.NewLine);
                        output.AppendText(_player.CurrentLocation.visibleInteractables() + Environment.NewLine + Environment.NewLine);
                        break;
                    case "inspect":
                        output.AppendText(_player.Inspect(inputComponents) + Environment.NewLine + Environment.NewLine);
                        break;
                    case "grab":
                        output.AppendText(_player.Grab(inputComponents) + Environment.NewLine + Environment.NewLine);
                        break;
                    case "inventory":
                        output.AppendText(_player.Inventory(inputComponents) + Environment.NewLine + Environment.NewLine);
                        break;
                    case "use":
                        output.AppendText(_player.Use(inputComponents) + Environment.NewLine + Environment.NewLine);
                        break;
                    case "help":
                        output.AppendText("Available commands and syntax:" + Environment.NewLine);
                        output.AppendText("[help]" + Environment.NewLine);
                        output.AppendText("[go] [north/east/south/west]" + Environment.NewLine);
                        output.AppendText("[inspect] <object>" + Environment.NewLine);
                        output.AppendText("[grab] <object>" + Environment.NewLine);
                        output.AppendText("[inventory]" + Environment.NewLine);
                        output.AppendText("[use] <object>" + Environment.NewLine);
                        output.AppendText("[use] <object> [on] <object>" + Environment.NewLine + Environment.NewLine);
                        break;
                    default:
                        output.AppendText("Command does not exist." + Environment.NewLine + Environment.NewLine);
                        break;
                }
            }
        }

        // Event called whenever text is added to the output. We don't need to use this.
        private void output_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
