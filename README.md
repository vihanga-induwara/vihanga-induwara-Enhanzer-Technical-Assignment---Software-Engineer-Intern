# Book Management Application

## Overview

This project is a simple web application for managing a list of books, developed as part of the **Enhanzer Software Engineer Intern** assignment for the IIT Career Day 2025. The application allows users to perform CRUD (Create, Read, Update, Delete) operations on a list of books. It features a user-friendly interface for adding, viewing, editing, and deleting books, with form validation and error handling to enhance the user experience.

The project is divided into two main parts:
- **Backend**: A RESTful API built with ASP.NET Core and C#, using an in-memory list to store book data.
- **Frontend**: A single-page application (SPA) built with Angular, providing a clean and responsive UI to interact with the backend API.

The source code is hosted on GitHub: [https://github.com/your-username/BookManagementApp](https://github.com/your-username/BookManagementApp) *(replace with your actual GitHub repository URL)*.

A screen recording of the application in action is included in the submission as `BookManagementDemo.mp4`.

---

## Technologies Used

The project leverages the following technologies, as specified in the assignment requirements:

### Backend
- **ASP.NET Core with C#**: Used to create a RESTful API for handling CRUD operations on books.
- **In-Memory Data Storage**: A simple in-memory list (`List<Book>`) to store book data, as per the assignment requirements.
- **Swashbuckle.AspNetCore**: Added to provide Swagger UI for easy API testing during development.

### Frontend
- **Angular**: Used to build a single-page application with a responsive UI for managing books.
- **HTML, CSS, JavaScript/TypeScript**: Core web technologies for building the frontend UI and logic.
- **CommonModule**: For Angular directives like `*ngIf` and `*ngFor`.
- **FormsModule**: For two-way data binding with `ngModel` and form validation.
- **HttpClientModule**: For making HTTP requests to the backend API.

### Development Tools
- **Node.js and npm**: For managing Angular dependencies and running the frontend.
- **Angular CLI**: For generating and managing the Angular project.
- **.NET SDK**: For building and running the ASP.NET Core backend.
- **Visual Studio Code**: Used as the primary code editor, with extensions for C# and Angular development.

---

## Why I Chose This Approach

### Backend (ASP.NET Core)
- **In-Memory Storage**: I used an in-memory list to store books, as specified in the assignment. This approach simplifies the setup by avoiding the need for a database, making it ideal for a small-scale project like this.
- **RESTful API Design**: I structured the API to follow REST principles, with endpoints like `GET /api/books`, `POST /api/books`, `PUT /api/books/{id}`, and `DELETE /api/books/{id}`. This ensures a clear and standard way to interact with the backend.
- **CORS Configuration**: I enabled CORS to allow the Angular frontend (running on `http://localhost:4200`) to communicate with the backend (running on `http://localhost:5150`), ensuring seamless integration.
- **Swagger Integration**: I added Swagger UI to make it easier to test the API endpoints during development, which also demonstrates my attention to developer experience.

### Frontend (Angular)
- **Standalone Components**: I used Angular’s standalone components (a modern feature in Angular 17+), which eliminates the need for `NgModule` and simplifies the project structure. This aligns with current best practices in Angular development.
- **Form Validation**: I implemented form validation for fields like `title`, `author`, `isbn`, and `publicationDate`, ensuring users provide valid input (e.g., ISBN must match the pattern `123-1234567890`). This improves the user experience by preventing invalid submissions.
- **Error Handling**: I added error messages for API failures (e.g., "Error loading books") and form validation errors, making the application more robust and user-friendly.
- **Responsive UI**: I applied basic CSS styling to make the UI clean and professional, with a table layout for the book list and a form for adding/editing books. This enhances the visual appeal and usability of the application.
- **Date Handling**: I ensured that the `publicationDate` field, which is sent as an ISO string from the backend (e.g., `"1925-04-10T00:00:00"`), is correctly handled in the frontend. The `date` pipe formats it for display, and the form’s `<input type="date">` uses the `yyyy-mm-dd` format for user input.

### General
- **HTTP vs. HTTPS**: I initially configured the backend to support HTTPS for secure communication, but I switched to HTTP for local development to avoid certificate issues when the frontend communicates with the backend. In a production environment, I would ensure HTTPS is enforced with a proper certificate.
- **Type Safety**: I used TypeScript interfaces (e.g., `Book`) to ensure type safety in the frontend, reducing runtime errors and improving code maintainability.
- **Error-Free Code**: I resolved all compilation errors by ensuring proper type alignment (e.g., keeping `publicationDate` as a string in the `Book` interface) and correctly importing Angular modules (`CommonModule`, `FormsModule`).

---

## Setup Instructions

Follow these steps to set up and run the project locally.

### Prerequisites
- **Node.js and npm**: Install from [nodejs.org](https://nodejs.org/) (version 18.x or later recommended).
- **Angular CLI**: Install globally with `npm install -g @angular/cli`.
- **.NET SDK**: Install from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download) (version 6.0 or later).
- **Visual Studio Code** (optional): Recommended for editing the code, with extensions for C# and Angular.

### Project Structure

# Book Management App

## Project Structure
```
BookManagementApp/
├── backend/
│   └── BookApi/          # ASP.NET Core backend project
└── frontend/
    └── BookApp/          # Angular frontend project
```

## Backend Setup
1. Navigate to the backend folder:
   ```bash
   cd backend/BookApi
   ```
2. Restore dependencies and run the backend:
   ```bash
   dotnet restore
   dotnet run
   ```
   The backend will start on [http://localhost:5150](http://localhost:5150) (and optionally [https://localhost:7150](https://localhost:7150) if HTTPS is enabled).

3. Access the Swagger UI at [http://localhost:5150/swagger](http://localhost:5150/swagger) to test the API endpoints.

## Frontend Setup
1. Navigate to the frontend folder:
   ```bash
   cd frontend/BookApp
   ```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Run the Angular app:
   ```bash
   ng serve
   ```
   The frontend will start on [http://localhost:4200](http://localhost:4200).

## Running the Application
- Ensure the backend is running on [http://localhost:5150](http://localhost:5150).
- Open [http://localhost:4200](http://localhost:4200) in your browser to access the application.
- Use the UI to:
  - View the list of books.
  - Add a new book.
  - Edit an existing book.
  - Delete a book.
  - Test form validation by submitting invalid data (e.g., empty fields or an invalid ISBN).

## Features
- **CRUD Operations**: Add, view, update, and delete books using a RESTful API.
- **Form Validation**: Ensures required fields are filled and ISBN follows the pattern `123-1234567890`.
- **Error Handling**: Displays user-friendly error messages for API failures and form validation errors.
- **Responsive UI**: Clean and professional design with a table for the book list and a form for adding/editing books.
- **Date Formatting**: Properly handles the `publicationDate` field, displaying it in a readable format (e.g., "Apr 10, 1925") and allowing user input via a date picker.

## Challenges and Solutions
### Angular Standalone Components
- The project initially used a traditional `NgModule` setup, but errors occurred because `AppComponent` was standalone.
- Solution: Removed `AppModule`, used `bootstrapApplication` in `main.ts`, and directly imported `CommonModule` and `FormsModule` in `AppComponent`.

### Type Mismatch for `publicationDate`
- The `Book` interface defined `publicationDate` as a string, but it was being converted to a `Date` object, causing type errors.
- Solution: Kept `publicationDate` as a string throughout the frontend since the `date` pipe can handle ISO strings directly.

### HTTPS Certificate Issues
- The backend initially had issues with HTTPS redirection.
- Solution: Configured HTTPS with a development certificate (`dotnet dev-certs https --trust`), but switched to HTTP for local development to avoid certificate errors.

### CORS Configuration
- Enabled CORS in the backend to allow the frontend to make requests, ensuring seamless integration between the two.

## Video Demo
A screen recording of the application in action is provided in `BookManagementDemo.mp4`. The video demonstrates:
- Viewing the list of books.
- Adding a new book.
- Editing an existing book.
- Deleting a book.
- Form validation (e.g., submitting an empty form or invalid ISBN).

## Future Improvements
If more time were available, the following enhancements could be made:
- **Database Integration**: Replace the in-memory list with a database (e.g., SQL Server) for persistent storage.
- **Confirmation Dialog for Delete**: Add a confirmation dialog before deleting a book to prevent accidental deletions.
- **Advanced Styling**: Use a CSS framework like Bootstrap to improve the UI’s appearance and responsiveness.
- **Unit Tests**: Add unit tests for both the backend and frontend to ensure code reliability.

## Submission Details
- **Source Code**: Available on GitHub at [https://github.com/your-username/BookManagementApp](https://github.com/your-username/BookManagementApp) (replace with actual repository URL).
- **Video Demo**: Included as `BookManagementDemo.mp4` in the submission.
- **Deadline**: Submitted before **March 30, 2025, at 4:00 PM**, as per the assignment requirements.

## Contact Information
For any questions or further clarification, please contact me at `20indu03@gmail.com` . I am also happy to discuss the project in more detail during the interview process.

Thank you for considering my application for the **Software Engineer Intern** position at **Enhanzer**!


