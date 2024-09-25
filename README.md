# Lab1 ADO.NET Project: Login and Registration System
## Overview
This project demonstrates the implementation of a Login and Registration System using ADO.NET with a multi-layered architecture that includes UI Layer, Business Layer, and Data Access Layer. The project focuses on user authentication, role management, and database interaction, showcasing the following technologies and concepts:
•	C# with .NET Framework
•	Windows Forms for the User Interface
•	Dependency Injection (DI) to decouple UI from business logic and data access
•	ADO.NET for direct interaction with the database
•	Repository Pattern to abstract database operations
•	Password hashing using BCrypt for secure credentials management
•	Localization to handle multiple languages through a static class (temporary solution)
________________________________________
## Project Structure
UI Layer
The UI consists of the following key forms:
•	LoginForm: Handles user login, allowing login by username or email.
•	RegisterForm: Allows users to register by providing a username, email, and password.
•	MainForm: Displayed after successful login, this form is the primary application window where users access various functionalities.
•	Localization: The system uses a temporary static class LocalizationStrings to handle multiple languages in the application.
All UI elements interact with the Business Layer through interfaces that are injected using Dependency Injection, ensuring that the business logic is separated from the user interface.
________________________________________



## Business Layer
The Business Layer is responsible for handling the application's core logic. Key services include:
•	IUserService: Manages user-related logic, such as checking for existing users, validating credentials, and registering new users.
public class UserService : IUserService
{
    // User-related business logic
}
•	IStudentService: Handles operations related to students, such as retrieving, adding, and deleting student records.
________________________________________
## Data Access Layer
The Data Access Layer (DAL) manages direct communication with the SQL Server database using ADO.NET. It consists of repositories that abstract database queries.
Key repositories:
•	UserRepository: Handles CRUD operations for user entities.
public class UserRepository : IRepository<User>
{
    // Database interaction methods like GetAll, GetById, GetByUsername
}
•	StudentRepository: Handles CRUD operations for student entities.
Additionally, the ConnectionHelper class is used to handle the database connection strings dynamically, depending on the machine:
public static string GetConnectionString()
{
    if (Environment.MachineName == "ALEXANDRE")
    {
        return ConfigurationManager.ConnectionStrings["SchoolDbConnection"].ConnectionString;
    }
    return ConfigurationManager.ConnectionStrings["SchoolDbConnection_HomeServer"].ConnectionString;
}
________________________________________
## Features and Screenshots
Login Functionality
•	Users can log in using either their username or email.
•	Credentials are validated using BCrypt hashed passwords.
csharp
Copy code
private void LoginByUsername(string username, string password, IUserService userService)
{
    if (userService.UserExistsByUsername(username))
    {
        if (userService.ValidateCredentials(username, password))
        {
            LoginSuccess();
        }
        else
        {
            MessageBox.Show(LocalizationStrings.PasswordIncorrect);
        }
    }
}
________________________________________
## Registration Functionality
•	The system allows new users to register by providing a username, email, and password.
•	The RegisterForm shows the registration interface, and after successful registration, users can log in.
________________________________________
## Role-Based Management (Upcoming)
•	Planned future work will introduce role-based redirection for users, ensuring that different users have access to different functionalities based on their role.
________________________________________
## Dependency Injection
The project leverages Dependency Injection to ensure a clean separation of concerns. The DI setup is done in Program.cs, and services are injected into forms:
public LoginForm(IUserService userService)
{
    _userService = userService;
    InitializeComponent();
}
________________________________________
## Learning Outcomes
Through this project, I am learning about:
1.	Dependency Injection and how to decouple business logic from the UI layer.
2.	Secure User Authentication with BCrypt for password hashing.
3.	ADO.NET for database connectivity and how to implement repository patterns.
4.	Managing UI navigation between different forms in Windows Forms applications.
________________________________________
## Next Steps
•	Implement Role-based Authorization: Redirect users to different forms based on their role.
•	Enhance Localization: Improve the localization setup by moving to a more robust system (e.g., resource files).
•	Password Recovery: Implement password recovery functionality.
________________________________________
## Screenshots
Insert relevant screenshots here to help explain your project visually. Examples include:
•	Login form UI
•	Register form UI
•	Code snippets for major components
________________________________________


