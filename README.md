# Procedures Management System

This repository contains the source code for a procedures management system developed with Blazor and ASP.NET Core. The system allows users to manage procedures, cases, and users, providing an intuitive and functional web interface.

## Features

- **Procedure Management**: Create, modify, delete, and view procedures.
- **Case Management**: Create, modify, delete, and view cases.
- **User Management**: Registration, authentication, authorization, and user management.
- **Session Storage**: Utilizes `sessionStorage` to maintain the user session.

## Technologies Used

- **Blazor Server**: A framework for building interactive web applications on the server side.
- **ASP.NET Core**: A framework for building modern web applications.
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

- **Login**: Navigate to `http://localhost:5000/login` to log in.
- **Procedure Management**: Navigate to `http://localhost:5000/dashboard/tramites` to manage procedures.
- **Case Management**: Navigate to `http://localhost:5000/dashboard/expedientes` to manage cases.
- **User Profile**: Navigate to `http://localhost:5000/dashboard/perfil` to view and edit your user profile.

## Project Structure

The project is divided into three main folders:

- **Client**: Contains client-side logic and Blazor components.
- **Server**: Contains server-side logic, controllers, and API configuration.
- **Shared**: Contains models and classes shared between the client and server.

## Contributing

If you would like to contribute to this project, please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/new-feature`).
3. Make your changes and commit them with descriptive messages (`git commit -m 'Added new feature'`).
4. Push your changes to your fork (`git push origin feature/new-feature`).
5. Open a Pull Request describing your changes.

## Contact

If you have any questions or suggestions, feel free to contact us at [ricardo@sipionetech.com](mailto:ricardo@sipionetech.com).