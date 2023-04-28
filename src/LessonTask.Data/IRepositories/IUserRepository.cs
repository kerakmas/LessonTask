using LessonTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LessonTask.Data.IRepositories
{
    public interface IUserRepository
    {
        Task<User> InsertAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(long Id);
        Task<User> SelectAsync(Expression<Func<User, bool>> predicate);
        IQueryable<User> SelectAll();
    }
}
