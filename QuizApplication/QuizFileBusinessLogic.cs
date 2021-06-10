using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApplication
{
    public class QuizFileBusinessLogic
    {
        IQuizFile _quizFileDataAccess;

        public QuizFileBusinessLogic()
        {
            _quizFileDataAccess = DataAccessFactory.GetQuizFileDataAccessObj();
        }
    }
}
