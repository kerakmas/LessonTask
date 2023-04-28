using LessonTask.Service.DTOs.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTask.Service.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResultDto> AuthenticateAsync(string email, string password);
    }
}
