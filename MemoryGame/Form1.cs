using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1 : Form
    {

        // use this Random Object ( lol ) to choose random icons for the tiles
        Random random = new Random();


        // each of the letters is an emoji in the fonts letterset. 
        // 12 emojis, chosen by the BBG
        List<string> icons = new List<string>()
        {
            "💩", "❤️",  "😘",  "😍",  "😽",  "😻",  "😛",  "💎",  "💝",  "💵",  "💣",  "🎉"
        };

        public Form1()
        {
            InitializeComponent();

            AssignIconsToTiles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Assign each icon from the list of icons to a random tile
        /// </summary>

        private void AssignIconsToTiles()
        {
            // the tableLayoutPanel has 24 labels, 
            // and the icon list has 12 icons
            // so an icon is pulled at random from the list and added to each label
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);

                    //MessageBox.Show((randomNumber.ToString()));

                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);

                }
            }

        }
    }
}
