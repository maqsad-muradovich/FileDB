using FileDB.Services.Identities;
using System;

namespace FileDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IdentitiService identitiService1 = IdentitiService.GetInstance();
            IdentitiService identitiService2 = IdentitiService.GetInstance();

            Console.WriteLine(identitiService1.GetNewId());
            Console.WriteLine(identitiService2.GetNewId());
        }
    }
}
