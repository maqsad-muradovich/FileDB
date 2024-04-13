### Project description

The `FileDB` project is a user management system that uses a text file (`Users.txt`) as a database to store user data. The project consists of several main components:

- **Brokers**:
     - **Logging**: Implements `ILoggingBroker` for logging various operations (information messages, errors, successes).
     - **Storages**: Implements `IStorageBroker` to manage user data (adding, reading, updating and deleting).

- **Models/Users**: Contains a definition of the `User` class, representing a user with `Id` and `Name`.

- **Services**:
     - **Identities**: Implements `IdentityService` to generate unique identifiers (`Id`) for users.
     - **Processing**: Implements `UserProcessing` to perform operations on users, such as creating, displaying, deleting and updating users.
     - **Users**: Implements `UserService` to handle operations on users, including adding, displaying, updating and deleting.

The entire system is controlled through a program (`Program.cs`) that instantiates various services and performs operations on users. The project provides basic functionality for managing users using a file system to store data.