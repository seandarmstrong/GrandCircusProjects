using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatinTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator!\n");
            do
            {
                string userInput = UserInput();
                StringBuilder transitionWord = CreateNewSentence(userInput);
                string finalString = String.Join("", transitionWord).ToLower();
                OutputResults(finalString, userInput);
            } while (ContinueProgram());
        }

        //this function obtains the user input, removes any white space before or after the sentence, and validates
        //that the user entered text.
        public static string UserInput()
        {
            Console.Write("Enter sentence(s) to be translated: ");
            while (true)
            {
                string userInput = Console.ReadLine().Trim();
                if (CheckUserEntry(userInput))
                {
                    return userInput;

                }
                else
                {
                    return UserInput();
                }
            }

        }

        //this function validates the user has entered something into the console.
        public static bool CheckUserEntry(string userInput)
        {
            return !string.IsNullOrWhiteSpace(userInput);
        }

        //this function validates if the user has entered all UPPERCASE.
        public static bool IsAllUpper(string userInput)
        {
            for (int i = 0; i < userInput.Length; i++)
            {
                if (Char.IsLetter(userInput[i]) && !Char.IsUpper(userInput[i]))
                    return false;
            }
            return true;
        }

        //this function validates if the user has entered all lowercase.
        public static bool IsAllLower(string userInput)
        {
            for (int i = 0; i < userInput.Length; i++)
            {
                if (Char.IsLetter(userInput[i]) && !Char.IsLower(userInput[i]))
                    return false;
            }
            return true;
        }

        //this function validates if the User Has Entered Title Case.
        public static bool IsTitleCase(string userInput)
        {
            if (userInput.Split().All(p => p.Substring(0, 1) == p.Substring(0, 1).ToUpper()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //this function determines if the word starts with a vowel using a char array.
        public static bool StartsWithVowel(string userInput)
        {
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            char vowel = userInput[0];
            if (vowels.Contains(vowel))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //this function translates words that begin with a vowel.
        public static string TranslateVowelWord(string userInput)
        {
            return userInput.Insert((userInput.Length), "way");
        }

        //this function translate words that begin with a consonant, including "y".
        public static string TranslateConsonantWord(string userInput)
        {
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            int firstVowelIndex = userInput.IndexOfAny(vowels);
            //this if statement tests if the word only contains consonants and handles those words with a hyphen.
            if (firstVowelIndex > 0)
            {

                char[] consonants = userInput.ToCharArray(0, firstVowelIndex);
                string firstConsonants = new string(consonants);
                string adjustedWord = userInput.Remove(0, firstVowelIndex);
                return $"{adjustedWord}{firstConsonants}ay";
            }
            else
            {

                char[] allConsonants = userInput.ToCharArray(0, (userInput.Length - 1));
                string justConsonants = new string(allConsonants);
                string adjustedWord2 = userInput.Remove(0, (userInput.Length - 1));
                return $"{adjustedWord2}-{justConsonants}ay";
            }
        }

        //this function calls the translation methods depending on what the word starts with
        public static string TranslateToPigLatin(string word)
        {
            if (StartsWithVowel(word))
            {
                return TranslateVowelWord(word);
            }
            else
            {
                return TranslateConsonantWord(word);
            }
        }

        //this function builds the new sentence, accounting for special characters, punctuation, and numbers.
        public static StringBuilder CreateNewSentence(string userInput)
        {
            StringBuilder transitionWord = new StringBuilder();
            string[] inputWords = userInput.Split(' ');
            var first = inputWords.First();
            var last = inputWords.Last();
            var regexItem = new Regex("^[a-zA-Z?!.:,;'\"]*$");
            foreach (var word in inputWords)
            {
                //determines if the next word in the loop is the last word of the array
                if (word.Equals(last))
                {
                    //determines if the sentence contains any special characters or numbers
                    if (regexItem.IsMatch(word))
                    {
                        if (word == last)
                        {
                            int punctuationIndex = word.Length - 1;
                            if (Char.IsPunctuation(word, punctuationIndex))
                            {
                                if (word.Contains("\""))
                                {
                                    char[] punctuation = new char[] { word[punctuationIndex], word[0] };
                                    string modifiedWord = Regex.Replace(word, @"\p{P}", "");
                                    transitionWord.Append(punctuation[1]).Append(TranslateToPigLatin(modifiedWord)).Append(punctuation[1]).Append(punctuation[0]);
                                }
                                else
                                {
                                    char[] punctuation = new char[] { word[punctuationIndex] };
                                    string modifiedWord = word.Remove(punctuationIndex, 1);
                                    transitionWord.Append(TranslateToPigLatin(modifiedWord)).Append(punctuation);
                                }

                            }
                            else
                            {
                                transitionWord.Append(TranslateToPigLatin(word));
                            }
                        }
                    }
                    else
                    {
                        transitionWord.Append(word);
                    }
                }
                else if (regexItem.IsMatch(word))
                {
                    int punctuationIndex = word.Length - 1;
                    if (Char.IsPunctuation(word, punctuationIndex))
                    {
                        if (word.Contains("\""))
                        {
                            if (word.Contains(",") || word.Contains(".") || word.Contains("?") || word.Contains("!") || word.Contains(";") || word.Contains(":"))
                            {
                                char[] punctuation = new char[] { word[punctuationIndex], word[0] };
                                string modifiedWord = Regex.Replace(word, @"\p{P}", "");
                                transitionWord.Append(punctuation[1]).Append(TranslateToPigLatin(modifiedWord)).Append(punctuation[1]).Append(punctuation[0]).Append(" ");
                            }
                            else
                            {
                                char[] punctuation = new char[] { word[punctuationIndex], word[0] };
                                string modifiedWord = Regex.Replace(word, @"\p{P}", "");
                                transitionWord.Append(punctuation[1]).Append(TranslateToPigLatin(modifiedWord)).Append(punctuation[1]).Append(" ");
                            }
                        }
                        else
                        {
                            char[] punctuation = new char[] { word[punctuationIndex] };
                            string modifiedWord = word.Remove(punctuationIndex, 1);
                            transitionWord.Append(TranslateToPigLatin(modifiedWord)).Append(punctuation).Append(" ");
                        }

                    }
                    else
                    {
                        transitionWord.Append(TranslateToPigLatin(word)).Append(" ");
                    }
                }
                else
                {
                    transitionWord.Append(word).Append(" ");
                }
            }
            return transitionWord;
        }

        //this function displays the new sentence in the same casing of the sentence (upper, lower, title, or sentence)
        public static void OutputResults(string finalString, string userInput)
        {
            TextInfo tempTI = new CultureInfo("en-US", false).TextInfo;
            if (IsAllUpper(userInput))
            {
                Console.WriteLine(tempTI.ToUpper(finalString));
            }
            else if (IsAllLower(userInput))
            {
                Console.WriteLine(tempTI.ToLower(finalString));
            }
            else if (IsTitleCase(userInput))
            {
                Console.WriteLine(tempTI.ToTitleCase(finalString));
            }
            else
            {
                string sentenceCase = char.ToUpper(finalString[0]) + finalString.Substring(1);
                Console.WriteLine(sentenceCase);
            }
        }

        //this function asks the user if they would like to continue the program and then continues or exits depending
        //on the user input
        private static bool ContinueProgram()
        {
            bool proceed;
            Console.Write("Translate another sentence/more sentences (y/n)? ");
            string input = Console.ReadLine();
            input = input.ToLower();

            //if statement will use user's input and determine whether or not to change the value of program in the while loop.
            if (input == "y")
            {
                proceed = true;
            }
            else if (input == "n")
            {
                proceed = false;
            }
            else
            {
                return ContinueProgram();
            }
            //end of if statement
            return proceed;
        }
    }
}
