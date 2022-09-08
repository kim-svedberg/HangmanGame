using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;

namespace HangmanGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "Hangman Game";

            //Wordlist to allow replayability.  
            Random randomWords = new Random();
            List<string> selectionOfWords = new List<string>
            {
               
                "console", "computer", "coding", "games", "character", "storytelling"
            };

            //Welcoming screen.
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("\n\r");
            Console.WriteLine("You'll have 5 tries to guess a secret word, letter by letter.");
            Console.WriteLine("\n\r");
            Console.WriteLine("Want to add your own word? Press Y and then Enter.");
            Console.WriteLine("\n\r");
            Console.WriteLine("Otherwise, just hit Enter to play."); 
            string choosingYesOrContinue = Console.ReadLine();
            Console.Clear();    

            //Room for improvement: Stop the program from crashing when user enters invalid answers. 

            string yesAddWord = "Y";
            if (choosingYesOrContinue == yesAddWord)
            {
                Console.Clear();
                Console.Write("Type your word and hit Enter to add it: ");
                string usersOwnWord = Console.ReadLine();
                Console.Clear();
                Console.WriteLine(usersOwnWord + " has been added. Press any key to play.");
                selectionOfWords.Add(usersOwnWord);
                Console.ReadKey(true);
                Console.Clear();

            }


            //Randomly selects one of the words, which becomes the string-array "chosenWord". 
            // Good: Creates dashes which are iconic for the game. 
            //Improvement: Would look neater with spaces in-between the dashes.
            int index = randomWords.Next(selectionOfWords.Count);
            string chosenWord = selectionOfWords[index];
            StringBuilder hidingChosenWord = new StringBuilder();

            for (int i = 0; i < chosenWord.Length; i++)
            {
                hidingChosenWord.Append("_");
            }
            Console.Write(hidingChosenWord);

            //Need to create variables so that the user can't:
            // 1) Be wrong more than 5 times
            // 2) Guess the same letter more than once 
            // 3) Continue guessing once all the correct letters have been found. 
            int wordLength = chosenWord.Length;
            int lettersWrong = 0;
            int lettersRight = 0;

            //A list for exhausted letters so that user doesn't lose a life/gain success if they guess the same letter again. 
            List<char> alreadyGuessedLetters = new List<char> { };


            //Entering letters. 3 cases: (1) user already entered the letter, (2) the letter is correct, (3) the letter is wrong. 
            //Loop ends when an outcome is triggered: (1) the user loses after entering an incorrect letter 5 times, (2) all correct letters have been entered and the user wins. 
            while (lettersWrong <= 5 && lettersRight != wordLength)
            {

                Console.Write("\nChoose a letter in the English alphabet and hit Enter: ");
                string userInput = Console.ReadLine();
                char userGuess = char.Parse(userInput);

                //Room for improvement: If the user enters a capital letter, the program should still recognize it & convert it to lowercase. 


                if (alreadyGuessedLetters.Contains(userGuess))
                {
                    Console.WriteLine("You have already guessed this letter.");
                }

                else
                {

                    bool right = false;
                    for (int i = 0; i < chosenWord.Length; i++)
                    { if (userGuess == chosenWord[i]) { right = true; } }


                    if (right)
                    {
                       
                        alreadyGuessedLetters.Add(userGuess);
                        Console.WriteLine("Correct, that is part of the word.");
                        Console.Beep(500, 500);


                        for (int k = 0; k < chosenWord.Length; k++)
                        {
                            if (userGuess == chosenWord[k])
                            {

                                hidingChosenWord[k] = userGuess;
                                lettersRight++;
                            }
                        }

                    }

                    else
                    {
                        lettersWrong += 1;
                        alreadyGuessedLetters.Add(userGuess);
                        Console.WriteLine("Wrong! You lost a life.");
                        Console.Beep(200, 500);
                    }
                    
                    
                    Console.WriteLine(hidingChosenWord);

                }

               
                // Outcome 1) You lose
                if (lettersWrong == 5)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.WriteLine("You lost the game! :( The secret word was: " + chosenWord);
                    Console.Beep(250, 500);
                    Console.Beep(200, 500);
                    Console.Beep(150, 500);
                    break;
                }
                // Outcome 2) You win
                else if (lettersRight == wordLength) 
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.WriteLine("You won the game! :) The secret word was: " + chosenWord);
                    Console.Beep(200, 500);
                    Console.Beep(250, 500);
                    Console.Beep(300, 500);

                    
                    
                    //Good: Two different sounds and colors when winning/losing. 
                   

                }

              





            }
        }
    }
} 