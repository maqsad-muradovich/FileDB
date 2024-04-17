using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDB.Services.Processing
{
    internal interface IUserProcessing
    {
        public void CreateNewUser(string name);
        public void DisplayUsers();
        public void DeleteUser(int id);
        public void UpdateUser(int id, string name);

    }
}
