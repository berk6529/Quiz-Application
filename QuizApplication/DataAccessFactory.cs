using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApplication
{
    public class DataAccessFactory
    {
        public static IQuizFile GetQuizFileDataAccessObj()
        {
            return new QuizFile();
        }
    }
}
