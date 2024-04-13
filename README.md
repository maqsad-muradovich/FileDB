# FileDB

FileDB is a C# console application designed to work with a user database stored in a text file. The application allows you to add, delete, update and display users. It implements various services, brokers, and models to manage application data and logic.

## Content

- [Project architecture](#project-architecture)
- [Launch application](#launching-the-application)
- [Use](#usage)
- [Help information](#referance-infarmation)

## Project architecture

The FileDB project has the following structure:

```plaintext
├── Brokers/
│ ├── Logging/
│ │ ├── LoggingBroker.cs
│ │ └── ILoggingBroker.cs
│ └── Storages/
│ ├── FileStorageBroker.cs
│ └── IStorageBroker.cs
├──Models/
│ └──Users/
│ └── User.cs
├── Services/
│ ├── Identities/
│ │ └── IdentityService.cs
│ ├── Processing/
│ │ └── UserProcessing.cs
│ └──Users/
│ ├── IUserService.cs
│ └── UserService.cs
├── Program.cs
└──Users.txt
```

- **Brokers**: The directory contains brokers for accessing data storage and logging.
     - **Logging**: Brokers for logging (`LoggingBroker.cs` and `ILoggingBroker.cs`).
     - **Storages**: File management brokers (`FileStorageBroker.cs` and `IStorageBroker.cs`).
- **Models**: Contains data models (`Users/User.cs`).
- **Services**: Contains services to manage various aspects of the application.
     - **Identities**: Manage user identities (`IdentityService.cs`).
     - **Processing**: Service for processing users (`UserProcessing.cs`).
     - **Users**: Manage operations with users (`UserService.cs` and `IUserService.cs`).
- **Program.cs**: Main program file containing the entry point.
- **Users.txt**: Data file in which users are stored.

## Launching the application

To run the application, open the console in the project root directory and run the following command:

```bash
dotnet run
```

The application will prompt you to select an operation from the menu, depending on which the corresponding action will be performed.

## Usage

- Create a new user: Enter 1, then enter the name of the new user.
- Show all users: Enter 2 to display a list of all users.
- Update User: Enter 3, then enter the ID and new username.
- Delete User: Enter 4, then enter the user ID to delete.
- Exit the program: Enter 5.

## Reference Information

- [C# Documentation](https://learn.microsoft.com/ru-ru/dotnet/csharp/)
- [.NET Documentation](https://learn.microsoft.com/ru-ru/dotnet/)
