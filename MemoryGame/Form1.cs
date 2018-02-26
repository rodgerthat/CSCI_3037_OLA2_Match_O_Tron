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

        // firstClicked points to the first Label control that the player clicks, 
        // but it will be null if the player hasn't clicked a label yet
        Label firstClicked = null;

        // secondClicked points ot the second Label control that the player clicks
        Label secondClicked = null;

        // use this Random Object ( lol ) to choose random icons for the tiles
        Random random = new Random();


        // each of the letters is an emoji in the fonts letterset. 
        // 12 emojis, chosen by the BBG
        List<string> icons = new List<string>()
        {
            "💩", "❤️",  "😘",  "😍",  "😽",  "😻",  "😛",  "💎",  "💝",  "💵",  "💣",  "🎉",
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
            /*
            int i = 0;
            string message = " ";

            for (int j = 0; j > icons.Count; ++j)
            {
                message += icons[j];
            }
            */

            // the tableLayoutPanel has 24 labels, 
            // and the icon list has 12 icons
            // so an icon is pulled at random from the list and added to each label
            foreach (Control control in tableLayoutPanel1.Controls)
            {

                Label iconLabel = control as Label;

                // MessageBox.Show((icons[i]));
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);

                    //MessageBox.Show((randomNumber.ToString()));

                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;  // this hides them from the player initially, 
                    icons.RemoveAt(randomNumber);               // 

                    //iconLabel.Text = icons[i];
                    //iconLabel.ForeColor = iconLabel.BackColor;
                    //icons.RemoveAt(i);

                }

                //++i;
            }

            //MessageBox.Show(message);
            //MessageBox.Show(i.ToString());

        }

        private void labelClick(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // if the clicked label is black, the player clicked
                // an icon that's already been revealed, 
                // so ignore that clickity clickiness
                if (clickedLabel.ForeColor == Color.Black)
                {
                    return; // bail! abort! abort!
                }

                // if firstClicked is null, this is the first icon in the pair that the player
                // has clicked. so set firstClicked to the label that the player
                // clicked, change it's color to black, and RETURN

                if (firstClicked == null)
                {

                    firstClicked = clickedLabel;
                    clickedLabel.ForeColor = Color.Black;
                }
            }
        }
    }
}
