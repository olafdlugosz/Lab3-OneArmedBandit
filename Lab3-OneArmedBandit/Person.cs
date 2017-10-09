using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OneArmedBandit
{
    class Person
    {
        private string _name;
        public Wallet wallet;
        /// <summary>
        /// Method for getting the _name property of the Person class
        /// </summary>
        /// <returns>_name</returns>
        public string GetName()
        {
            return _name;
        }
        /// <summary>
        /// Method for setting the _name property of the Person class
        /// </summary>
        /// <param name="PlayerName">user input parameter for setting the _name property of the Person class</param>
        public void SetName(string PlayerName)
        {
            _name = PlayerName;
        }
        /// <summary>
        /// Main Constructor for the class.
        /// </summary>
        /// <param name="PlayerName">user input parameter for setting the _name property of the Person class</param>
        public Person(string PlayerName)
        {           
            SetName(PlayerName);
            wallet = new Wallet();
        }
        /// <summary>
        /// Constructor for assigning class property _name in the case of no UserInput
        /// </summary>
        public Person()
        {
            SetName("ManwithNoName");
            wallet = new Wallet();
        }
    }
}
