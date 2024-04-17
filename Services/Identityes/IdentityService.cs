using System;
using System.Linq;
using System.Text;
using FileDB.Models.Users;
using System.Threading.Tasks;
using FileDB.Brokers.Storages;
using System.Collections.Generic;

namespace FileDB.Services.Identityes
{
    internal sealed class IdentityService : IIdentityService
    {
        private static int id;
        private static IdentityService instance;
        private readonly IStorageBroker storageBroker;

        private IdentityService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public static IdentityService GetInstance(IStorageBroker storageBroker)
        {
            if (instance is null) 
            {
                instance = new IdentityService(storageBroker);
            }
            return instance;
        }

        public int GetNewId()
        {
            List<User> users = this.storageBroker.ReadAllUsers();

            return users.Count is not 0
                ? IncrementLastUserId(users)
                : 1;

        }

        private static int IncrementLastUserId(List<User> users) =>
            users[users.Count - 1].Id + 1;
    }
}
