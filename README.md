# Post API with xUnit Testing

This project demonstrates a RESTful API for managing posts, built using **.NET 9**. It includes full CRUD operations and implements **unit testing** using **xUnit**, **Moq**, and **FluentAssertions**.

---

## **Features**

- **CRUD Operations**:
  - `GET /api/posts` - Retrieve all posts.
  - `GET /api/posts/{id}` - Retrieve a specific post by ID.
  - `GET /api/posts/{id}/comments` - Retrieve comments for a specific post.
  - `POST /api/posts` - Create a new post.
  - `PUT /api/posts/{id}` - Update an existing post.
  - `PATCH /api/posts/{id}` - Partially update a post.
  - `DELETE /api/posts/{id}` - Delete a post.

- **Service Layer**: Implements `IPostService` for API logic, using `HttpClient` via `IHttpClientFactory`.

- **Unit Testing**:
  - Tests for all endpoints using **xUnit**.
  - Mocked `IPostService` using **Moq**.
  - Validation of HTTP responses and behaviors.

---

## **Technologies Used**

- **Backend**: .NET 9
- **Unit Testing**: xUnit, Moq, FluentAssertions
- **Dependency Injection**: Built-in DI container
- **HTTP Client**: `IHttpClientFactory` for external API calls
- **Data Serialization**: System.Text.Json

---

## **Getting Started**

### Prerequisites

Ensure you have the following installed:

- [.NET SDK (latest version)](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/)
- [Postman](https://www.postman.com/) or any API testing tool

---

### **Run the Application**

1. Clone the repository:
   ```bash
   git clone https://github.com/Prashant-Odhavani/xUnitDemo.git
   
