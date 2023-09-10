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
- [Contributing](#contributing)
- [License](#license)

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

1. Clone the repository:

   ```bash
   git clone https://github.com/Sairam62/UrlShortener.git

2. Do the Migration:

	Open Packager Manager Console

	Run Below Commands:
	Add-Migration UrlShortener.Data.AppDbContext
	update-database