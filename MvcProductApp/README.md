MvcProductApp
This is an ASP.NET Core MVC application that demonstrates a full CRUD (Create, Read, Update, Delete) product catalog. It is built using a service-oriented architecture with dependency injection to ensure a clean separation of concerns and testability.
Features
Full CRUD Operations: Create, read, update, and delete products.
Database Persistence: Uses Entity Framework Core to save data to a local SQL database.
Seed Data: The database is automatically populated with initial product data on creation.
Search/Filtering: Users can filter the product list by name.
Service Layer: Business logic (like finding a featured product) is handled in a dedicated service, keeping controllers lean.
Dependency Injection: Services like the database context and product service are provided to controllers using constructor injection.
Unit Tested: The service layer includes a unit test to verify its business logic.
How to Run
Prerequisites:
.NET SDK (8.0 or newer)
Visual Studio 2022 with the "ASP.NET and web development" workload.
Clone the Repository:
git clone [https://github.com/jomuch/MvcProductApp-W3.git](https://github.com/jomuch/MvcProductApp-W3.git)


Open in Visual Studio:
Navigate to the cloned directory and open the MvcProductApp.sln solution file.
Create the Database:
In the Visual Studio menu, go to Tools > NuGet Package Manager > Package Manager Console.
Run the following command to create and seed the local database:
Update-Database


Run the Application:
Press F5 or click the green "Start" button in Visual Studio.
Design Notes (Separation of Concerns & DI)
This project uses a service layer to separate business logic from the controller. The HomeController is responsible for handling web requests and returning a view, but it is not responsible for the logic that determines what a "featured product" is. This logic is encapsulated entirely within the ProductService.
Dependency Injection is used to provide the ProductService to the HomeController:
Constructor Injection: The HomeController receives an IProductService through its constructor. This makes the dependency explicit and ensures the controller cannot be created without its required service.
Programming to an Interface: The controller depends on the IProductService interface, not the concrete ProductService class. This decouples the controller from the implementation, allowing the service to be easily replaced or mocked for unit testing.
DI Lifetime: The service is registered with a Scoped lifetime in Program.cs. This is the appropriate choice because the ProductService depends on ApplicationDbContext, which is also scoped, ensuring they share the same database context for a single request.
Screenshot

