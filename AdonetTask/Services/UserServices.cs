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
       
            return SqlHelpers.Exec($"INSERT INTO Users VALUES (N'{data.Name}', N'{data.Surame}', N'{Hash.Encrypt(data.Password,"aa")}',N'{data.UserName}')");
        }
        public static int Login(string username, string password) 
        {
            int okay = -1;
            DataTable? users= SqlHelpers.GetDatas($"SELECT * FROM Users");
            foreach (DataRow item in users.Rows)
            {
                if ((string)item[3]== Hash.Encrypt(password, "aa") && (string)item[4] ==username)
                { 
                    Console.WriteLine("Login olundu");
                    okay= (int)item[0];
                }
            }
            Console.WriteLine(  okay);
            return okay;   
        }
    }
}
