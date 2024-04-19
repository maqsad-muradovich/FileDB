using System;
using System.Linq;
using System.Text;
using FileDB.Models.Users;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FileDB.Services.Users
{
    internal interface IUserService
    {
        User AddUser(User user);
        List<User> AllUsers();
        bool Update(User user);
        void Delete(int id);
    }
}
