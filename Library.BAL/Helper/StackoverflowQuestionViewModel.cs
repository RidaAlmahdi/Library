using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BAL.Helper
{
    public class StackoverflowQuestionViewModel
    {
        public List<Details> items{ get; set; }

    }

    public class Details
    {
        public int question_id { get; set;}
        public Person owner { get; set;}
        public string title { get; set;}
        public string link { get; set;}
        public bool is_answered { get; set;}
        public int view_count { get; set;}
        public int answer_count { get; set;}
        public int score { get; set;}
    }

    public class Person
    {
        public string display_name { get; set; }
    }
}
