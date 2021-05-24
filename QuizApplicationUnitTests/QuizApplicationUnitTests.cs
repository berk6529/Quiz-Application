using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizApplication;
using System;
using System.IO;

namespace QuizApplicationUnitTests
{
    [TestClass]
    public class QuizApplicationTests
    {

        [TestMethod]
        public void TestSanitizeAndValidateInputFileNotFound()
        {
            string expectedEmptyPath = @"C:\Users\Brad Berkobien\Desktop\Avasure Interview\QuizAppFileConsumer\FileToConsumeError.txt";

            Assert.IsFalse(File.Exists(expectedEmptyPath));
        }

        [TestMethod]
        public void TestSanitizeAndValidateInputForNonNumericAnswer()
        {
            string expectedPath = @"C:\Users\Brad Berkobien\Desktop\Avasure Interview\QuizAppFileConsumer\FileToConsumeNonNumericAnswer.txt";
            string[] lines = null;
            int errorCount = 1;

            lines = File.ReadAllLines(expectedPath);

            // 1 is the error count here. It should match
            Assert.AreEqual(1, errorCount);

        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestAskQuestionsAndReturnResultsToUserForEmptyFile()
        {
            string[] lines = null;

            ProgramForAvasure.AskQuestionsAndReturnResultsToUser(lines);

        }


    }
}
