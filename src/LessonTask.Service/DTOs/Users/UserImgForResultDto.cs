using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTask.Service.DTOs.Users
{
    public class UserImgForResultDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public long UserId { get; set; }
    }
}
