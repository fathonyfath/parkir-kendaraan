using System;
using System.Collections.Generic;
using WebService.Model;
using System.Data.SqlClient;
using WebService.Util;

namespace WebService.Controller
{
    public class UserService : IUserService
    {
        public bool IsUserExist(string username, string password)
        {
            String query = String.Format(@"SELECT id FROM pegawai WHERE username ='{0}' AND password='{1}';", username, password);
            SqlCommand command = SqlConnectionHelper.Instance.CreateSqlCommand(query);
            SqlDataReader reader = command.ExecuteReader();

            int rows = 0;
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    rows++;
                }
            }

            reader.Close();

            return rows == 1;
        }

        public bool DeleteUser(long id)
        {
            String query = String.Format(@"DELETE FROM pegawai WHERE id={0};", id);
            SqlCommand command = SqlConnectionHelper.Instance.CreateSqlCommand(query);
            int executeDelete = command.ExecuteNonQuery();
            return executeDelete == 1;
        }

        public List<User> FetchUsers()
        {
            List<User> users = new List<User>();
            String query = @"SELECT * FROM pegawai;";
            SqlCommand command = SqlConnectionHelper.Instance.CreateSqlCommand(query);
            SqlDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    User user = new User()
                    {
                        Id = reader.GetInt32(0), 
                        Nama = reader.GetString(1), 
                        Username = reader.GetString(2), 
                        Password = reader.GetString(3)
                    };

                    users.Add(user);
                }
            }
            reader.Close();

            return users;
        }

        public bool UpdateUser(long id, string nama, string username, string password)
        {
            String query = String.Format(@"UPDATE pegawai SET nama='{0}', username='{1}', 
                                        password='{2}' WHERE id={3};", nama, username, password, id);
            SqlCommand command = SqlConnectionHelper.Instance.CreateSqlCommand(query);
            int executeUpdate = command.ExecuteNonQuery();
            return executeUpdate == 1;
        }

        public bool InsertUser(string nama, string username, string password)
        {
            String query = String.Format(@"INSERT INTO pegawai (nama, username, password) VALUES ('{0}', '{1}', '{2}');", nama, username, password);
            SqlCommand command = SqlConnectionHelper.Instance.CreateSqlCommand(query);
            int executeInsert = command.ExecuteNonQuery();
            return executeInsert == 1;
        }
    }
}
