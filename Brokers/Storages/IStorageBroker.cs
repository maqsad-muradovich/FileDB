﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FileDB.Models.Users;

namespace FileDB.Brokers.Storages
{
    internal interface IStorageBroker
    {
        User AddUser(User user);
        User[] ReadAllUsers();
    }
}
