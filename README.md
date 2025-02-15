
# E-Movie 

## Overview
The **E-Movie** is an innovative and feature-packed **e-commerce platform** that revolutionizes how users browse, discover, and purchase **movies**. It offers a seamless user experience, allowing movie lovers to explore an expansive catalog of films, gain insights about actors, producers, and cinemas, and make purchases directly on the platform. Designed for scalability, high performance, and ease of use, this project provides the most efficient solution for managing movie-related content ever created.

## Problem Solved 
Before **eMovie-Application**, movie enthusiasts struggled to find a centralized platform that combined movie browsing, purchasing, and detailed information about films, actors, producers, and cinemas. This platform eliminates that gap, providing an all-in-one solution that ensures users can easily navigate and enjoy their favorite films, while movie managers can handle their catalogs efficiently.

## Features 
- **Movie Catalog**: Easily browse through a vast and ever-growing selection of movies, with detailed information on each title.
- **Actor Information**: Access comprehensive profiles of actors, including their roles and filmography.
- **Producer Insights**: Discover the masterminds behind your favorite films.
- **Cinema Listings**: See where to watch movies in cinemas near you.
- **User Registration & Authentication**: Safe, secure accounts for seamless profile management.
- **Purchase System**: Effortlessly buy tickets or movies directly from the platform with just a few clicks.

## Technology Stack 
- **Frontend**: Bootstrap, HTML5 & CSS3, JavaScript (ES6+), jQuery
- **Backend**: ASP.NET Core, C#
- **Database**: MySQL
- **ORM**: Entity Framework Core
- **Authentication**: Email and password-based registration/login using ASP.NET Identity

## How It Works 
- **Home Page**: The home page displays movies in an easy-to-navigate grid with thumbnails, titles, genres, and release years.
- **Search Functionality**: Search for movies by title, genre, or actor with powerful dynamic filtering.
- **Detailed Movie Page**: Each movie has a dedicated page that includes in-depth information such as cast, producers, and options to purchase.
- **User Registration & Authentication**: Users can create accounts, sign in, and manage profiles and transaction histories securely.
- **Movie Purchase**: After selecting a movie, users can add it to their cart and easily check out.
- **Admin Panel (Future Feature)**: Admins will have the ability to manage the movie catalog, update content, and monitor user purchases.

## Application Structure 
- **Models**: Entity Framework Core models for Movies, Actors, Producers, Cinemas, and Users.
- **Controllers**: Four main controllers:
  - **Movies Controller**: Manages movie-related operations.
  - **Actors Controller**: Handles actor-related data.
  - **Producers Controller**: Manages information about movie producers.
  - **Cinemas Controller**: Displays listings of cinemas screening films.
- **Views**: Razor views to facilitate dynamic user interaction with the platform.

## Acknowledgments 
Special thanks to the open-source community for providing valuable resources and tools that helped make this project a success.

## License 
This project is licensed under the **MIT License**. See the LICENSE file for details.
