# DotNetCoreWebAPI-Boilerplate
DotNetCoreWebAPI-Boilerplate is a starter template for ASP.NET Core Web API projects, designed to kickstart development with essential features and best practices. It includes CRUD APIs for multi-tenancy clients, user management (login and CRUD operations), and customer entities. Additionally, the boilerplate provides Role-based Access Control (RBAC) APIs for granular permissions, Logging and Monitoring APIs for tracking application behavior, and Error Handling and Exception Logging APIs for robust error management. Use this boilerplate to accelerate the development of your ASP.NET Core Web API projects while adhering to industry-standard practices.

## Getting Started

### Prerequisites

- MS SQL Server
- .NET Core

### Installation

1. Clone the repository to your local machine.

```
git clone https://github.com/shanibpatel/DotNetCoreWebAPI-Boilerplate.git
```

2. Navigate to the project directory.
```
cd DotNetCoreWebAPI-Boilerplate
```

3. Open Package Manager Console in Visual Studio or use the terminal and run the following command to apply migrations and create the database.

```
Update-Database
```


4. Build and run the project. (In Visual Studio Run with F5 or in VS Code follow as below

```
dotnet run
```

5. Access the API endpoints locally using a tool like Postman or curl.

## Tools Used

1. MS SQL Server
2. .NET Core Web API

## Contributing

Contributions are welcome! Feel free to open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
