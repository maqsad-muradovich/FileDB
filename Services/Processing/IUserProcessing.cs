using FileDB.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDB.Services.Processing
{
    internal interface IUserProcessing
    {
        User CreateNewUser(string name);
        List<User> DisplayUsers();
        void DeleteUser(int id);
        bool UpdateUser(int id, string name);

    }
}
