﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using FileDB.Models.Users;
using FileDB.Services.Users;
using FileDB.Services.Identityes;

namespace FileDB.Services.Processing
{
    internal class UserProcessing : IUserProcessing
    {
        private readonly IUserService userService;
        private readonly IdentityService identityService;

        public UserProcessing(IUserService userService,
                    IdentityService identitiyService)
        {
            this.userService = userService;
            this.identityService = identitiyService;
        }

        public void CreateNewUser(string name)
        {
            User user = new User();
            user.Id = this.identityService.GetNewId();
            user.Name = name;
            this.userService.AddUser(user);
        }

        public void DisplayUsers() =>
            this.userService.ShowUsers();

        public void DeleteUser(int id) =>
            this.userService.Delete(id);

        public void UpdateUser(int id, string name)
        {
            User user = new User();
            user.Id = id;
            user.Name = name;
            this.userService.Update(user);
        }
    }
}
