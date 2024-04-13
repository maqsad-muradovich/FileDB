using FileDB.Brokers.Storages;
using FileDB.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDB.Services.Identities
{
    internal sealed class IdentityService
    {
        private static IdentityService instance;
        private static int id;
        private readonly IStorageBroker storageBroker;

        private IdentityService()
        {
            this.storageBroker = new FileStorageBroker();
        }

        public static IdentityService GetInstance()
        {
            if (instance is null) 
            {
                instance = new IdentityService();
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
