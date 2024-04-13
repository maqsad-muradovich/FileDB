using FileDB.Services.Identities;
using System;

namespace FileDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IdentityService identitiService1 = IdentityService.GetInstance();
            IdentityService identitiService2 = IdentityService.GetInstance();

            Console.WriteLine(identitiService1.GetNewId());
            Console.WriteLine(identitiService2.GetNewId());
        }
    }
}
