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

namespace Lab3_OneArmedBandit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person person = new Person();
        public MainWindow()
        {
            InitializeComponent();
           
        }
        /// <summary>
        /// Getter for Person class property PlayerName
        /// </summary>
        private string PlayerName => NameTextBox.Text;
               /// <summary>
        /// Method for Retrieving credit from User
        /// </summary>
        /// <returns>inputCredit</returns>
        private int GetInputCredit()
        {
              
                int.TryParse(CreditTextBox.Text, out int inputCredit); return inputCredit;                       
        }
        /// <summary>
        /// Method for setting required class instance properties for Wallet and Person classes 
        /// </summary>
        /// <param name="PlayerName">Name of User</param>
        private void SetInnitialWalletValue(string PlayerName)
        {
            int inputCredit = GetInputCredit();
            person.wallet.SetCredit(inputCredit);
            person.SetName(PlayerName);
        }
        /// <summary>
        /// Method for retrieving Bet from User
        /// </summary>
        private int Bet
        {
            get
            {                
                int.TryParse(BetTextBox.Text, out int bet); return bet;
            }
        }
        /// <summary>
        /// Method for displaying the GameBoard Matrix to the User
        /// </summary>
        /// <param name="gamePiece"></param>
        /// <param name="matrix"></param>
        private void ShowBoard(string gamePiece, string[,] matrix)
        {

            Element00.Content = matrix[0, 0];
            Element01.Content = matrix[0, 1];
            Element02.Content = matrix[0, 2];
            Element10.Content = matrix[1, 0];
            Element11.Content = matrix[1, 1];
            Element12.Content = matrix[1, 2];
            Element20.Content = matrix[2, 0];
            Element21.Content = matrix[2, 1];
            Element22.Content = matrix[2, 2];

        }
        /// <summary>
        /// Method for handling the event of all money loss.
        /// </summary>
        private void NoMoney()
        {

            int moneyMoreThanZero = person.wallet.GetCredit();
            if (moneyMoreThanZero <= 0)
            {
                MessageBoxResult result = MessageBox.Show("You got no money left, huh? Do you want to exit," +
                    " kick the machine and go kill yourself? Or at least re-think your life you fucking gambling addict!"
                    , "NO MONEY left! Wife is gonna KILL YOU!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (MessageBoxResult.Yes == result)
                {
                    Close();
                }
                else if (MessageBoxResult.No == result)
                {
                    int inputCredit = 0;
                    person.wallet.SetCredit(inputCredit);
                    BetTextBox.Clear();
                    CreditTextBox.Clear();
                    CreditLabel.Content = " ";
                    NameLabel.Content = " ";
                }
            }

        }
        /// <summary>
        /// Main Method for construction and running the game
        /// </summary>
        /// <param name="Bet">Bet retrieved from User</param>
        private void Run(int Bet)
        {
            int credit = person.wallet.GetCredit();
            if (credit >= Bet && Bet != 0)                //Checks if the Bet value is valid.
            {
                GameBoard newGameBoard = new GameBoard(Bet);              
                person.wallet.SubstractBet(Bet);  //Subtracts Bet from users credit.

                MultiplierLabel.Content = newGameBoard.Multiplier.ToString();   //Show multiplier to user
                int convertedWinnings = Convert.ToInt32(newGameBoard.Winnings);
                person.wallet.AddWinnings(convertedWinnings);        //Add winnings if there are any..
                CreditLabel.Content = person.wallet.GetCredit();        //Display credit to the user.
                ShowBoard(newGameBoard.GamePiece, newGameBoard.Matrix);
                NoMoney();

            }
            else if (credit < Bet) { MessageBox.Show("You can't bet more than you have!"); }
        }

        private void DisplayGameBoard_Click(object sender, RoutedEventArgs e)
        {
            Run(Bet);
        }

        private void SaveContent_Click(object sender, RoutedEventArgs e)
        {
            SetInnitialWalletValue(PlayerName);
            CreditLabel.Content = person.wallet.GetCredit();
            CreditTextBox.Clear();
            NameLabel.Content = PlayerName + "'s Game";
            NameTextBox.Clear();

        }



    }
}
