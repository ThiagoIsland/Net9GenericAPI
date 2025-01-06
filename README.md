# Generic CRUD API in .NET: Overview

This project demonstrates a clean, modular, and scalable implementation of a CRUD (Create, Read, Update, Delete) API built using .NET 9 and PostgreSQL, following the Clean Architecture principles.

The repository can be used as a template for other projects requiring a structured, testable, and maintainable back-end service.

# Technologies Used

- **.NET 9.0**

- **Entity Framework Core**

- **PostgreSQL**

- **AutoMapper, MediatR, FluentValidation, Npgsql, Swagger/Swashbuckle**

- **Prometheus, OpenTelemetry**

# Architecture

The API adheres to Clean Architecture principles:

- **Domain/Core Layer**: Contains the core logic and entities.

- **Application Layer**: Handles use cases, DTOs, and business rules.

- **nfrastructure/Infra Layer**: Database access, repositories, and external services.

- **API Layer**: Exposes endpoints and manages incoming requests.

# Pre-requisites

- **.NET 9 SDK**: [Download .NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (Direct Download)
```bash
Windows: winget install Microsoft.DotNet.SDK.9
Windows: choco install dotnet-sdk

Linux - Ubuntu/Debian: 
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt update
sudo apt install -y dotnet-sdk-9.0

MacOS: brew install --cask dotnet-sdk
```
- **PostgreSQL**(Version 12+): [Download PostgreSQL](https://www.postgresql.org/download/)


- **IDE**: Visual Studio, Rider, or VS Code

    - **Visual Studio**: [Download Visual Studio](https://visualstudio.microsoft.com/downloads/)
    - **Rider**: [Download Rider](https://www.jetbrains.com/rider/download/)
    - **VS Code**: [Download VS Code](https://code.visualstudio.com/Download)  
      (Personally, I prefer to use Rider or Visual Studio).
  

- **Prometheus**:
    
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
