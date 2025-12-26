MvcProductApp - Week 2 Version
This is an ASP.NET Core MVC application that demonstrates a full CRUD (Create, Read, Update, Delete) product catalog. It is built using a clean architecture that separates concerns by moving business logic into a dedicated service layer and uses dependency injection.
Features
Full CRUD Operations: Allows users to create, view a list of, edit, and delete products.
Database Persistence: Uses Entity Framework Core to save product data to a local SQL Server database.
Seed Data: The database is automatically populated with initial product data upon creation.
Search Functionality: Users can filter the product list by name.
Service Layer: Business logic (like finding a "featured" product) is handled in a separate ProductService.
Dependency Injection: The HomeController receives the IProductService via constructor injection, decoupling it from the implementation.
Unit Tested: The project includes a unit test to verify the business logic in the ProductService.
How to Run
Prerequisites:
.NET SDK (e.g., .NET 8.0 or newer)
Visual Studio 2022
Clone the Repository:
git clone [https://github.com/jomuch/MvcProductApp-Wk3v2.git](https://github.com/jomuch/MvcProductApp-Wk3v2.git)


Open in Visual Studio:
Navigate to the cloned directory and open the MvcProductApp.sln solution file.
Create the Database:
This is a critical step, as the local database is not stored in the repository.
In the Visual Studio menu, go to Tools > NuGet Package Manager > Package Manager Console.
Run the following command to create and seed the database:
Update-Database


Run the Application:
Press F5 or click the green "Start" button in Visual Studio to launch the project.
Design Notes
Separation of Concerns & Dependency Injection (DI)
This project uses a service layer (ProductService) to separate business logic from the controller. The HomeController is responsible for handling web requests and returning a view, but it is not responsible for the logic that determines what a "featured product" is. This logic is encapsulated entirely within the ProductService.
This separation is achieved using Dependency Injection:
Constructor Injection: The HomeController receives an IProductService through its constructor. This makes its dependency explicit and ensures the controller cannot be created without its required service.
Programming to an Interface: The controller depends on the IProductService interface, not the concrete ProductService class. This decouples the controller from the implementation, allowing the service to be easily replaced with a different implementation or a mock object for unit testing without changing the controller's code.
DI Lifetime: The service is registered with a Scoped lifetime in Program.cs. This is the appropriate choice because the ProductService depends on ApplicationDbContext, which is also scoped. This ensures that both services share the same instance within a single HTTP request, preventing data consistency issues.
Screenshot
(A screenshot of the application's product list page would be placed here.)
