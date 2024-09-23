using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using UI_Lab1_ADO.NET.Forms;  // Reference for UI Layer Forms
using Buisness_Lab1_ADO.NET.Services;  // Reference for Business Layer Service Registration

namespace UI_Lab1_ADO.NET
{
    internal static class Program
    {
        // The ServiceProvider is a built-in container used for Dependency Injection.
        // It will be used to manage and provide instances of services and forms
        // throughout the application's lifetime.
        private static ServiceProvider serviceProvider;

        [STAThread]
        static void Main()
        {
            // Step 1: Create a new ServiceCollection
            // The ServiceCollection is a collection where we register services, forms, and repositories.
            // It will be used to configure which dependencies will be injected.
            var services = new ServiceCollection();

            // Step 2: Register Services and Repositories from the Business Layer
            // This step delegates the responsibility of registering services (such as IUserService)
            // and repositories (such as IRepository<User>) to the Business Layer.
            // The Business Layer manages both business logic and data access dependencies.
            ServiceRegistration.RegisterServices(services);

            // Step 3: Register Forms (UI Layer)
            // Forms, which are part of the UI, are registered here to allow Dependency Injection
            // to provide their instances when needed (such as MainForm, LoginForm, etc.).
            // This ensures that forms can have their dependencies injected automatically.
            services.AddScoped<LoginForm>();
            services.AddScoped<RegisterForm>();
            services.AddScoped<MainForm>();
            services.AddScoped<UserManagerForm>();
            services.AddScoped<StudentManagerForm>();

            // Step 4: Build the ServiceProvider
            // After registering all the services, repositories, and forms,
            // we build the ServiceProvider. The ServiceProvider is the DI container
            // that will manage and resolve all dependencies throughout the application’s lifetime.
            serviceProvider = services.BuildServiceProvider();

            // Step 5: Configure Application Settings
            // This step enables visual styles and sets text rendering for the application,
            // ensuring it uses default Windows forms styling.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Step 6: Get the Required Form (LoginForm) from the ServiceProvider
            // The DI container (ServiceProvider) resolves the dependencies needed by the LoginForm.
            // Since LoginForm is registered in the ServiceCollection, the ServiceProvider
            // can automatically create an instance of it and inject any required dependencies.
            var loginForm = serviceProvider.GetRequiredService<LoginForm>();

            // Step 7: Run the Application with the Resolved Form
            // The application starts by running the LoginForm, which is automatically
            // injected with its required dependencies.
            Application.Run(loginForm);
        }
    }
}
