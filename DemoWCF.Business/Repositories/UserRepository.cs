using DemoWCF.Model.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Business.Repositories
{
    public class UserRepository : IUserRepository
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["connectionDB"].ConnectionString;

        public bool Exisiting(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new FaultException("El nombre no puede estar vacio");

            using (SqlConnection db = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.SP_User_CRUD", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Action", "EXISTS");
                    cmd.Parameters.AddWithValue("name", name);

                    try
                    {
                        db.Open();
                        var response = Convert.ToInt32(cmd.ExecuteScalar()); //Se usa porque devuelve un unico resultado
                        return response > 0 ? true : false;
                    }
                    catch
                    {
                        throw new FaultException("Error al buscar el usuario");
                    }
                }
            }
        }

        public List<UserEntity> GetAll()
        {
            List<UserEntity> userList = new List<UserEntity>();

            using (SqlConnection db = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.SP_User_CRUD", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Action", "SELECT");

                    try
                    {
                        db.Open();

                        using (SqlDataReader dataReader = cmd.ExecuteReader()) //Se usa porque devuelve multiples filas de datos
                        {
                            while (dataReader.Read())
                            {
                                UserEntity userItem = new UserEntity();
                                userItem.Id = Convert.ToInt32(dataReader["Id"]);
                                userItem.Name = dataReader["Name"].ToString();
                                userItem.Gender = Convert.ToChar(dataReader["Gender"]);
                                userItem.Birthdate = Convert.ToDateTime(dataReader["Birthdate"]);

                                userList.Add(userItem);
                            }
                        }
                    }
                    catch
                    {
                        throw new FaultException("Error al obtener los usuarios");
                    }
                }
            }

            return userList;
        }


        public void Insert(UserEntity entity)
        {
            if (entity == null)
                throw new FaultException("Usuario inválido");

            var userExists = Exisiting(entity.Name);

            if (userExists)
                throw new FaultException("Usuario existente");

            using (SqlConnection db = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.SP_User_CRUD", db))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Action", "INSERT");
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@Gender", entity.Gender);
                    cmd.Parameters.AddWithValue("@Birthdate", entity.Birthdate);

                    try
                    {
                        db.Open();
                        //se usa porque ejecuta un comando SQL que no devuelve filas de datos
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        throw new FaultException("Error al insertar usuario");
                    }
                }
            }
        }

        public void Update(UserEntity entity)
        {
            if (entity == null)
                throw new FaultException("Usuario inválido");

            using (SqlConnection db = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.SP_User_CRUD", db))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Action", "UPDATE");
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@Gender", entity.Gender);
                    cmd.Parameters.AddWithValue("@Birthdate", entity.Birthdate);

                    try
                    {
                        db.Open();
                        //se usa porque ejecuta un comando SQL que no devuelve filas de datos
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        throw new FaultException("Error al actualizar el usuario");
                    }
                }

            }
        }

        public void Delete(int Id)
        {
            if (Id < 1) 
                throw new FaultException("Error Id invalido");

            using (SqlConnection db = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_User_CRUD", db))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Action", "DELETE");
                    cmd.Parameters.AddWithValue("@Id", Id);

                    try
                    {
                        db.Open();
                        //se usa porque ejecuta un comando SQL que no devuelve filas de datos
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        throw new FaultException("Error al eliminar el usuario");
                    }
                }
            }
        }
    }
}