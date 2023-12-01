using AdonetTask.Helpers;
using AdonetTask.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdonetTask.Services
{
    internal class BlogServices : IBaseServices<Blogs>
    {
        public int Create(Blogs data)
        {
            return SqlHelpers.Exec($"INSERT INTO Blogs VALUES (N'{data.Title}', N'{data.Description}',{data.UserId} )");
        }


        public ICollection<Blogs> GetAll()
        {
            DataTable dt = SqlHelpers.GetDatas("SELECT * FROM Blogs");
            ICollection<Blogs> list = new List<Blogs>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Blogs
                {
                    id = (int)row["Id"],
                    Title = (string)row["Title"],
                    Description = (string)row["Description"],
                    UserId = (int)row["UserId"]
                });
            }
            return list;
        }
        public Blogs GetById(int id)
        {
            DataTable dt = SqlHelpers.GetDatas($"SELECT * FROM Blogs Where Id={id}");
            foreach (DataRow row in dt.Rows)
            {
                Blogs blog = new Blogs
                {
                    id = (int)row["Id"],
                    Title = (string)row["Title"],
                    Description = (string)row["Description"],
                    UserId = (int)row["UserId"]
                };
                return blog;
            }
            return null;
        }
        public void Delete(int id)
        {
            Console.WriteLine(SqlHelpers.Exec($"delete  from Blogs where Blogs.id={id}"));
        }
        public void Update(string name,string surname,  int id)
        {

            SqlHelpers.Exec($"UPDATE dbo.Blogs SET Title =N'{name}', Description = N'{surname}' WHERE id={id}");


        }
    }
}