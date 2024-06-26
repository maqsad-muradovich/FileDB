﻿using System;
using System.IO;
using System.Text;
using System.Linq;
using FileDB.Models.Users;
using System.Threading.Tasks;
using FileDB.Brokers.Logging;
using FileDB.Brokers.Storages;
using System.Collections.Generic;

namespace FileDB.Services.Users
{
    internal class UserService : IUserService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public UserService(ILoggingBroker loggingBroker,
            IStorageBroker storageBroker)
        {
            this.loggingBroker = loggingBroker;
            this.storageBroker = storageBroker;
        }

        public User AddUser(User user)
        {
            return user is null
                ? CreateAndLogInvalidUser()
                : ValidateAndAddUser(user);
        }

        private User CreateAndLogInvalidUser()
        {
            loggingBroker.LogError("User is invalid");
            return new User();
        }

        private User ValidateAndAddUser(User user)
        {
            if (user.Id is 0 || string.IsNullOrWhiteSpace(user.Name))
            {
                loggingBroker.LogError("User details missing.");
                return new User();
            }
            else
            {
                loggingBroker.LogInforamation("User is created successfully");
                return storageBroker.AddUser(user);
            }
        }

        public List<User> AllUsers() =>
            this.storageBroker.ReadAllUsers();

        public void Delete(int id)
        {
            List<User> users = storageBroker.ReadAllUsers();
            User userToDelete = users.FirstOrDefault(user => user.Id == id);

            if (userToDelete != null)
            {
                loggingBroker.LogInforamation($"User with ID {id} deleted successfully.");

                storageBroker.DeleteUser(id);
            }
            else
            {
                loggingBroker.LogError($"User with ID {id} not found.");
            }
        }

        public bool Update(User user)
        {
            List<User> users = storageBroker.ReadAllUsers();

            foreach (User item in users)
            {
                if (item.Id == user.Id)
                {
                    storageBroker.UpdateUser(user);

                    return true;
                }
            }
            
            return false;
        }
    }
}
