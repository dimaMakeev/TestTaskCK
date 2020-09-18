using System.Collections.Generic;

namespace TestTaskCK
{
    public class Responce
    {

        public string result { get; set; }
        public int http_status { get; set; }
        public List<Error> errors { get; set; }

    
    }

    public class Error
    {
        public string code { get; set; }
        public string message { get; set; }
    }
}