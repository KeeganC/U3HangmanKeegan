/* Keegan Chan
 * 4 19 2018
 * U3HangmanKeegan
 * simulates a game of hangman*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace U3HangmanKeegan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Global variables
        Random random = new Random();
        private static string strWordLineNumber;
        private static string strTargetWord;
        string strBlanks = "_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ";
        int mistakeCounter = 0;
        bool GameOver = false;
        string strLettersGuessed = "";
        string strShowWord = "";

        public MainWindow()
        {
            InitializeComponent();
            //sets backround image
            ImageBrush gallows = new ImageBrush();
            gallows.ImageSource = new BitmapImage(new Uri("https://dailytimes.com.pk/static/uploads/original/five-terrorists-sent-to-the-gallows-c79c76c915a08e72cca13837c665fe80.jpg"));
            myCanvas.Background = gallows;
        }

        // sets a word ready to be guessed
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //picks the word from the list
            strWordLineNumber = random.Next(1, 15).ToString();
            //NIU MessageBox.Show(strWordLineNumber);
            SelectWord(); // add number of the word you want in the brackets for testing mode
            //NIU MessageBox.Show(strTargetWord);

            //sets the number of spaces for letters
            lblShowWord.Content = strBlanks.Substring(0, (strTargetWord.Length * 2) + 1);

            //resets mistakes
            mistakeCounter = 0;
            GameOver = false;
            bodyPart1.Visibility = Visibility.Hidden;
            bodyPart2.Visibility = Visibility.Hidden;
            bodyPart3.Visibility = Visibility.Hidden;
            bodyPart4.Visibility = Visibility.Hidden;
            bodyPart5.Visibility = Visibility.Hidden;
            bodyPart6.Visibility = Visibility.Hidden;

            //resets letters guessed
            lblGuessed.Content = ":";

            //assure that there are spaces where needed
            if (strTargetWord.Contains(" "))
            {
                strShowWord = lblShowWord.Content.ToString();
                lblShowWord.Content = strShowWord.Substring(0, (strTargetWord.IndexOf(" ") * 2) + 2) + " " + strShowWord.Substring((strTargetWord.IndexOf(" ") * 2) + 3);
            }
        }

        //guess the word
        private void btnSolve_Click(object sender, RoutedEventArgs e)
        {
            if (txbWordInput.Text == strTargetWord)
            {
                if (GameOver == false)
                {
                    MessageBox.Show("Correct!\r\nPlease click reset to play again");
                }
                else
                {
                    MessageBox.Show("Solved after Game Over.\r\nClick reset to play again");
                }
            }
            else
            {
                MessageBox.Show("incorrect, try again.");

                //adding a body part if they make a mistake
                MistakeMade();
            }
        }

        //guessing a letter
        private void btnGuess_Click(object sender, RoutedEventArgs e)
        {
            strShowWord = lblShowWord.Content.ToString();

            //checks if the letter has been guessed before
            strLettersGuessed = lblGuessed.Content.ToString();
            if (strLettersGuessed.Contains(txbLetterInput.Text))
            {
                MessageBox.Show("already guessed");
            }
            else
            {
                //adds letter to letters guessed
                lblGuessed.Content = lblGuessed.Content + " " + txbLetterInput.Text;

                if (strTargetWord.Contains(txbLetterInput.Text))
                {
                    lblShowWord.Content = strShowWord.Substring(0, (strTargetWord.IndexOf(txbLetterInput.Text) * 2) + 2) + txbLetterInput.Text + strShowWord.Substring((strTargetWord.IndexOf(txbLetterInput.Text) * 2) + 3);
                    strShowWord = lblShowWord.Content.ToString();
                    lblShowWord.Content = strShowWord.Substring(0, (strTargetWord.LastIndexOf(txbLetterInput.Text) * 2) + 2) + txbLetterInput.Text + strShowWord.Substring((strTargetWord.LastIndexOf(txbLetterInput.Text) * 2) + 3);
                }
                else
                {
                    MessageBox.Show("incorrect, try again.");
                    MistakeMade();
                }
            }
        }

        //Method to select the word randomly from a list
        private static void SelectWord() // add int x1 in the brackets for testing mode
        {
            StreamReader streamReader = new StreamReader("wordList.txt");

            try
            {
                while (!streamReader.EndOfStream) 
                {
                    string line = streamReader.ReadLine();
                    if (line.Contains(strWordLineNumber + " ")) // replace strWordLineNumber with int x1 in the brackets for testing
                    {
                        strTargetWord = line.Substring(strWordLineNumber.Length + 1);
                        streamReader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //method for adding body parts when mistakes are made
        private void MistakeMade()
        {
            mistakeCounter++;
            if (mistakeCounter == 1)
            {
                bodyPart1.Visibility = Visibility.Visible;
            }
            if (mistakeCounter == 2)
            {
                bodyPart2.Visibility = Visibility.Visible;
            }
            if (mistakeCounter == 3)
            {
                bodyPart3.Visibility = Visibility.Visible;
            }
            if (mistakeCounter == 4)
            {
                bodyPart4.Visibility = Visibility.Visible;
            }
            if (mistakeCounter == 5)
            {
                bodyPart5.Visibility = Visibility.Visible;
            }
            if (mistakeCounter == 6)
            {
                bodyPart6.Visibility = Visibility.Visible;
                MessageBox.Show("GAME OVER\r\nClick reset to try again");
                GameOver = true;
            }
        }
    }
}