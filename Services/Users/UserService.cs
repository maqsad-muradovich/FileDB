using System;
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

        public void ShowUsers()
        {
            List<User> users = storageBroker.ReadAllUsers();

            foreach (User user in users)
            {
                loggingBroker.LogSuccessUser($"{user.Id}, {user.Name}");
            }
            loggingBroker.LogInforamation("===End of users===\n");
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

        public void DeleteUser(int id)
        {
            List<User> users = storageBroker.ReadAllUsers();
            for (int iterator = 0; iterator < users.Count; iterator++)
            {
                if (users[iterator] != null && users[iterator].Id == id)
                {
                    users[iterator] = null;
                    loggingBroker.LogInforamation($"PhoneBook with ID {id} deleted successfully.");
                    return;
                }
            }
            loggingBroker.LogError($"PhoneBook with ID {id} not found.");
        }

        public void Update(User user)
        {
            if (user is null)
            {
                loggingBroker.LogError("Your user is empty");
                return;
            }

            if (user.Id == 0 || string.IsNullOrEmpty(user.Name))
            {
                loggingBroker.LogError("Your user is invalid");
            }

            storageBroker.UpdateUser(user);
        }

        public void Delete(int id)
        {
            storageBroker.DeleteUser(id);
        }
    }
}
