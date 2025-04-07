# E-Movie

**Your Gateway to Cinematic Adventures Online.**

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET Version](https://img.shields.io/badge/.NET-9.0-blueviolet.svg)](https://dotnet.microsoft.com/download/dotnet/9.0)

E-Movie is a comprehensive web application built with ASP.NET Core 9.0 MVC, designed as an online hub for movie enthusiasts. It offers functionalities for browsing movie details, managing related entities like actors and cinemas, and includes a complete e-commerce experience with user accounts, shopping carts, and order processing.

> **Mission:** To provide a seamless and engaging online platform for discovering, managing, and interacting with movie information and related e-commerce activities.

---

## ✨ Visual Peek

Here's a glimpse of the eMovies home page (or another key feature):

![Screenshot 2025-04-06 152442](https://github.com/user-attachments/assets/db476df4-7d79-4a94-b981-c305b6c31db0)

---
## Core Features

eMovies offers a range of features designed for both users and administrators:

**Catalogue & Management:**

* **Movie Catalogue:** Browse an extensive list of movies with details including synopsis, release/closing dates, pricing, image posters, and categories (Action, Drama, Comedy, etc.).
* **Detailed Views:** Access dedicated pages for individual Movies, Actors, Cinemas, and Producers.
* **CRUD Operations:** Administrators can perform Create, Read, Update, and Delete operations on Movies, Actors, Cinemas, and Producers through dedicated management interfaces.
* **Search & Filtering:** Users can search for movies and potentially filter based on various criteria.

**User & E-commerce:**

* **Robust User Authentication:** Secure user registration, login/logout, email confirmation, and password recovery using ASP.NET Core Identity.
* **User Profiles:** Registered users have profiles, potentially including display names and profile pictures.
* **Shopping Cart:** Add desired movies (or tickets) to a session-based cart, view cart contents, and modify items.
* **Ordering System:** Complete the checkout process to place orders based on cart items. Orders are associated with user accounts and track status.
* **Order History:** Users can view their past orders.

**Infrastructure:**

* **Database Seeding:** Automatic initialization of the database with essential data (like categories, roles, potentially an admin user) on first launch.
* **Email Notifications:** Integrated email service for sending confirmations and notifications (requires configuration).

---

## Technology Stack

Built with a robust and maintainable technology stack:

* **Backend Framework:** ASP.NET Core 9.0 MVC (C#)
* **Data Access:** Entity Framework Core 9.0 (using Code-First migrations)
* **Authentication:** ASP.NET Core Identity
* **Database:** Microsoft SQL Server (Configurable for other EF Core compatible databases)
* **Frontend:** Razor Views (`.cshtml`), HTML, CSS, JavaScript
* **UI Libraries:** Bootstrap 5, jQuery, jQuery Validation
* **Architecture:** MVC, Repository Pattern, Service Layer, Dependency Injection
* **Utilities:** Email Sending Service (`Services/EmailSender.cs`)

---

## 🚀 Getting Started

Follow these steps to get eMovies running locally:

**1. Prerequisites:**

* [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
* [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Express, Developer, or other editions) or another configured EF Core compatible database.
* Development Environment (e.g., Visual Studio 2022+, VS Code)

**2. Clone the Repository:**

```bash
# Replace YOUR_USERNAME/eMovies.git with the actual repository URL if applicable
git clone [https://github.com/YOUR_USERNAME/eMovies.git](https://www.google.com/search?q=https://github.com/YOUR_USERNAME/eMovies.git)
cd eMovies
3. Configure Application Secrets:

It's highly recommended to use User Secrets for sensitive data like connection strings and email credentials, especially during development.

Initialize User Secrets (if not already done):
Bash

dotnet user-secrets init
Set Database Connection String:
Bash

# Adjust the connection string for your specific SQL Server instance
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=(localdb)\\mssqllocaldb;Database=eMoviesDb_Dev;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
Set Email Settings (Optional): If you want to test email functionality:
Bash

dotnet user-secrets set "EmailSettings:SmtpServer" "smtp.example.com"
dotnet user-secrets set "EmailSettings:Port" "587" # Or your provider's port
dotnet user-secrets set "EmailSettings:SenderName" "eMovies Notifications"
dotnet user-secrets set "EmailSettings:SenderEmail" "[email address removed]"
dotnet user-secrets set "EmailSettings:Username" "your_smtp_username"
dotnet user-secrets set "EmailSettings:Password" "your_smtp_password"
(Alternatively, configure these in appsettings.Development.json for local testing only, but do not commit credentials to source control).
4. Restore Dependencies:

Bash

dotnet restore
5. Apply Database Migrations:

This command creates the database (if it doesn't exist) and applies the schema based on the EF Core migrations defined in the project.

Bash

dotnet ef database update
6. Run the Application:

Bash

dotnet run
The application will start, and the console output will show the URLs where it's accessible (e.g., https://localhost:xxxx and http://localhost:yyyy).

7. Explore! Open your web browser and navigate to one of the provided URLs. Register a new account or use seeded credentials (if applicable) to start exploring the eMovies application.

Contributing
Contributions are welcome! If you'd like to help improve eMovies:

Fork the repository.
Create a new branch (git checkout -b feature/YourFeature or bugfix/YourBugfix).
Make your changes and commit them (git commit -am 'Add some amazing feature').
Push to the branch (git push origin feature/YourFeature).
Open a Pull Request.
Please adhere to standard coding practices and provide clear descriptions for your changes. Use GitHub Issues to report bugs or suggest new features.

License
This project is licensed under the MIT License.

(You should ensure a LICENSE file containing the MIT License text exists in the root of your repository.)
