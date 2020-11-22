## Task List App

### Features
- List Creation.  Each User can have multiple lists. Each list can have multiple tasks
- Task creation, editing, completion, open, remove. Each task belongs in a list
- User registration and login. This was provided by the Angular template in Visual Studio and only minor changes were made to accommodate the requirements

### Design and Architecture

- Imparta.UI.Web: The backend API and the frontend Angular App. The initial plan was to have separate projects for the Task API backend and Task Web UI frontend but both have been combined in the Imparta.UI.Web project for simplicity. Consumes Imparta.Application and Imparta.Domain.
- Imparta.Application: The core application. This can be consumed by other frontends / services. Consumes Imparta.Domain and Imparta.DataAccess.
- Imparta.DataAccess: The is the SQL data access using Entity Framework Core ORM. Consumes Imparta.Domain
- Imparta.Domain: This has domain models and logic

### Technologies and Tools
- Asp.net Core 3.1 for Imparta.UI.Web and .Net Standard 2.1 for Imparta.DataAccess, Imparta.Application, and Imparta.Domain
- Angular 8.2
- Entity Framework Core 3.1
- Bootstrap 4
- SQL Server Express LocalDB

### Running the solution
- Clone the project and open the solution in Visual Studio
- In the Package Manager Console, Run:
- ``` Update-Database -Project 'Imparta.UI.Web' -Context IdentityDbContext ```
- ``` Update-Database -Project 'Imparta.DataAccess' -Context TaskDbContext ```
- Build and Run the Project
- Tests are also available to run

### Remarks
- This project took a little bit longer because I wanted to also pick up Angular skills. My frontend end experience is in React, but we discussed that Imparta uses Angular. This project was an opportunity to delve into Angular. I have scratched just the basics, but it will be easier for me to quickly pick up the advance parts and best practises.
- Testing: This is limited because of time constraints. However, I value testing highly and it is a critical part of building quality software.

### Improvements
- Plenty of refactoring to do to clean the code. 
- Improve the design on mobile. 
- Refine the Angular frontend as I learn more about the framework.
- Add Validation to the models in Imparta.Domain


