using System;

namespace Rock_Paper_Scissors
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomNumber = new Random();

            double playerPoints = 0;
            double computerPoints = 0;

            int rock = 1;
            int paper = 2;
            int scissors = 3;

            Console.WriteLine("Rock-Paper-Scissors Game");
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();

            Console.Write("Enter number of rounds: ");
            string input = Console.ReadLine();
            int totalRounds = Convert.ToInt32(input);

            Console.WriteLine();

            for (int roundNumber = 0; roundNumber < totalRounds; roundNumber++)
            {
                int computerChoice = randomNumber.Next(1,4);

                Console.Write("Enter R or S or P: ");
                string playerInput = Console.ReadLine();
                string playerInputUpper = playerInput.ToUpper();
                int playerChoice = playerInputUpper == "R" ? rock : (playerInputUpper == "S" ? scissors : paper);

                string message = "";
                if (computerChoice == rock && playerChoice == scissors || 
                    computerChoice == scissors && playerChoice == paper ||
                    computerChoice == paper && playerChoice == rock)
                {
                    computerPoints += 1;
                    message = "Your Enemy Wins!";
                }
                else
                {
                    if (computerChoice == playerChoice)
                    {
                        computerPoints += 0.5;
                        playerPoints += 0.5;
                        message = "It's a tie";
                        
                    }
                    else
                    {
                        playerPoints += 1;
                        message = "You won!";
                    }
                }
                string playerChoiceInText = playerChoice == rock ?
            "Rock" : (playerChoice == scissors ? "Scissors" : "Paper");
                string computerChoiceInText = computerChoice == rock ?
                    "Rock" : (computerChoice == scissors ? "Scissors" : "Paper");
                Console.WriteLine(playerName + ":Enemy - " +
                    playerChoiceInText + ":" + computerChoiceInText);
                Console.WriteLine(message);
                Console.WriteLine();


            }
            Console.WriteLine("GAME OVER - OVERALL RESULT");
            if(playerPoints > computerPoints)
            {
                Console.WriteLine("You conquered your opponent!");
            }
            else if (playerPoints == computerPoints)
            {
                Console.WriteLine("It is a tie.");
            }
            else
            {
                Console.WriteLine("You were defeated, you'll get them next time.");
            }
            Console.WriteLine(playerName + ":Enemy - " +
                playerPoints.ToString() + ":" + computerPoints.ToString());

            
            Console.ReadLine();

        }
    }
}
