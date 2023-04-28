using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTask.Service.Exceptions
{
    public class TaskLessonException : Exception
    {
        public int Code { get; set; }
        public TaskLessonException(int code = 500, string message = "Something went wrong") : base(message)
        {
            this.Code = code;
        }
    }
}
