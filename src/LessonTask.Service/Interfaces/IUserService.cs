using LessonTask.Domain.Configurations;
using LessonTask.Domain.Entities;
using LessonTask.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTask.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserResultDto> AddAsync(UserCreationDto dto);
        Task<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParamas @params);
        Task<bool> RemoveAsync(long id);
        Task<UserResultDto> RetrieveByIdAsync(long id);
        Task<UserResultDto> ModifyAsync(long id, UserCreationDto dto);
        Task<User> RetrieveByEmailAsync(string email);
    }
}
