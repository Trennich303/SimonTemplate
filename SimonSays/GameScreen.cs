using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        SoundPlayer mistakeSound = new SoundPlayer(Properties.Resources.mistake);
        SoundPlayer greenSound = new SoundPlayer(Properties.Resources.green);
        SoundPlayer redSound = new SoundPlayer(Properties.Resources.red);
        SoundPlayer yellowSound = new SoundPlayer(Properties.Resources.yellow);
        SoundPlayer blueSound = new SoundPlayer(Properties.Resources.blue);
        
        //TODO: create guess variable to track what part of the pattern the user is at
        int playerGuess = 0;

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //TODO: clear the pattern list from form1, refresh, pause for a bit, and run ComputerTurn()
            Form1.playerInput.Clear();
            Refresh();
         Thread.Sleep(1000);
            ComputerTurn();
     

        }



        private void ComputerTurn()
        {
            //TODO: get rand num between 0 and 4 (0, 1, 2, 3) and add to pattern list
            
            Random randGen = new Random();
            int randValue;
            randValue = randGen.Next(0, 4);
            Form1.playerInput.Add(randValue);

           

            //TODO: create a for loop that shows each value in the pattern by lighting up approriate button
            for (int i = 0; i < Form1.playerInput.Count(); i++)
            {
                if (Form1.playerInput[i] == 0)
                {
                    blueButton.BackColor = Color.DodgerBlue;
                    Refresh();
                    Thread.Sleep(500);
                    blueButton.BackColor = Color.DarkBlue;
                    Refresh();
                    Thread.Sleep(500);
                }
                else if (Form1.playerInput[i] == 1)
                {
                    redButton.BackColor = Color.Red;
                    Refresh();
                    Thread.Sleep(500);
                    redButton.BackColor = Color.DarkRed;
                    Refresh();
                    Thread.Sleep(500);
                }
                else if (Form1.playerInput[i] == 2)
                {
                    greenButton.BackColor = Color.Lime;
                    Refresh();
                    Thread.Sleep(500);
                    greenButton.BackColor = Color.ForestGreen;
                    Refresh();
                    Thread.Sleep(500);
                }
                else if (Form1.playerInput[i] == 3)
                {
                    yellowButton.BackColor = Color.Gold;
                    Refresh();
                    Thread.Sleep(500);
                    yellowButton.BackColor = Color.Goldenrod;
                    Refresh();
                    Thread.Sleep(500);
                }
            }

            //TODO: get guess index value back to 0
            playerGuess = 0;
        }

        public void GameOver()
        {
            //TODO: Play a game over sound

            //TODO: close this screen and open the GameOverScreen
            Form1.ChangeScreen(this, new GameOverScreen());

        }

        //TODO: create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            //TODO: is the value at current guess index equal to a green. If so:
            // light up button, play sound, and pause
            if (Form1.playerInput[playerGuess] == 2)
            {
                greenSound.Play();
                greenButton.BackColor = Color.Lime;
                Refresh();
                Thread.Sleep(500);
                greenButton.BackColor = Color.ForestGreen;
                Refresh();
                Thread.Sleep(500);
                // set button colour back to original
                // add one to the guess index
                playerGuess++;
            }
            else
            {
                mistakeSound.Play();    
                GameOver();
            }


               
            
            // check to see if we are at the end of the pattern. If so:
           if(Form1.playerInput.Count == playerGuess )
            {
                ComputerTurn();
            }
           
            // call ComputerTurn() method
            
            // else call GameOver method
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (Form1.playerInput[playerGuess] == 0)
            {
                blueSound.Play();
                blueButton.BackColor = Color.DodgerBlue;
                Refresh();
                Thread.Sleep(500);
                blueButton.BackColor = Color.DarkBlue;
                Refresh();
                Thread.Sleep(500);
                // set button colour back to original
                // add one to the guess index
                playerGuess++;
            }
            else
            {
                mistakeSound.Play();
                GameOver();
            }
            if (Form1.playerInput.Count == playerGuess)
            {
                ComputerTurn();
            }
         

        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (Form1.playerInput[playerGuess] == 3)
            {
                yellowSound.Play();
                yellowButton.BackColor = Color.Gold;
                Refresh();
                Thread.Sleep(500);
                yellowButton.BackColor = Color.Goldenrod;
                Refresh();
                Thread.Sleep(500);
                // set button colour back to original
                // add one to the guess index
                playerGuess++;
            }
            else
            {
                mistakeSound.Play();
                GameOver();
            }
            if (Form1.playerInput.Count == playerGuess)
            {
                ComputerTurn();
            }
           
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            if (Form1.playerInput[playerGuess] == 1)
            {
               redSound.Play();
                redButton.BackColor = Color.Red;
                Refresh();
                Thread.Sleep(500);
                redButton.BackColor = Color.DarkRed;
                Refresh();
                Thread.Sleep(500);
                // set button colour back to original
                // add one to the guess index
                playerGuess++;
            }
            else
            {
                mistakeSound.Play();
                GameOver();
            }
            if (Form1.playerInput.Count == playerGuess)
            {
                ComputerTurn();
            }
           
        }
    }
}
