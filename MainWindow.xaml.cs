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
        string[] sebisbad = new string[20];

        public MainWindow()
        {
            InitializeComponent();
        }

        StreamReader streamReader = new StreamReader("wordList.txt");
        

        private void btnSolve_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGuess_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
