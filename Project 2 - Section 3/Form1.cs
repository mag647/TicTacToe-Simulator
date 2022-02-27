using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_2___Section_3
{
    //           Author:  Michele Gay
    // Date of creation:  04/01/2020
    //      Description:  This project creates a random game of tic tac toe
    //                    when a button is clicked. It displays the winner or 
    //                    if there was a tie after each game. Upon exit
    //                    the number of wins and ties are shown to the user. 

    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
        }

        // Constant declaration
        const int ROWS = 3;
        const int COLS = 3;

        // Create new array 
        int[,] valueArray = new int[ROWS, COLS];

        // Create a variable of the random class 
        Random rand = new Random();
       
        int numOWins = 0; // Holds number of times O wins
        int numXWins = 0; // Holds number of times X wins
        int numTies = 0; // Holds number of ties

        bool playerXWin;
        bool playerOWin;

        private void AssignValues(int[,] valueArray)
        {
            // Use a random number object to assign 0 or 1 to each element in the valueArray
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    valueArray[row, col] = rand.Next(2);
                }
            }

        }

        // Creates a new array to store Xs and Os as values for each element in letterArray
        string[,] letterArray = new string[ROWS, COLS];

        private void AssignLetters(int[,] valueArray)
        {
            int totalO = 0; //Holds number of times O appears in letterArray
            int totalX = 0; //Holds number of times X appears in letterArray

            // Assigns "O" or "X" to each element in letterArray. If a 
            // subscript in valueArray = 0, then an element at the same subscript
            // in letterArray = O. If a subscript in valueArray = 1, then an element
            // at the same subscript in letterArray = X. 

            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    if (valueArray[row, col] == 0)
                    {
                       //Keeps maximum number of Os at 5
                        if (totalO < 5)
                        {
                            letterArray[row, col] = "O";
                            totalO++;
                        }
                        else
                        {
                            letterArray[row, col] = "X";
                            totalX++;
                        }
                        
                    }
                    else 
                    {
                        //Keeps maximum number of Xs at 5
                        if (totalX < 5)
                        {
                            letterArray[row, col] = "X";
                            totalX++;
                        }
                        else
                        {
                            letterArray[row, col] = "O";
                            totalO++;
                        }
                    }
                }
            }
        }

        private void DisplayLetters(string[,] letterArray)
        {
            //Assigns X or O as the text for each label in the game
            Row0Col0Label.Text = letterArray[0, 0].ToString();
            Row0Col1Label.Text = letterArray[0, 1].ToString();
            Row0Col2Label.Text = letterArray[0, 2].ToString();
            Row1Col0Label.Text = letterArray[1, 0].ToString();
            Row1Col1Label.Text = letterArray[1, 1].ToString();
            Row1Col2Label.Text = letterArray[1, 2].ToString();
            Row2Col0Label.Text = letterArray[2, 0].ToString();
            Row2Col1Label.Text = letterArray[2, 1].ToString();
            Row2RightLabel.Text = letterArray[2, 2].ToString();
        }

        private void DisplayWinner()
        {

            playerXWin = false;
            playerOWin = false;
            
            //Winning Condition for Row 0
            if (letterArray[0,0] == letterArray[0,1] && letterArray[0,1] ==letterArray[0,2])
            {
                if (letterArray[0,0] == "X")
                {
                    playerXWin = true;
                }
                else //if (letterArray[0, 0] == "O")
                {
                    playerOWin = true;
                }
            }
            //Winning Condition for Row 1
            if (letterArray[1, 0] == letterArray[1, 1] && letterArray[1, 1] == letterArray[1, 2])
            {
                if (letterArray[1, 0] == "X")
                {
                    playerXWin = true;
                }
                else
                {
                    playerOWin = true;
                }
            }
            //Winning Condition for Row 2
            if (letterArray[2, 0] == letterArray[2, 1] && letterArray[2, 1] == letterArray[2, 2])
            {
                if (letterArray[2, 0] == "X")
                {
                    playerXWin = true;
                }
                else
                {
                    playerOWin = true;
                }
            }
            //Winning Condition for Column 0
            if (letterArray[0, 0] == letterArray[1, 0] && letterArray[1, 0] == letterArray[2, 0])
            {
                if (letterArray[0, 0] == "X")
                {
                    playerXWin = true;
                }
                else
                {
                    playerOWin = true;
                }
            }
            //Winning Condition for Column 1
            if (letterArray[0, 1] == letterArray[1, 1] && letterArray[1, 1] == letterArray[2, 1])
            {
                if (letterArray[0, 1] == "X")
                {
                    playerXWin = true;
                }
                else
                {
                    playerOWin = true;
                }
            }
            //Winning Condition for Column 2
            if (letterArray[0, 2] == letterArray[1, 2] && letterArray[1, 2] == letterArray[2, 2])
            {
                if (letterArray[0, 2] == "X")
                {
                    playerXWin = true;
                }
                else
                {
                    playerOWin = true;
                }
            }
            //Winning Condition for Diagonal including [0,0], [1,1], and [2,2]
            else if (letterArray[0, 0] == letterArray[1, 1] && letterArray[1, 1] == letterArray[2, 2])
            {
                if (letterArray[0, 0] == "X")
                {
                    playerXWin = true;
                }
                else
                {
                    playerOWin = true;
                }
            }
            //Winning Condition for Diagonal including [2,0], [1,1], and [0,2]
            if (letterArray[2, 0] == letterArray[1, 1] && letterArray[1, 1] == letterArray[0, 2])
            {
                if (letterArray[2, 0] == "X")
                {
                    playerXWin = true;
                }
                else
                {
                    playerOWin = true;
                }
            }
            //Output results to ResultLabel and increment win   variables. 
            if (playerOWin && playerXWin)
            {
                ResultLabel.Text = "It's a tie!";
                numTies++;
            }
            else if (playerOWin)
            {
                ResultLabel.Text = "O is the winner!";
                numOWins++;
            }
            else if (playerXWin)
            {
                ResultLabel.Text = "X is the winner!";
                numXWins++;
            }
            else
            {
                ResultLabel.Text = "It's a tie!";
                numTies++;
            }
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            AssignValues(valueArray);
            AssignLetters(valueArray);
            DisplayLetters(letterArray);
            DisplayWinner();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            
            //Confirm the form exit by prompting the user first.
            if (MessageBox.Show("Are you sure you want to exit?",
                "Confirm exit...",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //Show total wins for X, wins for O, and total ties
                MessageBox.Show("Number of times X won: " + numXWins.ToString() + Environment.NewLine +
                "Number of times O won: " + numOWins.ToString() + Environment.NewLine +
                "Number of ties: " + numTies.ToString());

                //Exit the application
                Application.Exit();
            }
        }
    }


}
