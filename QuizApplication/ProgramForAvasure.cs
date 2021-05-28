namespace QuizApplication
{
    public class ProgramForAvasure
    {
        public static void Main(string[] args)
        {
            string expectedPath = @"C:\Users\Brad Berkobien\OneDrive\Desktop\Avasure Interview\QuizAppFileConsumer\FileToConsume.txt";
            string[] lines;
            int errorCount;

            //Create the new quiz file with the path given (override traditional constructor)
            QuizFile quizFile = new QuizFile(expectedPath);

            //Try to get all of the lines in the quizFile
            lines = quizFile.GetAllFileLines();

            //Get the amount of errors in the file
            errorCount = quizFile.SanitizeAndValidateInput(lines);

            //If no errors, Ask the user the questions / show them answers and scores
            if (errorCount == 0)
            {
                quizFile.AskQuestionsAndReturnResultsToUser(lines);
            }


        }
    }
}
