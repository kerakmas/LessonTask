﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTask.Service.DTOs.Users
{
    public class UserImgForCreationDto
    {
        public IFormFile Image { get; set; }
        public long UserId { get; set; }

    }
}
