using LessonTask.Data.Contexts;
using LessonTask.Data.IRepositories;
using LessonTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace LessonTask.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> DeleteAsync(long Id)
        {
            User entity = await this.appDbContext.Users.FirstOrDefaultAsync(user => user.Id == Id);
            if (entity is null)
            {
                return false;
            }
            this.appDbContext.Remove(entity);
            await this.appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<User> InsertAsync(User user)
        {
            EntityEntry<User> entity = await this.appDbContext.Users.AddAsync(user);
            await this.appDbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public IQueryable<User> SelectAll()=>
                 this.appDbContext.Users;


        public async Task<User> SelectAsync(Expression<Func<User, bool>> predicate)
        {
            return await this.appDbContext.Users.FirstOrDefaultAsync(predicate);
        }




        public async Task<User> UpdateAsync(User user)
        {
            EntityEntry<User> entity = this.appDbContext.Users.Update(user);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }
    }
}