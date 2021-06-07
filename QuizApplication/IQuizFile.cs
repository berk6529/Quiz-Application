namespace QuizApplication
{
    public interface IQuizFile
    {
        string[] Lines { get; set; }
        string Path { get; set; }
        void AskQuestionsAndReturnResultsToUser(string[] lines);
        int CalculateScore(int correctAnswers, int totalQuestions);
        string[] GetAllFileLines();
        int SanitizeAndValidateInput(string[] lines);
    }
}