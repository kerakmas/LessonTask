﻿using LessonTask.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTask.Domain.Entities
{
    public class UserImage : Auditable
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
