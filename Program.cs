using System;
using FileDB.Models.Users;
using FileDB.Services.Users;
using FileDB.Brokers.Logging;
using FileDB.Brokers.Storages;
using FileDB.Services.Identityes;
using FileDB.Services.Processing;

namespace FileDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStorageBroker storageBroker;
            ILoggingBroker loggingBroker = new LoggingBroker();

            Console.WriteLine("Ma'lumotlar bazasi turini tanlang:");
            Console.WriteLine("1. Matnli maʼlumotlar bazasi (Users.txt)");
            Console.WriteLine("2. JSON ma'lumotlar bazasi (Users.json)");
            Console.Write("Sizning tanlovingiz (1 yoki 2): ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                storageBroker = new FileStorageBroker();
            }
            else if (choice == "2")
            {
                storageBroker = new JSONStorageBroker();
            }
            else
            {
                Console.WriteLine("Noto'g'ri tanlov. Standart matn bazasi ishlatildi.");
                storageBroker = new FileStorageBroker();
            }

            IdentityService identityService = IdentityService.GetInstance(storageBroker);
            IUserService userService = new UserService(loggingBroker, storageBroker);
            IUserProcessing userProcessing = new UserProcessing(userService, identityService);

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Yangi foydalanuvchi yaratish");
                Console.WriteLine("2. Barcha foydalanuvchilarni ko'rsatish");
                Console.WriteLine("3. Foydalanuvchini yangilash");
                Console.WriteLine("4. Foydalanuvchini oʻchirish");
                Console.WriteLine("5. Exit");

                Console.Write("\nOperatsiyani tanlash (1-5): ");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        Console.Write("Yangi foydalanuvchi ismini kiriting: ");
                        string newName = Console.ReadLine();
                        userProcessing.CreateNewUser(newName);
                        break;
                    case "2":
                        Console.WriteLine("Barcha foydalanuvchilar ro'yxati:");
                        userProcessing.DisplayUsers();
                        break;
                    case "3":
                        Console.Write("Foydalanuvchi ID kiriting: ");
                        int updatedId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Yangi foydalanuvchi nomini kiriting: ");
                        string updatedName = Console.ReadLine();
                        userProcessing.UpdateUser(updatedId, updatedName);
                        break;
                    case "4":
                        Console.Write("O'chirish uchun foydalanuvchi ID kiriting: ");
                        int deleteId = Convert.ToInt32(Console.ReadLine());
                        userProcessing.DeleteUser(deleteId);
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Noto'g'ri tanlov. Iltimos, yana bir bor urinib ko'ring.");
                        break;
                }
            }

            Console.WriteLine("Dastur tugallandi.");
        }
    }
}