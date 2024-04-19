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
        void DisplayUsers();
        void DeleteUser(int id);
        void UpdateUser(int id, string name);

    }
}
