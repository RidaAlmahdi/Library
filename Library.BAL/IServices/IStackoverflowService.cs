using Library.BAL.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.BAL.IServices
{
    public interface IStackoverflowService
    {

        Task<StackoverflowQuestionsViewModel> GetStackoverflowQuestions();
        Task<StackoverflowQuestionViewModel> GetStackoverflowQuestionById(int id);

    }
}
