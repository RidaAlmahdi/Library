using Library.BAL.Helper;
using Library.BAL.IServices;
using Library.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Llibrary.Controllers
{
    public class StackoverflowController : Controller
    {
        private IStackoverflowService _stackoverflowService;
        public StackoverflowController(IStackoverflowService stackoverflowService)
        {
            _stackoverflowService = stackoverflowService;

        }
        public async Task<IActionResult> Index()
        {
            var data = await _stackoverflowService.GetStackoverflowQuestions();
            ViewBag.stackOverflowQuestions = data.items;

            return View();
        }

        [HttpGet("StackoverflowQuestionById/{id}")]
        public async Task<IActionResult> StackoverflowQuestionById(int id)
        {
            var data = await _stackoverflowService.GetStackoverflowQuestionById(id);
            ViewBag.stackOverflowQuestion = data.items;

            return View();
        }


        [HttpGet("api/[controller]/StackoverflowQuestionById/{id}")]
        [Produces(typeof(StackoverflowQuestionViewModel))]
        public async Task<IActionResult> StackoverflowQuestionByIdApi(int id)
        {
            var data = await _stackoverflowService.GetStackoverflowQuestionById(id);

            return Ok(data);
        }


        [HttpGet("api/[controller]/GetStackoverflowQuestions")]
        [Produces(typeof(StackoverflowQuestionsViewModel))]
        public async Task<IActionResult> GetStackoverflowQuestionsApi()
        {
            var data = await _stackoverflowService.GetStackoverflowQuestions();

            return Ok(data);
        }


    }
}
