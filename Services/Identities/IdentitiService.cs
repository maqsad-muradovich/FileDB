using FileDB.Brokers.Storages;
using FileDB.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDB.Services.Identities
{
    internal sealed class IdentitiService
    {
        private static IdentitiService instance;
        private static int id;
        private readonly IStorageBroker storageBroker;

        private IdentitiService()
        {
            this.storageBroker = new FileStorageBroker();
        }

        public static IdentitiService GetInstance()
        {
            if (instance is null) 
            {
                instance = new IdentitiService();
            }
            return instance;
        }

        public int GetNewId()
        {
            User[] users = this.storageBroker.ReadAllUsers();

            return users.Length is not 0
                ? IncrementLastUserId(users)
                : 1;

        }

        private static int IncrementLastUserId(User[] users) =>
            users[users.Length - 1].Id + 1;
    }
}
