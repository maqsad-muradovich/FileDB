using FileDB.Brokers.Logging;
using FileDB.Brokers.Storages;
using FileDB.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            loggingBroker.LogInforamation("===End of users");
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
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i] != null && users[i].Id == id)
                {
                    users[i] = null;
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
