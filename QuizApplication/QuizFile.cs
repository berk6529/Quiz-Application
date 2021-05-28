using System;
using System.IO;

namespace QuizApplication
{

    public class QuizFile
    {
        public string Path { get; set; }
        public string[] Lines { get; set; }

        public QuizFile()
        {
            Path = string.Empty;
        }

        public QuizFile(string path)
        {
            Path = path;
        }

        public string[] GetAllFileLines()
        {
            try
            {
                Lines = File.ReadAllLines(Path);
                return Lines;
            }
            catch
            {
                Console.WriteLine("There is no file to be read. Please place a quiz text file in the correct path: {0}", Path);
                Environment.Exit(-1);
                return null;
            }

        }


        /// <summary>
        /// This method performs the following operations:
        /// 1. Checks if the user shows an answer that is non-numeric
        /// </summary>
        /// <param name="lines">All of the lines found in the text files</param>
        /// <returns>The amount of errors found</returns>
        public int SanitizeAndValidateInput(string[] lines)
        {
            /*TODO: There is more that you can sanitize here (and unit test)
             * 1. Rearrange Questions
             * 2. Are they allowed a certain number Response Numbers? 
             * 3. Random characters and such within file
             * 4. ETC
             * */
            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                int answer;

                //Answers are non-numeric
                if (trimmedLine.Length == 1 && !int.TryParse(trimmedLine, out answer))
                {
                    Console.WriteLine("One of your answers is invalid: {0}", line);
                    return 1;
                }
            }
            return 0;
        }


        /// <summary>
        /// This method performs the following operations:
        /// 1. Loops through file and shows questions one at a time (based off of the answer line)
        /// 2. Let's user answer (shows them if their answer was correct/incorrect) ; Reports correct answer if need be
        /// 3. Prints the users score percentage at the end
        /// </summary>
        /// <param name="lines">All of the lines found in the text files</param>
        public void AskQuestionsAndReturnResultsToUser(string[] lines)
        {
            int correctAnswers = 0, totalQuestions = 0, score = 0;

            if (lines != null)
            {
                foreach (string line in lines)
                {
                    string trimmedLine = line.Trim();
                    int answer;

                    //Check for the answer line
                    if (trimmedLine.Length == 1 && int.TryParse(trimmedLine, out answer))
                    {
                        totalQuestions++;

                        string userAnswerInput = Console.ReadLine();

                        //The user selected the right answer
                        if (line == userAnswerInput)
                        {
                            Console.WriteLine("Your answer is correct. Nice Work!!! \n");
                            correctAnswers++;
                        }
                        else
                        {
                            Console.WriteLine("Your answer is incorrect, the correct answer is number {0}. \n", answer);
                        }
                    }
                    else
                    {
                        Console.WriteLine(line);
                    }

                }

                if (totalQuestions != 0)
                {
                    // Rounds users correct answer score up
                    score = CalculateScore(correctAnswers, totalQuestions);
                }

                // Prints the score
                Console.WriteLine("You answered {0} questions correctly out of {1}. Your score on this quiz is %{2}", correctAnswers, totalQuestions, score);

            }

        }

        public int CalculateScore(int correctAnswers, int totalQuestions)
        {
            return (int)Math.Round((double)(100 * correctAnswers) / totalQuestions);
        }

    }
}
