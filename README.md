# RaceDay Platform - Part 3 (MVC Web Application)

Welcome to the **RaceDay** platform! This is the final part of the project, a production-ready ASP.NET Core MVC Web Application. It acts as the frontend user interface that consumes the Part 2 RESTful API for all data operations, ensuring no direct database access or replicated business logic exists within this MVC project.

## 🚀 Features Implemented

*   **Authentication & Role-Based Navigation:** Secure session-based login/registration. Dynamic navigation menus based on user roles (Organiser, Participant).
*   **Organiser Interface:** Dashboard with event summaries, full CRUD operations for events (with banner uploads), category management, and result capturing.
*   **Participant Interface:** Event browsing with filtering, seamless enrolment, personal status tracking, and historical race results.
*   **Cloud Storage Integration:** Azure Blob Storage is integrated via the API for uploading and displaying event banner images.
*   **Sporting UI Design:** A polished, responsive interface built with Bootstrap, featuring an energetic sporting theme, role-appropriate navigation, and color-coded statuses.
*   **Dockerised Architecture:** Fully containerised using Docker Compose with a SQL Server database container and health checks for reliable startup.

---

## 🛠️ Prerequisites

Before running this application, ensure you have the following installed:
*   [.NET 10.0 SDK](https://dotnet.microsoft.com/download)
*   [Docker Desktop](https://www.docker.com/products/docker-desktop/) (Required for the containerised setup)

---

## 🐳 Docker Setup & Run Command

This application is fully containerised using Docker. It includes a multi-stage `Dockerfile` and a `docker-compose.yml` file to orchestrate the web application alongside a SQL Server 2022 database container.

### **How to start the application (Single Command):**

1. Ensure Docker Desktop is running on your machine.
2. Open your terminal and navigate to the root directory of this repository (where the `docker-compose.yml` file is located).
3. Run the following command to build and start the application:


docker compose up --build

### Once the containers are running, open your browser and navigate to: https://localhost:7119

Default Admin Credentials:

Email: admin@gmail.com

Password: Admin@123

To stop the application, press Ctrl+C in the terminal or run docker compose down.

### 📂 Project Structure
/Controllers - Handles HTTP requests and routes them to the appropriate API endpoints or Views.

/Models - Contains ViewModels and DTOs used to transfer data between the MVC app and the API.

/Views - Razor pages utilising Bootstrap for responsive, dynamic UI rendering.

/Services - Contains HTTP clients and services used to communicate with the Part 2 API and Azure Blob Storage.

Dockerfile - Multi-stage build for containerising the MVC app.

docker-compose.yml - Defines the web app and SQL Server database services with health checks.

🎥 Video Demonstration
As required by the POE, a full video demonstration covering the MVC structure, API integration, Azure Blob Storage flow, and Docker setup can be found here:

**YouTube link:** https://youtu.be/SBXgQhvVx-E 
