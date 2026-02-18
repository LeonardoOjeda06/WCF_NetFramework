using DemoWCF.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public interface IUserRepository
    {
        bool Exisiting(string name);
        List<UserEntity> GetAll();

        void Insert(UserEntity entity);
        void Update(UserEntity entity);
        void Delete(int Id);
    }
}
