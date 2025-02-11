
# E-Movie 🎬

## Overview
The **eMovie-Application** is a dynamic and user-friendly **e-commerce platform** designed for browsing, searching, and purchasing **movies**. It allows movie enthusiasts to explore various titles, learn about their details, and make purchases. The application handles **movies**, **actors**, **producers**, and **cinemas**, providing an intuitive interface for users.

## Features ✨
- **Movie Catalog**: Browse and search for a vast catalog of movies.
- **Actor Information**: View detailed profiles of actors and their roles.
- **Producer Information**: Insights into producers and their contributions.
- **Cinema Listings**: See cinemas screening the movies.
- **User Registration & Authentication**: Secure user accounts and profiles.
- **Purchase System**: Buy tickets or movies directly from the platform.

## Technology Stack ⚙️
- **Frontend**: HTML, CSS, JavaScript, React
- **Backend**: ASP.NET Core, C#
- **Database**: Microsoft SQL Server
- **ORM**: Entity Framework Core
- **Hosting**: Netlify (Frontend)
- **Authentication**: Email and password-based registration/login

## How It Works 🔄
- **Home Page**: Displays movies in a grid with thumbnails, titles, genres, and release years.
- **Search Functionality**: Search for movies by title, genre, or actor with dynamic filtering.
- **Detailed Movie Page**: Each movie has a dedicated page with information like cast, producer, and purchase options.
- **User Registration & Authentication**: Users register with email/password and view their profile and transaction history.
- **Movie Purchase**: Select a movie, add it to the cart, and proceed to checkout.
- **Admin Panel (Future Feature)**: Admins can manage the movie catalog, update details, and monitor purchases.

## Application Structure 🏗️
- **Models**: Entity Framework Core models for Movies, Actors, Producers, Cinemas, and Users.
- **Controllers**: Four main controllers:
  - **Movies Controller**: Manage movie-related operations.
  - **Actors Controller**: Handle actor information.
  - **Producers Controller**: Manage producer details.
  - **Cinemas Controller**: Display cinema listings.
- **Views**: Razor views for user interaction.

## Future Enhancements 🔮
- **Admin Dashboard**: A user-friendly interface for admins.
- **Payment Gateway Integration**: Secure payment system for purchases.
- **Ratings & Reviews**: Allow users to rate and review movies.
- **Recommendation System**: Suggest movies based on user preferences.

## License 📜
This project is licensed under the **MIT License**. See the LICENSE file for details.
