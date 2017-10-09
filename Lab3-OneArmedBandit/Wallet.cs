using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OneArmedBandit
{
    class Wallet
    {
        private int _credit;
        /// <summary>
        /// Method for getting the private int _credit property of the wallet class 
        /// </summary>
        /// <returns></returns>
        public int GetCredit()
        {
            return _credit;
        }
        /// <summary>
        /// Method for setting the private int _credit property of the wallet class
        /// </summary>
        /// <param name="inputCredit"></param>
        public void SetCredit(int inputCredit)
        {
            _credit = inputCredit;
        }
        /// <summary>
        /// Method for adding the financial gain of the user to private int _credit property of the class
        /// </summary>
        /// <param name="convertedWinnings">Winnings casted from type double to type int</param>
        public void AddWinnings(int convertedWinnings)
        {
            _credit += convertedWinnings;
        }
        /// <summary>
        /// Method for substracting the user Bet from the private int _credit wallet class property
        /// </summary>
        /// <param name="Bet"></param>
        public bool SubstractBet(int Bet)
        {
            if (_credit < Bet) { return false; }
            
            _credit -= Bet;
            return true;
        }
    }
}
