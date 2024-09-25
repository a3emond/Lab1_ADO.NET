# Lab1 ADO.NET Project: Login and Registration System

## Overview
This project demonstrates the implementation of a **Login and Registration System** using ADO.NET with a multi-layered architecture that includes the **UI Layer**, **Business Layer**, and **Data Access Layer**. The project focuses on user authentication, role management, and database interaction, showcasing the following technologies and concepts:

<ul>
<li>C# with .NET Framework</li>
<li>Windows Forms for the User Interface</li>
<li>Dependency Injection (DI) to decouple UI from business logic and data access</li>
<li>ADO.NET for direct interaction with the database</li>
<li>Repository Pattern to abstract database operations</li>
<li>Password hashing using BCrypt for secure credentials management</li>
<li>Localization to handle multiple languages through a static class (temporary solution)</li>
</ul>

---

## Project Structure

### UI Layer
The UI consists of the following key forms:

<ul>
<li><strong>LoginForm</strong>: Handles user login, allowing login by username or email.</li>
<li><strong>RegisterForm</strong>: Allows users to register by providing a username, email, and password.</li>
<li><strong>MainForm</strong>: Displayed after successful login, this form is the primary application window where users access various functionalities.</li>
<li><strong>Localization</strong>: The system uses a temporary static class <code>LocalizationStrings</code> to handle multiple languages in the application.</li>
</ul>

All UI elements interact with the **Business Layer** through interfaces that are injected using Dependency Injection, ensuring that the business logic is separated from the user interface.

---

## Business Layer

The **Business Layer** is responsible for handling the application's core logic. Key services include:

<ul>
<li><strong>IUserService</strong>: Manages user-related logic, such as checking for existing users, validating credentials, and registering new users.</li>
</ul>

<pre>
<code>
public class UserService : IUserService
{
    // User-related business logic
}
</code>
</pre>

<ul>
<li><strong>IStudentService</strong>: Handles operations related to students, such as retrieving, adding, and deleting student records.</li>
</ul>

---

## Data Access Layer

The **Data Access Layer** (DAL) manages direct communication with the SQL Server database using ADO.NET. It consists of repositories that abstract database queries.

Key repositories:

<ul>
<li><strong>UserRepository</strong>: Handles CRUD operations for user entities.</li>
</ul>

<pre>
<code>
public class UserRepository : IRepository<User>
{
    // Database interaction methods like GetAll, GetById, GetByUsername
}
</code>
</pre>

<ul>
<li><strong>StudentRepository</strong>: Handles CRUD operations for student entities.</li>
</ul>

Additionally, the <code>ConnectionHelper</code> class is used to handle the database connection strings dynamically, depending on the machine:

<pre>
<code>
public static string GetConnectionString()
{
    if (Environment.MachineName == "ALEXANDRE")
    {
        return ConfigurationManager.ConnectionStrings["SchoolDbConnection"].ConnectionString;
    }
    return ConfigurationManager.ConnectionStrings["SchoolDbConnection_HomeServer"].ConnectionString;
}
</code>
</pre>

---

## Features and Screenshots

### Login Functionality
<ul>
<li>Users can log in using either their username or email.</li>
<li>Credentials are validated using BCrypt hashed passwords.</li>
</ul>

<pre>
<code>
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
</code>
</pre>

---

### Registration Functionality
<ul>
<li>The system allows new users to register by providing a username, email, and password.</li>
<li>The <code>RegisterForm</code> shows the registration interface, and after successful registration, users can log in to the application.</li>
</ul>

---

## Role-Based Management (Upcoming)
<ul>
<li>Planned future work will introduce role-based redirection for users, ensuring that different users have access to different functionalities based on their role.</li>
</ul>

---

## Dependency Injection

The project leverages Dependency Injection to ensure a clean separation of concerns. The DI setup is done in <code>Program.cs</code>, and services are injected into forms:


<pre><code>
public LoginForm(IUserService userService)
{
    _userService = userService;
    InitializeComponent();
}
</code></pre>
## Learning Outcomes
<ul> <li><strong>Dependency Injection</strong> and how to decouple business logic from the UI layer.</li> <li><strong>Secure User Authentication</strong> with BCrypt for password hashing.</li> <li><strong>ADO.NET</strong> for database connectivity and how to implement repository patterns.</li> <li><strong>Managing UI navigation</strong> between different forms in Windows Forms applications.</li> </ul>
Next Steps
<ul> <li><strong>Implement Role-based Authorization</strong>: Redirect users to different forms based on their role.</li> <li><strong>Enhance Localization</strong>: Improve the localization setup by moving to a more robust system (e.g., resource files).</li> <li><strong>Password Recovery</strong>: Implement password recovery functionality.</li> </ul>
