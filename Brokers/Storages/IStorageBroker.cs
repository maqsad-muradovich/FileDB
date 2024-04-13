using System;
using System.IO;
using System.Linq;
using System.Text;
using FileDB.Models.Users;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FileDB.Brokers.Storages
{
    internal interface IStorageBroker
    {
        User AddUser(User user);
        List<User> ReadAllUsers();
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
