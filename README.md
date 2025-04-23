# Airline Ticketing System API 🛫

A RESTful API for managing airline flights, ticket purchases, and passenger check-ins. Built with **.NET 8**, **MySQL**, and deployed on **Azure**. Compliant with service-oriented architecture principles.

---

## Project Overview
This API allows airline companies to:
- Schedule flights with capacity tracking.
- Query available flights based on dates and airports.
- Purchase tickets and manage seat availability.
- Check-in passengers with seat assignments.
- Retrieve passenger lists for flights.

---

## Key Features
- **JWT Authentication** for secure endpoints.
- **Pagination** for large datasets.
- **Versioned APIs** (`v1`).
- **Swagger UI** for interactive testing.
- Cloud-hosted

---

## API Endpoints
| Endpoint                                    | Method | Auth Required | Paging | Description                                   |
|---------------------------------------------|--------|---------------|--------|-----------------------------------------------|
| `/api/v1/flights`                           | POST   | ✅            | ❌     | Add a new flight to the schedule.             |
| `/api/v1/flights/`                          | GET    | ❌            | ✅     | Search available flights                      |
| `/api/v1/flights/{flightNumber}/passengers` | GET    | ✅            | ✅     | Retrieve passenger list for a flight.         |
| `/api/v1/tickets/buy`                       | POST   | ✅            | ❌     | Buy a ticket                                  |
| `/api/v1/tickets/checkin`                   | POST   | ❌            | ❌     | Check-in a passenger and assign a seat.       |

---

## Assumptions & Design Decisions
- **Seat Assignment**: Sequential numbering (e.g., Seat 1, Seat 2).
- **DTOs**: Used for data transfer between layers (no direct DB exposure).
- **Authentication**: JWT tokens for secure endpoints.
- **Paging**: Default page size of 10 for paginated responses.

---

## Design & Architecture
**Service-Oriented Architecture** principles guide this project:
1. **Controllers**: 
   - Handle HTTP requests/responses.
   - Validate inputs and delegate business logic to services.
   - Example: `FlightsController` → `FlightService`.

2. **Services**:
   - Encapsulate core business logic (e.g., flight availability checks, seat assignment).
   - Interact with the database via repositories.
   - Example: `TicketService` handles ticket purchases and capacity updates.

3. **DTOs (Data Transfer Objects)**:
   - Used for input/output between layers (e.g., `ResponseDTO`).
   - Prevent direct exposure of database models.

4. **Database Layer**:
   - MySQL for persistent storage.
   - Entity Framework Core for ORM and migrations.
   - Models: `Flight`, `Passenger`, `Ticket`.

5. **Dependency Injection**:
   - Services and repositories are injected into controllers.
   - Promotes loose coupling and testability.

---

## Links
**Swagger Docs:** [https://gd-airline-ticket-api.azurewebsites.net/swagger/index.html](https://gd-airline-ticket-api.azurewebsites.net/swagger/index.html)
**YouTube Link:** [https://youtu.be/mKkkHSPqrtk](https://youtu.be/mKkkHSPqrtk)

---
## Author
Gulce DOGRUOZ - 20070001020
