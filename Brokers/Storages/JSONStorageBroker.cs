using System;
using System.Collections.Generic;
using System.IO;
using FileDB.Models.Users;
using Newtonsoft.Json;

namespace FileDB.Brokers.Storages
{
    internal class JSONStorageBroker : IStorageBroker
    {
        private const string FilePath = "../../../Users.json";

        public JSONStorageBroker()
        {
            EnsureFileExists();
        }

        private void EnsureFileExists()
        {
            if (!File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, "[]");
            }
        }

        public User AddUser(User user)
        {
            List<User> users = ReadAllUsers();
            users.Add(user);
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(users));
            return user;
        }

        public List<User> ReadAllUsers()
        {
            string jsonData = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<User>>(jsonData);
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
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(users));
        }

        public void DeleteUser(int id)
        {
            List<User> users = ReadAllUsers();
            users.RemoveAll(user => user.Id == id);
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(users));
        }
    }
}
