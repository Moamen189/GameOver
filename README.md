#  Game Over Application

This repository contains a simple MVC (Model-View-Controller) application that performs CRUD (Create, Read, Update, Delete) operations on game categories using a ViewModel.

## Table of Contents

- [Introduction](#introduction)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Features](#features)
- [Usage](#usage)
- [Contributing](#contributing)
## Introduction

This MVC application demonstrates a basic implementation of managing game categories using the ViewModel pattern. The application allows users to perform CRUD operations on different game categories.

## Technologies Used

- ASP.NET MVC
- C#
- Entity Framework
- HTML
- CSS
- Bootstrap
- JavaScript
- SQL Server (for data storage)

## Getting Started

To run this application locally, follow these steps:

1. Clone this repository to your local machine using:
   ```
   git clone https://github.com/your-username/mvc-game-categories.git
   ```

2. Open the solution in Visual Studio.

3. Modify the connection string in the `Web.config` file to point to your local SQL Server instance.

4. Build and run the application.

## Features

- List all game categories.
- Create a new game category.
- Edit an existing game category.
- Delete a game category.

## Usage

1. **Home Page**: Upon accessing the application, you will be presented with a list of existing game categories.

2. **Create Category**: Click on the "Create New Category" button to create a new game category. Provide the necessary details and click the "Save" button.

3. **Edit Category**: Each existing category will have an "Edit" button. Clicking on it will allow you to modify the category's information. Click "Save" to apply the changes.

4. **Delete Category**: To remove a category, click on the "Delete" button next to the category you want to delete. A confirmation prompt will appear before deleting the category.

## Contributing

Contributions to enhance the functionality, fix issues, or improve the code structure are welcome. Here's how you can contribute:

1. Fork the repository.
2. Create a new branch for your changes.
3. Make your changes and commit them with descriptive commit messages.
4. Push your changes to your fork.
5. Create a pull request to the main repository.
