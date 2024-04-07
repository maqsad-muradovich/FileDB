using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FileDB.Models.Users;

namespace FileDB.Brokers.Storages
{
    internal class FileStorageBroker : IStorageBroker
    {
        private const string FilePath = "../../../Users.txt";

        public FileStorageBroker()
        {
            EnsureFileExists();
        }

        public User AddUser(User user)
        {
            string userLine = $"{user.Id}*{user.Name}\n";
            File.AppendAllText(FilePath, userLine);

            return user;
        }

        public User[] ReadAllUsers()
        {
            string[] userLines = File.ReadAllLines(FilePath);
            int userLength = userLines.Length;
            User[] users = new User[userLength];

            for (int iterator = 0; iterator < userLength; iterator++)
            {
                string userLine = userLines[iterator];
                string[] userProperties = userLine.Split('*');

                User user = new User
                {
                    Id = Convert.ToInt32(userProperties[0]),
                    Name = userProperties[1],
                };

                users[iterator] = user;
            }

            return users;
        }

        private void EnsureFileExists()
        {
            bool fileExists = File.Exists(FilePath);

            if (fileExists is false)
            {
                File.Create(FilePath).Close();
            }
        }
    }
}
