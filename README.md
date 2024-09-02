# Procedures Management System

This repository contains the source code for a procedures management system developed with Blazor, ASP.NET Core, and apiMVC. The system allows users to manage procedures, cases, and users, providing an intuitive and functional web interface.

## Features

- **Procedure Management**: Create, modify, delete, and view procedures.
- **Case Management**: Create, modify, delete, and view cases.
- **User Management**: Registration, authentication, authorization, and user management.
- **Session Storage**: Utilizes `sessionStorage` to maintain the user session.
- **API Integration**: Provides RESTful API endpoints for external integrations using apiMVC.

## Technologies Used

- **Blazor Server**: A framework for building interactive web applications on the server side.
- **ASP.NET Core**: A framework for building modern web applications.
- **apiMVC**: A framework for building RESTful APIs.
- **Entity Framework Core**: An ORM for handling the SQLite database.
- **SQLite**: A lightweight and efficient database.
- **C#**: The programming language used for backend and frontend development.

## Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (optional, for additional frontend development)
- [SQLite](https://www.sqlite.org/download.html) (optional, if you want to interact directly with the database)

## Installation and Setup

Follow these steps to set up and run the project in your local environment:

### Clone the Repository

```sh
git clone https://github.com/sipione/Procedures-Management-System.git
cd Procedures-Management-System
```

### Set Up the Database

The project uses SQLite as its database. Ensure that the database file `SGE.sqlite` is in the root directory of the project. If it doesn't exist, it will be created automatically.

### Run the Application

1. Navigate to the project directory:

    ```sh
    cd Procedures-Management-System
    ```

2. Restore the dependencies:

    ```sh
    dotnet restore
    ```

3. Build the project:

    ```sh
    dotnet build
    ```

4. Navigate to the UI:

    ```sh
    cd SGE.UI
    ```

5. Start the application:

    ```sh
    dotnet run
    ```

   The application will be available at `http://localhost:5000`.

## Usage

### Main Features

- **Login**: Navigate to `http://localhost:5114/dashboard/login` to log in.
- **Procedure Management**: Navigate to `http://localhost:5114/dashboard/tramites` to manage procedures.
- **Case Management**: Navigate to `http://localhost:5114/dashboard/expedientes` to manage cases.
- **User Profile**: Navigate to `http://localhost:5114/dashboard/perfil` to view and edit your user profile.
- **API Documentation**: Navigate to `http://localhost:5197/swagger` to view and interact with the API endpoints provided by `apiMVC`.

### API Endpoints

- **Procedures**:
  - `GET /api/procedures`: Retrieve a list of procedures.
  - `POST /api/procedures`: Create a new procedure.
  - `GET /api/procedures/{id}`: Retrieve a specific procedure by ID.
  - `PUT /api/procedures/{id}`: Update a specific procedure by ID.
  - `DELETE /api/procedures/{id}`: Delete a specific procedure by ID.

- **Cases**:
  - `GET /api/cases`: Retrieve a list of cases.
  - `POST /api/cases`: Create a new case.
  - `GET /api/cases/{id}`: Retrieve a specific case by ID.
  - `PUT /api/cases/{id}`: Update a specific case by ID.
  - `DELETE /api/cases/{id}`: Delete a specific case by ID.

- **Users**:
  - `GET /api/users`: Retrieve a list of users.
  - `POST /api/users`: Create a new user.
  - `GET /api/users/{id}`: Retrieve a specific user by ID.
  - `PUT /api/users/{id}`: Update a specific user by ID.
  - `DELETE /api/users/{id}`: Delete a specific user by ID.

## Project Structure

The project is organized into the following directories and files:
Procedures-Management-System/ ├── Controllers/ │ ├── CasesController.cs │ ├── ProceduresController.cs │ └── UsersController.cs ├── Data/ │ ├── ApplicationDbContext.cs │ └── Migrations/ ├── Models/ │ ├── Case.cs │ ├── Procedure.cs │ └── User.cs ├── Services/ │ ├── CaseService.cs │ ├── ProcedureService.cs │ └── UserService.cs ├── Views/ │ ├── Cases/ │ ├── Procedures/ │ └── Users/ ├── wwwroot/ │ ├── css/ │ ├── js/ │ └── lib/ ├── appsettings.json ├── Program.cs ├── README.md ├── Startup.cs └── Procedures-Management-System.csproj


### Directories and Files

- **Controllers/**: Contains the API controllers for handling HTTP requests.
  - `CasesController.cs`: Manages case-related API endpoints.
  - `ProceduresController.cs`: Manages procedure-related API endpoints.
  - `UsersController.cs`: Manages user-related API endpoints.

- **Data/**: Contains the database context and migration files.
  - `ApplicationDbContext.cs`: Defines the database context.
  - `Migrations/`: Contains the Entity Framework Core migration files.

- **Models/**: Contains the data models used in the application.
  - `Case.cs`: Defines the Case model.
  - `Procedure.cs`: Defines the Procedure model.
  - `User.cs`: Defines the User model.

- **Services/**: Contains the business logic and service classes.
  - `CaseService.cs`: Contains business logic for managing cases.
  - `ProcedureService.cs`: Contains business logic for managing procedures.
  - `UserService.cs`: Contains business logic for managing users.

- **Views/**: Contains the Razor views for the web application.
  - `Cases/`: Views related to case management.
  - `Procedures/`: Views related to procedure management.
  - `Users/`: Views related to user management.

- **wwwroot/**: Contains static files such as CSS, JavaScript, and libraries.
  - `css/`: Contains CSS files.
  - `js/`: Contains JavaScript files.
  - `lib/`: Contains third-party libraries.

- `appsettings.json`: Configuration file for the application.
- `Program.cs`: Entry point of the application.
- [`README.md`](command:_github.copilot.openRelativePath?%5B%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2Froot%2FProcedures-Management-System%2FREADME.md%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%5D "/root/Procedures-Management-System/README.md"): Project documentation.
- `Startup.cs`: Configures services and the app's request pipeline.
- `Procedures-Management-System.csproj`: Project file for the .NET application.

## Contributing

If you would like to contribute to this project, please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/new-feature`).
3. Make your changes and commit them with descriptive messages (`git commit -m 'Added new feature'`).
4. Push your changes to your fork (`git push origin feature/new-feature`).
5. Open a Pull Request describing your changes.

## Contact

If you have any questions or suggestions, feel free to contact us at [ricardo@sipionetech.com](mailto:ricardo@sipionetech.com).