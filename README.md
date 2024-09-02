# Procedures Management System

Este repositorio contiene el código fuente de un sistema de gestión de procedimientos desarrollado con Blazor y ASP.NET Core. El sistema permite a los usuarios gestionar trámites, expedientes y usuarios, ofreciendo una interfaz web intuitiva y funcional.

## Características

- **Gestión de Trámites**: Crear, modificar, eliminar y consultar trámites.
- **Gestión de Expedientes**: Crear, modificar, eliminar y consultar expedientes.
- **Gestión de Usuarios**: Registro, autenticación, autorización y gestión de usuarios.
- **Almacenamiento de Sesión**: Uso de `sessionStorage` para mantener la sesión del usuario.

## Tecnologías Utilizadas

- **Blazor Server**: Framework para crear aplicaciones web interactivas del lado del servidor.
- **ASP.NET Core**: Framework para construir aplicaciones web modernas.
- **Entity Framework Core**: ORM para manejar la base de datos SQLite.
- **SQLite**: Base de datos ligera y eficiente.
- **C#**: Lenguaje de programación utilizado para el desarrollo backend y frontend.

## Requisitos Previos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (opcional, para desarrollo frontend adicional)
- [SQLite](https://www.sqlite.org/download.html) (opcional, si deseas interactuar con la base de datos directamente)

## Instalación y Configuración

Sigue estos pasos para configurar y ejecutar el proyecto en tu entorno local:

### Clonar el Repositorio

```sh
git clone https://github.com/sipione/Procedures-Management-System.git
cd Procedures-Management-System
```

### Configurar la Base de Datos

El proyecto utiliza SQLite como base de datos. Asegúrate de que el archivo de la base de datos `SGE.sqlite` esté en el directorio raíz del proyecto. Si no existe, se creará automáticamente.

### Ejecutar la Aplicación

1. Navega al directorio del proyecto:

    ```sh
    cd Procedures-Management-System
    ```

2. Restaura las dependencias:

    ```sh
    dotnet restore
    ```

3. Construye el proyecto:

    ```sh
    dotnet build
    ```

4. Navega al UI:

    ```sh
    cd SGE.UI
    ```

5. Inicia la aplicación:

    ```sh
    dotnet run
    ```

   La aplicación estará disponible en `http://localhost:5000`.

## Uso

### Funcionalidades Principales

- **Inicio de Sesión**: Navega a `http://localhost:5000/login` para iniciar sesión.
- **Gestión de Trámites**: Navega a `http://localhost:5000/dashboard/tramites` para gestionar trámites.
- **Gestión de Expedientes**: Navega a `http://localhost:5000/dashboard/expedientes` para gestionar expedientes.
- **Perfil de Usuario**: Navega a `http://localhost:5000/dashboard/perfil` para ver y editar tu perfil de usuario.

## Estructura del Proyecto

El proyecto está dividido en tres principales carpetas:

- **Client**: Contiene la lógica del lado del cliente y los componentes Blazor.
- **Server**: Contiene la lógica del lado del servidor, controladores y configuración de la API.
- **Shared**: Contiene modelos y clases compartidas entre el cliente y el servidor.

## Contribuir

Si deseas contribuir a este proyecto, por favor sigue estos pasos:

1. Haz un fork del repositorio.
2. Crea una nueva rama (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza tus cambios y haz commits descriptivos (`git commit -m 'Añadida nueva funcionalidad'`).
4. Sube tus cambios a tu fork (`git push origin feature/nueva-funcionalidad`).
5. Abre un Pull Request describiendo tus cambios.

## Contacto

Si tienes alguna pregunta o sugerencia, no dudes en contactarnos a través de [ricardo@sipionetech.com](mailto:tu_email@dominio.com).