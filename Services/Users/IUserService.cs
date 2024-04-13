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
        void ShowUsers();
        void Update(User user);
        void Delete(int id);
    }
}
