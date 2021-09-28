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
    public partial class TextGame : Form
    {
        private Player _player;

        public TextGame()
        {
            InitializeComponent();

            // Create a new Player and set the starting elements
            _player = new Player();
            _player.CurrentLocation = World.LocationByID(World.LOCATION_ID_STARTING_ROOM);
            output.AppendText(_player.CurrentLocation.Description + Environment.NewLine + Environment.NewLine);
            output.AppendText(_player.CurrentLocation.visibleInteractables() + Environment.NewLine + Environment.NewLine);
        }

        private void PlayerOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "CurrentLocation")
            {
                output.AppendText(_player.CurrentLocation.Description);
            }
        }

        // event called everytime the text inside the userInput textbox is modified
        private void userInput_TextChanged(object sender, EventArgs e)
        {
        }

        // event called when focus is on userInput textBox and a key is pressed down
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
                        output.AppendText("TODO HELP COMMAND" + Environment.NewLine + Environment.NewLine);
                        break;
                    default:
                        output.AppendText("Command does not exist." + Environment.NewLine);
                        break;
                }
            }
        }

        private void output_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
