# EssatoTaskClinicManage
Patient Management System
Welcome to the Patient Management System, a RESTful API designed to simplify the management of patient records for medical clinics. This project is part of an intern application task for Essato Company, showcasing the ability to create, read, update, and delete (CRUD) patient data, along with enhanced features like dynamic sorting and search capabilities.

Getting Started
These instructions will get your copy of the project up and running on your local machine for development and testing purposes.

Prerequisites
.NET 6 SDK or later
Visual Studio with ASP.NET and web development workload
SQL Server (Developer or Express edition)
Installation
Clone the repository to your local machine:

sh
Copy code
git clone https://github.com/yourusername/patient-management-system.git
Open the solution file (ClinicManagementSystem.sln) in Visual Studio.

Restore NuGet packages:

sh
Copy code
dotnet restore
Update the appsettings.json file with your SQL Server connection string.

Apply database migrations to set up your database schema:

sh
Copy code
dotnet ef database update
Run the application in Visual Studio or use the following command:

sh
Copy code
dotnet run
Usage
The API supports the following operations on patients:

GET /api/Patients + feature -  Lists all of the patients, with optional sorting and search queries. Additional feature - there is possibility to filter the result both by the City or ZipCode

POST /api/Patients - Create a new patient record.

PUT /api/Patients/{id} - Update an existing patient record.

DELETE /api/Patients/{id} - Delete a patient record.



