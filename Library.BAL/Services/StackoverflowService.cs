using Library.BAL.Helper;
using Library.BAL.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Library.BAL.Services
{
    public class StackoverflowService : IStackoverflowService
    {
        public async Task<StackoverflowQuestionsViewModel> GetStackoverflowQuestions()
        {
            try
            {
                List<StackoverflowQuestionsViewModel> stackoverflowQuestions = new List<StackoverflowQuestionsViewModel>();

                var webRequest = (HttpWebRequest)WebRequest.Create("https://api.stackexchange.com/2.3/questions?page=1&pagesize=50&order=desc&sort=activity&site=stackoverflow");
                webRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                var response = "";

                using (var webResponse = webRequest.GetResponse())
                using (var sr = new StreamReader(webResponse.GetResponseStream()))
                {
                    response = sr.ReadToEnd();
                }

                var allData = JsonConvert.DeserializeObject<StackoverflowQuestionsViewModel>(response);

                return allData;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<StackoverflowQuestionViewModel> GetStackoverflowQuestionById(int id)
        {
            try
            {


                var webRequest = (HttpWebRequest)WebRequest.Create($"https://api.stackexchange.com/2.3/questions/{id}?order=desc&sort=activity&site=stackoverflow");
                webRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                var response = "";

                using (var webResponse = webRequest.GetResponse())
                using (var sr = new StreamReader(webResponse.GetResponseStream()))
                {
                    response = sr.ReadToEnd();
                }

                var allData = JsonConvert.DeserializeObject<StackoverflowQuestionViewModel>(response);

                return allData;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}

    


