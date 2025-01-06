# Generic CRUD API in .NET: Overview

This project demonstrates a clean, modular, and scalable implementation of a CRUD (Create, Read, Update, Delete) API built using .NET 9 and PostgreSQL, following the Clean Architecture principles.

The repository can be used as a template for other projects requiring a structured, testable, and maintainable back-end service.

# Technologies Used

•⁠  ⁠.NET 9.0

•⁠  ⁠Entity Framework Core

•⁠  ⁠PostgreSQL

•⁠  ⁠AutoMapper, MediatR, FluentValidation, Npgsql, Swagger/Swashbuckle

•⁠  ⁠Prometheus, OpenTelemetry

# Architecture

The API adheres to Clean Architecture principles:

•⁠  ⁠Domain/Core Layer: Contains the core logic and entities.

•⁠  ⁠Application Layer: Handles use cases, DTOs, and business rules.

•⁠  ⁠Infrastructure/Infra Layer: Database access, repositories, and external services.

•⁠  ⁠API Layer: Exposes endpoints and manages incoming requests.

# Pre-requisites

•⁠  ⁠.NET 9 SDK

•⁠  ⁠PostgreSQL: Version 12+

•⁠  ⁠IDE: Visual Studio, Rider, or VS Code (Personally, I prefer to use Rider or Visual Studio).

•⁠  ⁠Prometheus:

    
```bash
  Linux
    Ubuntu/Others + SNAP: sudo snap install prometheus
    Fedora: sudo dnf install prometheus
 ```
```bash
  MacOS
    brew install Prometheus
 ```
```bash
  Windows + Chocolatey
    choco install prometheus
 ```

# Things I still pretend to implement:

•⁠  ⁠~~Other CRUD methods (Add User/Pessoa, Edit User/Pessoa, Remove User/Pessoa) and Dependency Injection~~

•⁠  ⁠~~Repository Layer and all others principles and concepts who makes this API be Clean ARCH~~

•⁠  ⁠~~Prometheus.NET and OpenTelemetry for observability, metrics collection and the API perfomance~~

•⁠  ⁠Polly: A library that improves resiliency to your appliaction aplying strategies like Circuit Breaker, Retry, Timeout, etc...
