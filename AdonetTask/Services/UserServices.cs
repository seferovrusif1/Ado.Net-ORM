using AdonetTask.Helpers;
using AdonetTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdonetTask.Services
{
    internal static class UserServices
    {
        public static int Register(User data)
        {
            //const int keySize = 64;
            //const int iterations = 350000;
            //string pas = data.Password;

            //HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

            //byte[] salt = RandomNumberGenerator.GetBytes(keySize);
            //var hash = Rfc2898DeriveBytes.Pbkdf2(
            //    Encoding.UTF8.GetBytes(data.Password),
            //    salt,
            //    iterations,
            //    hashAlgorithm,
            //    keySize);

            return SqlHelpers.Exec($"INSERT INTO Users VALUES (N'{data.Name}', N'{data.Surame}', N'{data.Password}',N'{data.UserName}')");
        }
        public static bool Login(string username, string password) 
        {
            bool okay = false;
            DataTable? users= SqlHelpers.GetDatas($"SELECT * FROM Users");
            foreach (DataRow item in users.Rows)
            {
                if ((string)item[3]== password && (string)item[4] ==username)
                { 
                    Console.WriteLine("Login olundu");
                    okay= true;
                }
            }
                return okay;   
        }
    }
}
