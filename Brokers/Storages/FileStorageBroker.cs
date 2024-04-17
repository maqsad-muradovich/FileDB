using System;
using System.IO;
using System.Linq;
using System.Text;
using FileDB.Models.Users;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FileDB.Brokers.Storages
{
    internal class FileStorageBroker : IStorageBroker
    {
        private const string FilePath = "../../../Assets/Users.txt";

        public FileStorageBroker()
        {
            EnsureFileExists();
        }
        private void EnsureFileExists()
        {
            bool fileExists = File.Exists(FilePath);

            if (fileExists is false)
            {
                File.Create(FilePath).Close();
            }
        }

        public User AddUser(User user)
        {
            string userLine = $"{user.Id}*{user.Name}\n";
            File.AppendAllText(FilePath, userLine);

            return user;
        }

        public List<User> ReadAllUsers()
        {
            string[] userLines = File.ReadAllLines(FilePath);
            int userLength = userLines.Length;
            List<User> users = new List<User>();

            for (int iterator = 0; iterator < userLength; iterator++)
            {
                string userLine = userLines[iterator];
                string[] userProperties = userLine.Split('*');

                User user = new User
                {
                    Id = Convert.ToInt32(userProperties[0]),
                    Name = userProperties[1],
                };

                users.Add(user);
            }

            return users;
        }

        public void UpdateUser(User user)
        {
            List<User> users = ReadAllUsers();

            for (int iterator = 0; iterator < users.Count; iterator++)
            {
                if (users[iterator].Id == user.Id)
                {
                    users[iterator] = user;
                    break;
                }
            }

            File.WriteAllText(FilePath, string.Empty);
            foreach(User iterator in users)
            {
                AddUser(iterator);
            }
        }

        public void DeleteUser(int id)
        {
            List<User> users = ReadAllUsers();
            File.WriteAllText(FilePath, string.Empty);

            for (int iterator = 0; iterator < users.Count; iterator++)
            {
                if (users[iterator].Id != id)
                {
                    this.AddUser(users[iterator]);
                }
            }
        }

    }
}
