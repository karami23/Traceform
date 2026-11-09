# TRACEFORM — Emergency Electrical Services Platform

TRACEFORM is a full-stack web platform designed for a professional emergency electrical services business operating across Manchester and Greater Manchester.

The platform provides a structured digital presence for customers to explore electrical services, discover supported service areas, review previous projects, and submit service enquiries. It combines a React-based frontend with an ASP.NET Core Web API, following a layered backend architecture designed for maintainability and scalability.

## Key Features

- **Service Management:** Browse electrical services and view individual service details.
- **Location-Based Pages:** Explore supported service areas through SEO-friendly URLs.
- **Customer Reviews:** Display customer feedback and testimonials.
- **FAQs:** Provide answers to common customer questions.
- **Project Showcase:** Present completed electrical projects.
- **Contact Requests:** Allow customers to submit enquiries through the website.
- **RESTful API:** Deliver structured data to the frontend through dedicated endpoints.
- **Responsive Interface:** Support a consistent experience across desktop and mobile devices.
- **SEO-Friendly Structure:** Use descriptive page content and readable URL slugs.

## Architecture

The backend follows a Clean Architecture-inspired structure, separating business logic, application workflows, infrastructure concerns, and API delivery.

```text
TRACEFORM/
├── Back/
│   ├── Traceform.API/
│   ├── Traceform.Application/
│   ├── Traceform.Domain/
│   └── Traceform.Infrastructure/
│
├── Front/
│   ├── public/
│   ├── src/
│   ├── package.json
│   └── vite.config.ts
│
├── .gitignore
└── README.md
```

### Backend

- **Domain:** Core business entities and domain logic.
- **Application:** Application use cases, DTOs, and abstractions.
- **Infrastructure:** Data access, Entity Framework Core, repositories, and persistence.
- **API:** HTTP endpoints, controllers, dependency injection, and middleware.

### Frontend

A React and TypeScript application built with Vite, using reusable components, page-level organization, routing, and API integration.

## Technology Stack

**Backend**
- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- RESTful API Design
- Clean Architecture
- Swagger / OpenAPI

**Frontend**
- React
- TypeScript
- Vite
- React Router
- Axios
- HTML and CSS

**Development Tools**
- Visual Studio / Visual Studio Code
- SQL Server
- Git and GitHub
- npm

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/services` | Retrieve available services |
| GET | `/api/services/{slug}` | Retrieve service details |
| GET | `/api/areas` | Retrieve service areas |
| GET | `/api/areas/{slug}` | Retrieve area details |
| GET | `/api/reviews` | Retrieve customer reviews |
| GET | `/api/faqs` | Retrieve frequently asked questions |
| GET | `/api/projects` | Retrieve completed projects |
| POST | `/api/contact-requests` | Submit a customer enquiry |

## Getting Started

### Prerequisites

- .NET SDK compatible with the solution
- SQL Server
- Node.js and npm

### 1. Clone the repository

```bash
git clone https://github.com/YOUR_USERNAME/TRACEFORM.git
cd TRACEFORM
```

### 2. Configure the backend

Configure the SQL Server connection string using your local configuration. Do not commit private credentials or development-only settings.

From the repository root:

```bash
cd Back
dotnet restore
dotnet build
```

Apply the Entity Framework Core migrations using the appropriate startup and migrations projects configured in the solution, then run the API:

```bash
dotnet run --project Traceform.API
```

Open the Swagger URL shown in the application output to explore the API.

### 3. Configure the frontend

Open a separate terminal:

```bash
cd Front
npm install
npm run dev
```

Open the local URL printed by Vite in your browser.

Ensure the frontend API base URL points to the backend address configured for your local environment.

## Project Goals

TRACEFORM was developed to demonstrate practical full-stack engineering, including layered backend design, REST API development, relational database integration, frontend architecture, API communication, and the delivery of a customer-focused web application.

The project emphasizes maintainable code organization, separation of concerns, reusable UI components, and a clear integration boundary between frontend and backend.

## License

This repository is intended for portfolio and demonstration purposes.