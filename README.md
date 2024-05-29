# Patient Info Portal ASP.NET Core Web API (6.0)

The Patient Info Portal ASP.NET Core Web API (6.0) is a web application developed using ASP.NET Core Web API and Entity Framework Core. It provides a comprehensive solution for managing patient information, including personal details, non-communicable diseases (NCDs), and allergies.

## Features

- **Patient Management:** APIs to create, edit, and delete patient records with details such as name, disease name, epilepsy status, NCDs, and allergies.
- **NCD Management:** Endpoints for managing patient NCDs, allowing for the addition and removal of various NCDs.
- **Allergy Management:** Endpoints for managing patient allergies, allowing for the addition and removal of various allergies.

## Project Structure

The project structure includes components built using ASP.NET Core Web API for backend services and Entity Framework Core for data management:

- **ASP.NET Core Web API:** Contains the backend logic for handling API requests, data processing, and business logic.
- **Entity Framework Core:** Used for database interactions and ORM.
- **Swagger:** Used for API documentation and testing.

## Technologies Used

- **ASP.NET Core Web API:** Used for building the backend APIs and implementing server-side logic.
- **Entity Framework Core:** Used for database interactions and ORM.
- **Swagger:** Used for API documentation and testing.
- **SQL Server:** Database used for storing patient information.

## Database Configuration

Configure the database connection string in the `appsettings.json` file according to your SQL Server instance.

## Running the Project

To run the project locally:

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Configure the database connection string in `appsettings.json`.
4. Run database migrations to set up the database schema: `Update-Database` in the Package Manager Console or Restore the `PatientInfoPortalDB_Web_API.bak` file in MSSQL server.
5. Run the API server by starting the project in Visual Studio.
6. Access the API documentation and test endpoints using Swagger at `https://localhost:{port}/swagger`.

## API Endpoints

- **Patients**
  - `GET /api/patients` - Retrieves all patients.
  - `GET /api/patients/{id}` - Retrieves a specific patient by ID.
  - `POST /api/patients` - Creates a new patient.
  - `PUT /api/patients/{id}` - Updates an existing patient.
  - `DELETE /api/patients/{id}` - Deletes a patient.

## Contributing

Contributions to the project are welcome! If you have any suggestions, improvements, or bug fixes, feel free to fork the repository, make your changes, and submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).

## Authors

- [@OptimisticNurul](https://github.com/OptimisticNurul)

# Hi, I'm Kazi Md Nurul Islam! 👋

## 🚀 About Me

I'm a Full Stack Developer, Graphic Designer, and Digital Marketer...

🧠 Currently learning more...

## 🛠 Skills

As a Full Stack Developer:
- C#, Microsoft SQL Server, JavaScript, HTML, CSS, ASP.NET Core, ASP.NET Core API, Angular, React.js, MAUI...

As a Graphic Designer:
- Photoshop Design, Illustration, Logo Design, Banner/Brochure/Flyer Design, Magazine/Book Cover Design, Business Card Design, Photo Retouch, Clipping Path, Background Removing, Watermark Removing...

As a Digital Marketer:
- Search Engine Optimization (SEO), Social Media Marketing, Lead Generation, Email Marketing, Web Scraping...

## 🔗 Links

[![portfolio](https://img.shields.io/badge/my_portfolio-000?style=for-the-badge&logo=ko-fi&logoColor=white)](https://github.com/OptimisticNurul/)
[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/optimisticnurul/)

## Support

For support, email info.optimisticnurul@gmail.com or join our Slack channel.