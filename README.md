# MaterialFlow

MaterialFlow is a high-performance API template built with .NET 10 and C# 13, designed following Clean Architecture and Domain-Driven Design (DDD) principles. It provides a robust foundation for scalable enterprise applications with out-of-the-box support for Identity management, distributed caching, and structured logging.​

🏗 Architecture Layers

The solution is divided into four logic layers to ensure a separation of concerns:

    Domain: The core layer containing Entities and Abstractions. It defines the business models and repository interfaces, remaining independent of external frameworks.

    Application: Implements business use cases using the CQRS pattern with MediatR. This layer handles the flow of data and application-specific logic.

    Infrastructure: Handles external concerns such as database access via EF Core. It includes Configurations (Fluent API), Repositories implementation, and a Dependency Injection wrapper.

    Presentation (API): The entry point of the application, featuring Controllers or Minimal APIs, environment-specific configurations (appsettings.json), and middleware setup.

🛠 Technology Stack & Infrastructure

The project utilizes a fully containerized environment for development and production consistency:
Service	Technology	Port	Description
API	.NET 10	8080	Main application service.
Database	PostgreSQL	5433	Primary relational data storage.
Identity	Keycloak	18080	Identity Provider (IDP) for AuthN/AuthZ.
Cache	Redis 7.2	6379	Distributed in-memory caching.
Logging	Seq	8081	Centralized structured log analysis.

🧪 Testing & Quality

    Unit Testing: Comprehensive tests for the Domain and Application layers to ensure business logic integrity.

    Automated CI: GitHub Actions are configured to run tests and verify builds on every push.​

    Mocking: All infrastructure dependencies are abstracted to allow fast, isolated unit testing.

🚀 Getting Started
Prerequisites

    Docker and Docker Desktop

    .NET 10 SDK

Setup

    Clone the repository:

    bash
    git clone https://github.com/FocuzNo/MaterialFlow.git

    Start the infrastructure:

    bash
    docker-compose up -d

    This command initializes the Database, Keycloak (with realm auto-import), Redis, and Seq.

    Apply Database Migrations:

    bash
    dotnet ef database update --project MaterialFlow.Infrastructure --startup-project MaterialFlow.Api

    Run the application:
    Open the solution in your IDE or run dotnet run --project MaterialFlow.Api.

Monitoring

    Access Seq at http://localhost:8081 to view real-time application logs.

    Access Keycloak at http://localhost:18080 to manage users and roles.

[![CI](https://github.com/FocuzNo/MaterialFlow/actions/workflows/ci.yml/badge.svg)](https://github.com/FocuzNo/MaterialFlow/actions/workflows/ci.yml)
[![Tests](https://github.com/FocuzNo/MaterialFlow/actions/workflows/tests.yml/badge.svg)](https://github.com/FocuzNo/MaterialFlow/actions/workflows/tests.yml)
[![Docker](https://github.com/FocuzNo/MaterialFlow/actions/workflows/docker.yml/badge.svg)](https://github.com/FocuzNo/MaterialFlow/actions/workflows/docker.yml)
[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-10.0-purple.svg)](https://dotnet.microsoft.com/download/dotnet/10.0)
[![C#](https://img.shields.io/badge/C%23-13.0-green.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![GitHub stars](https://img.shields.io/github/stars/FocuzNo/MaterialFlow?style=social)](https://github.com/FocuzNo/MaterialFlow/stargazers)
[![GitHub issues](https://img.shields.io/github/issues/FocuzNo/MaterialFlow)](https://github.com/FocuzNo/MaterialFlow/issues)
[![GitHub pull requests](https://img.shields.io/github/issues-pr/FocuzNo/MaterialFlow)](https://github.com/FocuzNo/MaterialFlow/pulls)
