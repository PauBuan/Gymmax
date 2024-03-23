# Gymmax
Buan Borbe Machine problem 😎 ( NEW REPO )

# Gym Management System

## Configuration
Make sure to open `Gym.mdb` file before anything.

## Running the Project
1. Open `MaxFitnessGym.sln`.
2. Run `logIn.aspx`.
3. Enter `admin` as username and `admin123` as password.
4. Should bring you to the homepage immediately 

The project architecture of our Gym Management System prioritizes efficiency and technical robustness to ensure smooth operation and scalability. Here's a deeper look into its structure:

### 1. Layered Architecture:
   - **Presentation Layer:** Contains the user interface components such as web pages (ASPX files), CSS stylesheets, and client-side scripts. This layer interacts directly with the users and receives their input.
   - **Business Logic Layer:** Responsible for implementing the business rules and logic of the application. It contains classes and methods for processing data, applying business rules, and coordinating the flow of information between the presentation layer and the data access layer.
   - **Data Access Layer:** Handles interactions with the database. It includes data access components such as Data Access Objects (DAOs), Entity Framework models, and database connection management.

### 2. Modular Design:
   - **Modular Components:** The system is divided into modular components, each responsible for specific functionalities such as user authentication, client registration, subscription management, and reporting.
   - **Loosely Coupled Modules:** Modules are designed to be loosely coupled, allowing for easier maintenance, scalability, and code reuse. Changes in one module should have minimal impact on others.

### 3. Scalability and Extensibility:
   - **Scalable Database Design:** The database schema is designed to scale efficiently as the volume of data increases. Proper indexing, normalization, and partitioning strategies are employed to optimize database performance.
   - **Extensible Codebase:** The codebase is designed to accommodate future enhancements and feature additions without significant refactoring. Use of design patterns such as MVC (Model-View-Controller) promotes separation of concerns and modular development.

### 4. Security Measures:
   - **Authentication and Authorization:** User authentication is implemented to ensure that only authorized users can access the system. Role-based access control (RBAC) is used to restrict user privileges based on their roles (admin, client).
   - **Data Encryption:** Sensitive data such as passwords and personal information are encrypted to prevent unauthorized access. Secure communication protocols (HTTPS) are used to protect data transmission over the network.

### 5. Performance Optimization:
   - **Caching Mechanisms:** Caching mechanisms are employed to reduce database load and improve response times. Frequently accessed data and query results are cached to minimize the need for repetitive database queries.
   - **Query Optimization:** Database queries are optimized for performance using techniques such as indexing, query tuning, and use of stored procedures. Batch processing and asynchronous operations are utilized to improve overall system responsiveness.

### 6. Documentation and Testing:
   - **Comprehensive Documentation:** Detailed documentation is provided for the project, including system architecture, database schema, API documentation, and user manuals.
   - **Unit Testing:** Unit tests are implemented to validate the functionality of individual components and ensure code reliability. Integration tests and system tests are also performed to verify the interaction between modules and the overall system behavior.

By adhering to these architectural principles, our Gym Management System ensures a robust, scalable, and efficient solution for managing gym operations and serving the needs of both administrators and clients.

## Features
### 1. Login Page
- Users can log in as an Admin or as a client as well as the functions to change or log out from accounts.

### 2. Register
- Users can register a new client and set their password to set up their account.

### 3. Update Client
- Allows updating the information and subscription duration of the client.

### 4. Delete
- Deletes the information of the client within the database.

### 5. Search
- Provides an index function within the pages of the database to search efficiently by Name or by Subscription type.


## Screenshots
### Login
![image](https://github.com/PauBuan/Gymmax/assets/154594654/f3cb378a-f880-4113-94c3-063ec97ddc0d)

### Register
![image](https://github.com/PauBuan/Gymmax/assets/154594654/bae8101d-8e21-4de6-9c4f-f277760542c1)

### Update
![image](https://github.com/PauBuan/Gymmax/assets/154594654/48f148f0-2d92-41ac-9b07-0acb7ee02aa6)

### Delete
![image](https://github.com/PauBuan/Gymmax/assets/154594654/14380999-4c31-4eaa-8e26-5477ce012666)

### Home
![image](https://github.com/PauBuan/Gymmax/assets/154594654/79ba1b92-c885-4a11-8452-51c5249797ad)

### Customer
![image](https://github.com/PauBuan/Gymmax/assets/154594654/8efd1510-6442-44a6-9982-0b9fd65d510b)

### Subscription
![image](https://github.com/PauBuan/Gymmax/assets/154594654/ec500b1c-66e1-4483-aa26-a5d3a4ea987b)

### Transaction
![image](https://github.com/PauBuan/Gymmax/assets/154594654/e8ca05ab-5289-449e-b9a2-db679da7f0e7)

