## Solution to the Task List App

### Features
- List Creation.  Each has can have multiple lists. Each list with multiple tasks
- Task creation, editing, completion, open, remove. Each task belongs in a list
- User registration and login. This was provider by the Angular template in Visual Studio and only minor changes were added to accommedate the requirements

### Design and Architecture

- Imparta.UI.Web: The backend API and the Frontend Angular App. The initial plan was to have separate projects for the Task API backend and Task Web UI frontend but both have been combined in the Imparta.UI.Web project for simplicity

### Technologies and Tools
- Asp.net Core 3.1 for Imparta.UI.Web and .Net Standard 2.1 for Imparta.DataAccess and Imparta.Application
- Angular 8.2
- Entity Framework Core 3.1
- Bootstrap 4
- SQL Server Express LocalDB

### Running the solution
- Clone the project and open the solution in Visual Studio or prefered editor
- In the Package Manager Console, Run:
- ``` Update-Database -Project 'Imparta.UI.Web' -Context IdentityDbContext
Update-Database -Project 'Imparta.DataAccess' -Context TaskDbContext ```
- Build and Run the Project
- Tests are also available to run

### Remarks
- The project took a little bit longer because i wanted to also pick up Angular skills. My frontend end experience is in React but we discussed that you use Angular at Imparta and i wanted to start learning Angualar with this project.
- Testing: This is very limited because of time constraints. I value testing hihgly and it is a critical part of building quality software.
- Improvements: Plenty of refactoring to do to clean the code. Improve the design on mobile. Refine the Angular frontend as I learn more about the framework.


