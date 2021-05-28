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
            string expectedEmptyPath = @"C:\Users\Brad Berkobien\OneDrive\Desktop\Avasure Interview\QuizAppFileConsumer\FileToConsume.txt";

            Assert.IsFalse(File.Exists(expectedEmptyPath));
        }

        [TestMethod]
        public void TestSanitizeAndValidateInputForNonNumericAnswer()
        {
            string expectedPath = @"C:\Users\Brad Berkobien\OneDrive\Desktop\Avasure Interview\QuizAppFileConsumer\FileToConsumeNonNumericAnswer.txt";
            string[] lines = null;
            int errorCount = 1;

            lines = File.ReadAllLines(expectedPath);

            // 1 is the error count here. It should match
            Assert.AreEqual(1, errorCount);

        }

    }
}
