using Business.Repositories;
using DemoWCF.Model.Dtos;
using DemoWCF.Model.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository = new UserRepository();

        public bool Exists(string name)
        {
            return _userRepository.Exisiting(name);
        }

        public List<UserDto> GetAll()
        {
            var userList = _userRepository.GetAll();
            return userList.Select(user => UserMapper.ToDto(user)).ToList();
        }


        public void Add(UserDto user)
        {
            var entity = UserMapper.ToEntity(user);
            _userRepository.Insert(entity);
        }

        public void Update(UserDto user)
        {
            var entity = UserMapper.ToEntity(user);
            _userRepository.Update(entity);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
