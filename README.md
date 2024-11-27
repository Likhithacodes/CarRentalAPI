# Car Rental System API

The **Car Rental System API** is a RESTful API built with **C#**, **ASP.NET Core web API**, and **Entity Framework (EF)**.
It allows users to manage a fleet of cars, perform CRUD operations on cars, handle user registration and authentication, rent cars, check availability, and receive email notifications for successful bookings. 
The system uses **JWT-based authentication** for secure access and role-based authorization to distinguish between `Admin` and `User`.

---

## Features
### User Management
- **Register User**: Register a new user with roles (`Admin` or `User`).
- **Login User**: Authenticate users and generate a JWT token for secure access.
  
### Car Management
- **Get Available Cars**: Retrieve a list of cars currently available for rent.
- **Add Car**: Add a new car to the fleet (Admin only).
- **Update Car**: Modify car details or update availability (Admin only).
- **Delete Car**: Remove a car from the fleet (Admin only).

### Rental Operations
- **Rent Car**: Allow users to rent a car for a specified number of days. Calculate rental price and mark the car as unavailable.

### Notifications
- **Email Notifications**: Send email confirmation for successful bookings using **SendGrid**.

### Security
- **JWT Authentication**: Secure endpoints with JWT tokens.
- **Role-based Authorization**: Restricted certain operations (car addition,updation,deletion) to `Admin` users only.
  ---

## Endpoints

### CarController

| HTTP Method | Endpoint         | Description                           | Authorization |
|-------------|------------------|---------------------------------------|---------------|
| GET       | /api/cars      | Get a list of available cars          | None          |
| POST      | /api/cars      | Add a new car to the fleet            | Admin         |
| PUT       | /api/cars/{id} | Update car details and availability   | Admin         |
| DELETE    | /api/cars/{id} | Delete a car from the fleet           | Admin         |

### UserController

| HTTP Method | Endpoint               | Description                                | Authorization |
|-------------|------------------------|--------------------------------------------|---------------|
| POST      | /api/users/register  | Register a new user                        | None          |
| POST      | /api/users/login     | Login and get a JWT token                  | None          |

---

## Database Models

### Car
| Field          | Type         | Description                          |
|----------------|--------------|--------------------------------------|
| Id           | int        | Unique identifier for the car.       |
| Make         | string     | Manufacturer of the car.             |
| Model        | string     | Model of the car.                    |
| Year         | int        | Year of manufacture.                 |
| PricePerDay  | decimal    | Rental price per day.                |
| IsAvailable  | bool       | Availability status of the car.      |

### User
| Field          | Type         | Description                          |
|----------------|--------------|--------------------------------------|
| Id           | int        | Unique identifier for the user.      |
| Name         | string     | Name of the user.                    |
| Email        | string     | Email address of the user.           |
| Password     | string     | User's password (plaintext for now). |
| Role         | string     | Role of the user (Admin or User).|

---
##POSTMAN TESTING
**Registering a Admin/User**
![image](https://github.com/user-attachments/assets/03fb1239-c20f-4244-9b82-406af6021085)
if trying to register with the same user details
![image](https://github.com/user-attachments/assets/59207c97-26f0-44df-b3e8-b6c876f57a48)

![image](https://github.com/user-attachments/assets/3ab1b642-f9a8-4416-8de7-c22cbfe72692)
if invalid credentials
![image](https://github.com/user-attachments/assets/c0ab8673-b156-47a8-83a0-8fdc7d1cce21)

**Get All the car details**
![image](https://github.com/user-attachments/assets/b7ae5877-3001-458a-8f1c-9d9b5a48c4d7)

**Add the car **
![image](https://github.com/user-attachments/assets/548f389f-8cff-430e-bfe0-4085cd1ccca0)

the data is reflecting in the db
![image](https://github.com/user-attachments/assets/ecae5b08-45ff-487a-9c69-980a1670d187)


**Update the car details of a particular ID**
![image](https://github.com/user-attachments/assets/7ffba52e-16a2-44c4-ac6f-f67ed2ab0341)

Updated values
![image](https://github.com/user-attachments/assets/0ff49132-8118-476e-a95f-51c46f97a4f5)

**Delete a car**
![image](https://github.com/user-attachments/assets/2bd5f0ee-03f0-4ae0-a499-986b3ce431bc)

after deleting the car with ID=1 got removed from the database
![image](https://github.com/user-attachments/assets/8754d82c-37a7-41e8-a127-974bfbddd9e6)

if trying to add a car without Authorization
![image](https://github.com/user-attachments/assets/0e0655f5-ec58-4ecf-89df-d7538eb37bae)

I tried sending an email with the sendgrid but i was unable to login into the sendgrid and get and APIKey
