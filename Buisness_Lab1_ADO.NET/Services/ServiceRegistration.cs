using Microsoft.Extensions.DependencyInjection;
using DAL_Lab1_ADO.NET.Repositories;  // Business Layer references Data Layer
using DAL_Lab1_ADO.NET.Models;  // Business Layer references Data Layer
using Buisness_Lab1_ADO.NET.Interfaces;  // Business Layer references Business Layer

namespace Buisness_Lab1_ADO.NET.Services
{
    public static class ServiceRegistration
    {
        /// <summary>
        /// This method registers all necessary services and repositories for the application.
        /// It centralizes the registration logic so that the UI layer does not need to know 
        /// about the details of how services and repositories are set up.
        /// </summary>
        /// <param name="services">The IServiceCollection to which services and repositories will be added.</param>
        public static void RegisterServices(IServiceCollection services)
        {
            // Step 1: Register Repositories (Data Layer)
            // This section registers the repository interfaces and their corresponding concrete implementations.
            // The repositories are part of the Data Layer and handle database-related operations.
            // Example: UserRepository implements the IRepository<User> interface and handles user-related data access.
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Student>, StudentRepository>();

            // AddScoped ensures that a new instance of the repository is created once per request (or in this case, per form interaction).

            // Step 2: Register Services (Business Layer)
            // Here, the services from the Business Layer are registered.
            // These services handle business logic and depend on the repositories from the Data Layer for data access.
            // Example: UserService implements the IUserService interface and contains business logic for managing users.
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStudentService, StudentService>();

            // AddScoped is used for services as well to ensure each form interaction gets its own instance of the service,
            // but the same instance is used throughout that interaction.

            // By registering services and repositories here, we maintain a clean separation of concerns.
            // The UI Layer doesn't need to know how these services and repositories are wired up;
            // it just requests the services it needs, and the DI container provides them.
        }
    }
}