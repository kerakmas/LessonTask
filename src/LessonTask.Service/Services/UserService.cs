using AutoMapper;
using LessonTask.Data.IRepositories;
using LessonTask.Domain.Configurations;
using LessonTask.Domain.Entities;
using LessonTask.Service.DTOs.Users;
using LessonTask.Service.Exceptions;
using LessonTask.Service.Interfaces;
using LessonTask.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LessonTask.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

      
        public async Task<UserResultDto> AddAsync(UserCreationDto dto)
        {
            var existUser = await userRepository.SelectAsync(u => u.Email == dto.Email);
            if (existUser != null)
                throw new TaskLessonException(409, "User already exist");
         
            var mapped = this.mapper.Map<User>(dto);
            mapped.CreatedAt = DateTime.UtcNow;
            mapped.Password = PasswordHasher.Hash(dto.Password);
            var addedModel = await userRepository.InsertAsync(mapped);

            return this.mapper.Map<UserResultDto>(addedModel);
        }
        public async Task<bool> RemoveAsync(long id)
        {
            var user = await this.userRepository.SelectAsync(u => u.Id == id);
            if (user is null)
                throw new TaskLessonException(404, "Not Found");

            await this.userRepository.DeleteAsync(id);


            return true;
        }

   
        public async Task<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParamas @params)
        {
            var users = await userRepository.SelectAll()
                                        .ToPagedList(@params).ToListAsync();

            return this.mapper.Map<IEnumerable<UserResultDto>>(users);
        }
     
        public async Task<UserResultDto> RetrieveByIdAsync(long id)
        {
            var user = await this.userRepository.SelectAsync(u => u.Id == id);
            if (user is null)
                throw new TaskLessonException(404, "User Not Found");

            return this.mapper.Map<UserResultDto>(user);
        }
        public async Task<UserResultDto> ModifyAsync(long id, UserCreationDto dto)
        {
            var user = await this.userRepository.SelectAsync(u => u.Id == id);
            if (user is null)
                throw new TaskLessonException(404, "Couldn't found user for given Id");

            var modifiedUser = this.mapper.Map(dto, user);
            modifiedUser.UpdatedAt = DateTime.UtcNow;


            return this.mapper.Map<UserResultDto>(user);
        }
        public async Task<User> RetrieveByEmailAsync(string email)
        {
            var user = await this.userRepository.SelectAsync(u => u.Email == email);
            if (user is null)
                throw new TaskLessonException(404, "User Not Found");

            return user;
        }
    }
}
