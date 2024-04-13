using FileDB.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDB.Services.Users
{
    internal interface IUserService
    {
        User AddUser(User contact);
        void ShowUsers();
        void Update(User contact);
        void Delete(int id);
    }
}
