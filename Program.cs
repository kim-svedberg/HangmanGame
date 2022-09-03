using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace HangmanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Plan:
              1. Welcome screen. Press any key to play.
              2. Secret word appears + text that asks user to enter a letter. You start with 5 lives.
              3. If correct, add the letter and the rest remain hidden. Letter that appears twice needs to be revealed at once. 
              4. If wrong, say "Wrong! You lost a life" and then return to nr 2. "You have 4 lives"...
              5. If they guess the same word again, say "You've already tried this letter" and don't remove a life. 
              6. When the word is completed = Win screen. 
              7. When all lives are lost = Losing screen. 
              8. Ask user if they want to play again. */

            Console.Title = "Hangman Game";

            Random randomWords = new Random();                                          //Create a wordlist to allow replayability.  
            List<string> selectionOfWords = new List<string>
            {
                "console", "computer", "coding", "games", "character", "storytelling"
            };

            int index = randomWords.Next(selectionOfWords.Count);
            string chosenWord = selectionOfWords[index];

            Console.WriteLine("Welcome to Hangman! You'll have 5 tries to guess a secret word, letter by letter.");
            Console.WriteLine("Press any key to play: ");
            Console.ReadKey(true);

            Console.Clear();

            Console.WriteLine("The secret word: ");

            foreach (char c in chosenWord)
            {
                Console.Write("_ ");         // Need those iconic dashes in Hangman! 
            }


            int wordLength = chosenWord.Length;
            int lettersWrong = 0;
            int lettersRight = 0;

           /* List<char> alreadyGuessed = new List<char>     
            {
                                                                        Need to do something like this, but not sure how. 
            }; */

            while (lettersWrong != 5 && lettersRight != wordLength)
            {
                Console.WriteLine("\nChoose a letter in the English alphabet and hit Enter: ");
                string userInput = Console.ReadLine();

                foreach (char c in chosenWord)
                {
                    if (userInput.Contains(c.ToString()))    //Can't use bool without converting 
                    {

                        lettersRight++;
                        Console.WriteLine("Correct, that is part of the word.");
                        Console.Beep(500, 500);
                        break;
                    }
                    else
                    {
                        lettersWrong++;
                        Console.WriteLine("Wrong! You lost a life.");
                        Console.Beep(200, 500);
                        break;
                    }
                }

            }
            Console.WriteLine("Thank you for playing the game! :) The secret word was: " + chosenWord);



        }
    }
}
