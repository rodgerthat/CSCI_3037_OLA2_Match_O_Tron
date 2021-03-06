﻿using System;
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

        Color[] rainbow = { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Purple };

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

            // the timer is only on after two non-matching icons have been shown to the player
            // so ignore any clicks if the timer is running
            if (timer1.Enabled == true)
            {
                return;
            }

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
                    return; // peace out. 
                }

                // if the player gets this far, the timer isn't running and firstClicked isn't null
                // so this must be the second icon the player clicked. 
                // set its' color to black. 
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                // check to see if the player won
                checkForWinner();

                // if the player clicked two matching icons, keep them black and reset
                // firstClicked and secondClicked
                // so that the player can click another icon
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                // if the player gets this far, the player clicked 
                // two different icons, so statrt the timer, which will wait a second
                // and then hide from the icons
                timer1.Start();


            }
        }

        /// <summary>
        /// This timer is started when the player clicks
        /// two icons that don't match
        /// so it counts for a second, then turns itself off and hides both icons. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();  // stop the timer, duh. 

            // Hide both icons. 
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            // Reset firstClicked and secondClicked so the next time a label is slicked, 
            // the program knows it's the first click
            firstClicked = null;
            secondClicked = null;


        }

        /// <summary>
        /// Check every icon to see if it is matched, by comparing it's foreground color
        /// to it's background color. If all of the icons are matched, the player has WON!
        /// </summary>
        private void checkForWinner()
        {

            // Go through all of the labels in the tableLayoutPanel1
            // checking each one to see if it's icon is matched. 
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            // if the loop didn't return, it didn't find any unmathced items!
            // therefore, the user has WON! show a message and close the form. 
            MessageBox.Show("You matched all teh Emoji's", "CONGRATULATIONS!");
            Close();

        }
    }
}
