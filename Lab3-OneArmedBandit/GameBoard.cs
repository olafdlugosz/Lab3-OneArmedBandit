using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_OneArmedBandit
{
    class GameBoard
    {
        Random randomElement = new Random();
        private const int ROWS = 3;
        private const int COLS = 3;

        //private string GamePiece;
        public string[,] Matrix { get; private set; }
        public double Multiplier { get; private set; }
        public double Winnings { get; private set; }
        public string GamePiece { get; private set; }
        //private int Bet;

        public GameBoard(int Bet)
        {
            var gamePiece = GenerateGamePiece();
            var matrix = GenerateMatrix(gamePiece);
            var multiplier = GetMultiplier(matrix);;
            var winnings = GetWinnings(multiplier, Bet);

            // update public properties
            GamePiece = gamePiece;
            Matrix = matrix;
            Multiplier = multiplier;
            Winnings = winnings;
        }
       /// <summary>
       /// Method for randomly generating the gamePiece which each of the array elements will hold.
       /// </summary>
       /// <returns>gamePiece</returns>
        public string GenerateGamePiece()
        {
            int random = randomElement.Next(1, 101);
            if (random <= 30 && random >= 1){ string GamePiece = "9"; return GamePiece; }
             if (random >= 31 && random <= 55) { string GamePiece = "10"; return GamePiece; }
             if (random >= 56 && random <= 76) { string GamePiece = "J"; return GamePiece; }
             if (random >= 77 && random <= 90) { string GamePiece = "Q"; return GamePiece; }
             if (random >= 91 && random < 98) { string GamePiece = "K"; return GamePiece; }
             if (random >= 98 && random <= 100) { string GamePiece = "D"; return GamePiece; }
            return GamePiece;                     
        }
        /// <summary>
        /// Method for generating the 2 dimentional array and assigning gamePiece to each element.
        /// </summary>
        /// <param name="GamePiece">Randomly genereated string element</param>
        /// <returns></returns>
        public string[,] GenerateMatrix(string GamePiece)
        {
            string[,] matrix = new string[ROWS,COLS];
            for(int i = 0; i < ROWS; i++)
            {
                for(int j=0; j < COLS; j++)
                {
                    matrix[i, j] = GenerateGamePiece();
                }
            }

            return matrix;
        }
        /// <summary>
        /// Method for calculating the financial gain of the user
        /// </summary>
        /// <param name="Multiplier">gamePiece specific cash multiplier</param>
        /// <param name="Bet">Users own financial bet input</param>
        /// <returns></returns>
        public double GetWinnings(double Multiplier, int Bet)
        {
            double winnings = Multiplier * Bet;
            return winnings;
        }           
        /// <summary>
        /// Method for retrieving the correct multiplier under specific game conditions
        /// </summary>
        /// <param name="matrix">2-dimentional string array of gamePiece</param>
        /// <returns></returns>      
        public double GetMultiplier(string[,] matrix)
        {
            //This works. Is this the most elegant way? 
            double multiplier = 0;

            List<string> rowValue = new List<string>();   //The for loop and if statements will check if Rows match, 
            for (int i = 0; i < 3; i++)                   //then throw gamePiece into rowValue list which the foreach loops through
                                                          //to find and increment multiplayer.
            {
                    if (matrix[i,0] == matrix[i, 1] && matrix[i, 1] == matrix[i, 2])
                        rowValue.Add(matrix[i, 0]);

            }

            if (matrix[0, 0] == matrix[1, 1] && matrix[1, 1] == matrix[2, 2])
                rowValue.Add(matrix[0, 0]); //Hardcoded, Do I have to?

            if (matrix[2, 0] == matrix[1, 1] && matrix[1, 1] == matrix[0, 2])
                rowValue.Add(matrix[2, 0]); //Hardcoded, Do I have to?

            if(rowValue.Count == 0)
            {
                return 0;
            }

            Console.WriteLine($"{rowValue.Count} valid rowValues: {string.Join(", ", rowValue)}");

            foreach (var gamePiece in rowValue)
            {
                //Printlining function to check what is inside the rowValue List.
                Console.WriteLine(gamePiece);

                switch (gamePiece)
                {
                    case "9":
                        multiplier += 1.2;
                        break;
                    case "10":
                        multiplier += 2;
                        break;
                    case "J":
                        multiplier += 2.5;
                        break;
                    case "K":
                        multiplier += 10;
                        break;
                    case "Q":
                        multiplier += 5;
                        break;
                    default:
                        Console.WriteLine($"ERROR: unknown gamePiece '{gamePiece}'");
                        break;

                }
            }

            Console.WriteLine($"Multiplier is {multiplier}");
            return multiplier;
            
            //I guess looping is more elegant...DO I even need these fucking loops?
            /*  for (int i = 0; i < Matrix.Length; i++)
              {
                  if (Matrix[0, 0] == Matrix[0, 1] && Matrix[0, 1] == Matrix[0, 2])
                  {
                      if (Matrix[0, 0] == "9") multiplier += 1.2;
                      if (Matrix[0, 0] == "10") multiplier += 2;
                      if (Matrix[0, 0] == "J") multiplier += 2.5;
                      if (Matrix[0, 0] == "Q") multiplier += 5;
                      if (Matrix[0, 0] == "K") multiplier += 10;
                      break;
                  }
              }
                  for (int i = 0; i < Matrix.Length; i++)
                  {
                      if (Matrix[1, 0] == Matrix[1, 1] && Matrix[1, 1] == Matrix[1, 2])
                      {
                          if (Matrix[1, 0] == "9") multiplier += 1.2;
                          if (Matrix[1, 0] == "10") multiplier += 2;
                          if (Matrix[1, 0] == "J") multiplier += 2.5;
                          if (Matrix[1, 0] == "Q") multiplier += 5;
                          if (Matrix[1, 0] == "K") multiplier += 10;
                          break;
                      }
                  }
              for (int i = 0; i < Matrix.Length; i++)
              {
                  if (Matrix[2, 0] == Matrix[2, 1] && Matrix[2, 1] == Matrix[2, 2])
                  {
                      if (Matrix[2, 0] == "9") multiplier += 1.2;
                      if (Matrix[2, 0] == "10") multiplier += 2;
                      if (Matrix[2, 0] == "J") multiplier += 2.5;
                      if (Matrix[2, 0] == "Q") multiplier += 5;
                      if (Matrix[2, 0] == "K") multiplier += 10;
                      break;
                  } }
              for (int i = 0; i < Matrix.Length; i++)
              {
                  if (Matrix[0, 0] == Matrix[1, 1] && Matrix[1, 1] == Matrix[2, 2])
                  {
                      if (Matrix[0, 0] == "9") multiplier += 1.2;
                      if (Matrix[0, 0] == "10") multiplier += 2;
                      if (Matrix[0, 0] == "J") multiplier += 2.5;
                      if (Matrix[0, 0] == "Q") multiplier += 5;
                      if (Matrix[0, 0] == "K") multiplier += 10;
                      break;
                  } }
              for (int i = 0; i < Matrix.Length; i++)
              {
                 if (Matrix[2, 0] == Matrix[1, 1] && Matrix[1, 1] == Matrix[0, 2])
                  {
                      if (Matrix[2, 0] == "9") multiplier += 1.2;
                      if (Matrix[2, 0] == "10") multiplier += 2;
                      if (Matrix[2, 0] == "J") multiplier += 2.5;
                      if (Matrix[2, 0] == "Q") multiplier += 5;
                      if (Matrix[2, 0] == "K") multiplier += 10;
                      break;
                  }
              }

                 /* //TODO This works correctly but... can it be more elegant?
                  if (Matrix[0, 0] == "9" && Matrix[0, 1] == "9" && Matrix[0, 2] == "9") multiplier += 1.2;
                  if (Matrix[1, 0] == "9" && Matrix[1, 1] == "9" && Matrix[1, 2] == "9") multiplier += 1.2;
                  if (Matrix[2, 0] == "9" && Matrix[2, 1] == "9" && Matrix[2, 2] == "9") multiplier += 1.2;
                  if (Matrix[0, 0] == "9" && Matrix[1, 1] == "9" && Matrix[2, 2] == "9") multiplier += 1.2;
                  if (Matrix[2, 0] == "9" && Matrix[1, 1] == "9" && Matrix[0, 2] == "9") multiplier += 1.2;

                  if (Matrix[0, 0] == "10" && Matrix[0, 1] == "10" && Matrix[0, 2] == "10") multiplier += 2;
                  if (Matrix[1, 0] == "10" && Matrix[1, 1] == "10" && Matrix[1, 2] == "10") multiplier += 2;
                  if (Matrix[2, 0] == "10" && Matrix[2, 1] == "10" && Matrix[2, 2] == "10") multiplier += 2;
                  if (Matrix[0, 0] == "10" && Matrix[1, 1] == "10" && Matrix[2, 2] == "10") multiplier += 2;
                  if (Matrix[2, 0] == "10" && Matrix[1, 1] == "10" && Matrix[0, 2] == "10") multiplier += 2;

                  if (Matrix[0, 0] == "J" && Matrix[0, 1] == "J" && Matrix[0, 2] == "J") multiplier += 2.5;
                  if (Matrix[1, 0] == "J" && Matrix[1, 1] == "J" && Matrix[1, 2] == "J") multiplier += 2.5;
                  if (Matrix[2, 0] == "J" && Matrix[2, 1] == "J" && Matrix[2, 2] == "J") multiplier += 2.5;
                  if (Matrix[0, 0] == "J" && Matrix[1, 1] == "J" && Matrix[2, 2] == "J") multiplier += 2.5;
                  if (Matrix[2, 0] == "J" && Matrix[1, 1] == "J" && Matrix[0, 2] == "J") multiplier += 2.5;

                  if (Matrix[0, 0] == "Q" && Matrix[0, 1] == "Q" && Matrix[0, 2] == "Q") multiplier += 5;
                  if (Matrix[1, 0] == "Q" && Matrix[1, 1] == "Q" && Matrix[1, 2] == "Q") multiplier += 5;
                  if (Matrix[2, 0] == "Q" && Matrix[2, 1] == "Q" && Matrix[2, 2] == "Q") multiplier += 5;
                  if (Matrix[0, 0] == "Q" && Matrix[1, 1] == "Q" && Matrix[2, 2] == "Q") multiplier += 5;
                  if (Matrix[2, 0] == "Q" && Matrix[1, 1] == "Q" && Matrix[0, 2] == "Q") multiplier += 5;

                  if (Matrix[0, 0] == "K" && Matrix[0, 1] == "K" && Matrix[0, 2] == "K") multiplier += 10;
                  if (Matrix[1, 0] == "K" && Matrix[1, 1] == "K" && Matrix[1, 2] == "K") multiplier += 10;
                  if (Matrix[2, 0] == "K" && Matrix[2, 1] == "K" && Matrix[2, 2] == "K") multiplier += 10;
                  if (Matrix[0, 0] == "K" && Matrix[1, 1] == "K" && Matrix[2, 2] == "K") multiplier += 10;
                  if (Matrix[2, 0] == "K" && Matrix[1, 1] == "K" && Matrix[0, 2] == "K") multiplier += 10;

                  if (Matrix[0, 0] == "D" && Matrix[0, 1] == "D" && Matrix[0, 2] == "D") multiplier += 50;
                  if (Matrix[1, 0] == "D" && Matrix[1, 1] == "D" && Matrix[1, 2] == "D") multiplier += 50;
                  if (Matrix[2, 0] == "D" && Matrix[2, 1] == "D" && Matrix[2, 2] == "D") multiplier += 50;
                  if (Matrix[0, 0] == "D" && Matrix[1, 1] == "D" && Matrix[2, 2] == "D") multiplier += 50;
                  if (Matrix[2, 0] == "D" && Matrix[1, 1] == "D" && Matrix[0, 2] == "D") multiplier += 50;               
              
            return multiplier;*/
        }

    }

}
