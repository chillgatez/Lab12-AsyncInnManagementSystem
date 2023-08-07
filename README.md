# Lab12 AsyncInn Hotel Management System Web Application

Welcome to the Hotel Management System Web Application project! This project aims to provide a comprehensive solution for managing hotels, rooms, and amenities through a user-friendly API. In this README, you'll find information about the project's structure, setup instructions, and key components.

## Problem Domain
In the hospitality industry, efficient management of hotels, rooms, and amenities is crucial for delivering top-notch services to guests. This project addresses this challenge by integrating a database schema with a web application. The project follows a tutorial-style approach, guiding you through the process of setting up the application, creating database tables, and establishing API routes.

## ERD Diagram
Below is the Entity-Relationship Diagram (ERD) representing the structure of the database:

![Async Inn ERD](https://github.com/chillgatez/Lab12-AsyncInnManagementSystem/blob/Kelsee-Lab11/async-inn-erd.png?raw=true)


The ERD showcases the relationships between the entities in the system:
- **Hotel**: Represents a hotel with various attributes such as name, address, and phone number.  
- **Room**: Describes individual rooms within hotels, including attributes like room number, layout type, and rate.  
- **Amenity**: Encompasses amenities offered by the hotels, such as Wi-Fi, TV, and air conditioning.  

## Setup Instructions
To get started with the Hotel Management System Web Application, follow these steps:
1. Create a new Empty .NET Core Web Application:
    - Set up explicit routing for API controllers in the Configure method.
    - Configure your appsettings.json file to include your database connection string.
1. Model and Database Setup:
    - Create models (Hotel, Room, Amenity) representing the entities from the ERD.
    - Implement an AsyncInnDbContext class deriving from DbContext, including constructor and database properties.
    - Register the DbContext in the startup file.
    - Generate migration scripts using EF Core tools:
      - Create and apply a migration for the Hotels, Rooms, and Amenities tables.
1. Seeding Data:
    - Override the OnModelCreating method in AsyncInnDbContext to seed default data.
    - Seed data for all three entity types (3 hotels, 3 rooms, 3 amenities).
    - Create a migration to include the seeded data and apply it to the database.
1. API Routes:
    - Create API controllers (HotelsController, RoomsController, AmenitiesController) using ASP.NET Web API controllers with actions.
    - Implement CRUD operations using Entity Framework for each entity type.
    - Use ThunderClient or similar tools to test and interact with the API routes.
