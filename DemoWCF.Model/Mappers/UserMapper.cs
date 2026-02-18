using DemoWCF.Model.Dtos;
using DemoWCF.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWCF.Model.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(UserEntity entity)
        {
            return new UserDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Gender = entity.Gender == 'M' ? "Masculino" : "Femenino",
                Birthdate = entity.Birthdate
            };
        }

        public static UserEntity ToEntity(UserDto dto)
        {
            return new UserEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Gender = dto.Gender == "Masculino" ? 'M' : 'F',
                Birthdate = dto.Birthdate
            };
        }
    }
}
