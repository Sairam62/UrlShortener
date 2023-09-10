# URL Shortener API

The URL Shortener API is a web service that allows you to shorten long URLs into unique, easy-to-share short codes. It is built using ASP.NET Core and PostgreSQL.

## Table of Contents

- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Database Migrations](#database-migrations)
- [Usage](#usage)
  - [API Endpoints](#api-endpoints)
- [Configuration](#configuration)

## Features

- Shorten long URLs into unique short codes.
- Redirect to the original long URL using a short code.
- Persistence of mappings in a PostgreSQL database.
- Error handling for invalid or nonexistent short codes.
- Built-in uniqueness constraint for short codes.

## Getting Started

### Prerequisites

Before you begin, ensure you have met the following requirements:

- .NET Core SDK
- PostgreSQL database server

### Installation

- Clone the repository:

   ```bash
   git clone https://github.com/Sairam62/UrlShortener.git

### Database Migrations

- 	Open Packager Manager Console
    Run Below Commands:
    
    ```bash	
	Add-Migration UrlShortener.Data.AppDbContext
	update-database

## Usage
To Generate a Tiny URL for Long URL.

### API Endpoints

#### Shorten a URL:

- HTTP Method: POST
- URL: /api/UrlShortener/shorten
- Request Body: JSON with a longUrl property.
- Response: Returns the generated short code.
#### Redirect to Original URL:

- HTTP Method: GET
- URL: /api/UrlShortener/{shortCode}
- Response: Redirects to the original long URL associated with the short code.
## Configuration
- Database connection settings can be configured in the appsettings.json file.