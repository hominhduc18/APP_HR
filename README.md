API (Controller) -> Application (Service / UseCase)-> Domain (Entity / Business Rule)-> Infrastructure (Database / External)

CleanAuthSolution/
├── CleanAuth.Domain/          # Domain Layer (Entities, Interfaces)
│   ├── Common/               # Base classes
│   ├── Entities/             # Domain entities
│   ├── Enums/                # Enumerations
│   ├── Events/               # Domain events
│   ├── Exceptions/           # Domain exceptions
│   ├── Interfaces/           # Repository interfaces
│   └── ValueObjects/         # Value objects
├── CleanAuth.Application/     # Application Layer
│   ├── Common/               # Base classes
│   ├── DTOs/                 # Data Transfer Objects
│   ├── Interfaces/           # Service interfaces
│   ├── Services/             # Application services
│   ├── UseCases/             # Use cases/CQRS
│   └── Validators/           # Fluent validators
├── CleanAuth.Infrastructure/  # Infrastructure Layer
│   ├── Data/                 # Entity Framework
│   ├── Email/                # Email services
│   ├── Identity/             # JWT, Password hashing
│   ├── Repositories/         # Repository implementations
│   └── Services/             # External services
├── CleanAuth.API/            # API Layer
│   ├── Controllers/
│   ├── Middleware/
│   ├── Filters/
│   └── Extensions/
└── CleanAuth.Tests/          # Test projects
