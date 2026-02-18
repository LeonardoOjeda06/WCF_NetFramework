using DemoWCF.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Business.Services
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        bool Exists(string name);

        [OperationContract]
        List<UserDto> GetAll();


        [OperationContract]
        void Add(UserDto user);

        [OperationContract]
        void Update(UserDto user);

        [OperationContract]
        void Delete(int id);
    }
}
