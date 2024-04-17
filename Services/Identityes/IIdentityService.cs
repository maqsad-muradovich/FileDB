using FileDB.Brokers.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDB.Services.Identiyes
{
    internal interface IIdentityService
    {
        int GetNewId();
    }
}
