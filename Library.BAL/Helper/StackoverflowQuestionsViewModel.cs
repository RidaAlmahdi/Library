using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BAL.Helper
{
    public class StackoverflowQuestionsViewModel
    {
        public List<Item> items{ get; set; }

       
    }

    public class Item
    {
        public int question_id { get; set;}
        public Owner owner { get; set;}
        public string title { get; set;}
        public string link { get; set;}
    }

    public class Owner
    {
        public string display_name { get; set; }
    }
}
