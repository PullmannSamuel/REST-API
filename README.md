# API Documentation

This API provides basic CRUD (Create, Read, Update, Delete) operations for managing data across five key entities: **Company**, **Division**, **Project**, **Department**, and **Employee**. The API also supports filtering and searching capabilities by name, code, and ID.

## Features

- **CRUD Operations:** Standard Create, Read, Update, and Delete functionalities for all entities.
- **Filtering & Searching:** Filter records by name or code, and search entities by their ID.

## Entity Relationships

Entities **Company**, **Division**, **Project**, and **Department** are interconnected through ID references, ensuring data consistency. For instance, when a new division is created, it's automatically linked to a company by ID. Any updates or deletions to the division will also reflect in the associated company.

## Installation

1. Ensure you have the [.NET SDK](https://dotnet.microsoft.com/en-us/download) installed on your system.
2. Clone the repository.
3. Run the `Setup.sh` script to install the required packages.
4. Create a Database using `SqlScript.sql`.
5. Change Source in appsettings.json to the database server name (for example: DESKTOP-PPRGCK7\\SQLEXPRESS)

## Running Tests

To execute basic tests, run the `RunTests.sh` script

## Starting the API

To start the API, run the `RunApi.sh` script



