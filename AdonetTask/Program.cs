using AdonetTask.Models;
using AdonetTask.Services;
using System.Xml.Linq;

namespace AdonetTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BlogServices bs = new BlogServices();
            User u;
            Blogs blog;
            int userid,id;
            int b;
            Blogs blogg;
            string Name, Surname,Password,UserName;
            bool iscontinue = true;
            while (iscontinue)
            {
                Console.WriteLine("1. Register\n2. Login\n3. GetAllBlogs\n4. Get blogs by id \n5. Create Blog\n6. Delete\n7. update");
                string a=Console.ReadLine();
                switch (a)
                {
                    case "1":
                        Console.WriteLine("Name: ");
                        Name = Console.ReadLine();
                        Console.WriteLine("SurName: ");
                        Surname = Console.ReadLine();
                        Console.WriteLine("Password: ");
                        Password = Console.ReadLine();
                        Console.WriteLine("UserName: ");
                        UserName = Console.ReadLine();
                        u = new User()
                        {
                            Name = Name,
                            Surame = Surname,
                            Password = Password,
                            UserName = UserName
                        };
                        UserServices.Register(u);
                        break;
                    case "2":
                        Console.WriteLine("Password: ");
                        Password = Console.ReadLine();
                        Console.WriteLine("UserName: ");
                        UserName = Console.ReadLine();
                        if (!UserServices.Login(UserName, Password))
                        {
                            Console.WriteLine("Login ugursuzdur");
                        }
                        break;
                    case "3":
                        foreach ( Blogs item in bs.GetAll())
                        {
                            Console.WriteLine($"{item.id} {item.Title}  {item.Description}   {item.UserId}");
                        }
                        
                        break;
                    case "4":
                        Console.WriteLine("Id daxil edin: ");
                         b= Convert.ToInt32(Console.ReadLine());
                         var bblogg=bs.GetById(b);
                        Console.WriteLine($"{bblogg.id} {bblogg.Title}  {bblogg.Description}   {bblogg.UserId}");

                        break;
                    case "5":
                        Console.WriteLine("Title: ");
                        Name = Console.ReadLine();
                        Console.WriteLine("Description: ");
                        Surname = Console.ReadLine();
                        Console.WriteLine("UserId: ");
                        userid=Convert.ToInt32(Console.ReadLine());

                        blog = new Blogs()
                        {
                            Title = Name,
                            Description = Surname,
                            UserId = userid
                        };
                        bs.Create(blog);
                        break;
                        case "6":

                        Console.WriteLine("Id daxil edin: ");
                         b = Convert.ToInt32(Console.ReadLine());
                        bs.Delete(b);
                        break;
                    case "7":
                        Console.WriteLine("Title: ");
                        Name = Console.ReadLine();
                        Console.WriteLine("Description: ");
                        Surname = Console.ReadLine();
                        Console.WriteLine("Id: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        
                        bs.Update(Name,Surname,id);
                        break;
                }
            }
       
        }
    }
}