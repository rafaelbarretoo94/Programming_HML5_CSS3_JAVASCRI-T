using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using JWT.Entities;

namespace JWT.DAO
{
    public class UserDAO
    {
        private IConfiguration _configuration;

        public UserDAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User Find(string userID)
        {
            using (SqlConnection conexao = new SqlConnection(
                _configuration.GetConnectionString("ExemploJWT")))
            {
                return conexao.QueryFirstOrDefault<User>(
                    "SELECT UserID, AccessKey " +
                    "FROM dbo.Users " +
                    "WHERE UserID = @UserID", new { UserID = userID });
            }

        }
    }
}
