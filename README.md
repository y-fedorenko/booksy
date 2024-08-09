# Booksy

Welcome to Booksy, your ultimate online bookstore. Booksy offers a wide range of books across various genres, providing an easy and convenient way for book lovers to discover, purchase, and enjoy books from the comfort of their home.

## Table of Contents

1. [Project Overview](#project-overview)
2. [Features](#features)
3. [Pages and Functionality](#pages-and-functionality)
4. [Technologies Used](#technologies-used)
5. [Installation](#installation)
6. [Running the Project](#running-the-project)
7. [License](#license)



## Project Overview

Welcome to Booksy, your ultimate online bookstore. Booksy offers a wide range of books across various genres, providing an easy and convenient way for book lovers to discover, purchase, and enjoy books from the comfort of their home.

## Features

- **Book Catalog**: Browse books by authors.
- **Book Details**: Detailed view of each book including description, author info, and reviews.
- **Book Series** View series of specific books.
- **Comment Section**: Users can leave comments on books, authors, and series pages.

## Pages and Functionality

### Author Page

- **Create**: Add a new author to the database.
- **Read**: View detailed information about an author, including their biography and the books they have written.
- **Update**: Edit an author's information.
- **Delete**: Remove an author from the database.
- **Comments**: Users can leave comments on the author page.

### Book Page

- **Create**: Add a new book to the catalog.
- **Read**: View detailed information about a book, including its description and author info.
- **Update**: Edit a book's information.
- **Delete**: Remove a book from the database.
- **Comments**: Users can leave comments on the book page.

### Series Page

- **Create**: Add a new series to the database.
- **Read**: View detailed information about a series, including the books in the series and related information.
- **Update**: Edit a series' information.
- **Delete**: Remove a series from the database.
- **Comments**: Users can leave comments on the series page.

## Technologies Used

- **Frontend**: HTML, CSS, React.js
- **Backend**: Node.js, C#, ASP.NET
- **Database**: SQL 
- **Version Control**: Git

## Installation

To set up the project locally, follow these steps:

1. **Clone the repository:**
   ```bash
   git clone https://github.com/y-fedorenko/booksy.git

2. **Open the project in Visual Studio:**
   Navigate to the project folder and open the .sln file in Visual Studio.
   
4. **Set up the database:**
  Update the connection string in appsettings.json to match your SQL Server configuration.
  Open the Package Manager Console in Visual Studio (Tools > NuGet Package Manager > Package Manager Console).
  Ensure the default project in the console dropdown is set to your project's data layer (e.g., Booksy.DAL).
  Run the following command to apply migrations and create the database:
   ```powershell
   Update-Database
   
4. **Restore dependencies:**
 In Visual Studio, restore the necessary NuGet packages by right-clicking on the solution in Solution Explorer and selecting Restore NuGet Packages

 ## Running the Project
 
 Run the application
    Press F5 or click the Start button in Visual Studio to build and run the application.
   
## License

This project is licensed under the Booksy License.


