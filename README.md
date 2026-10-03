<sub>🇺🇸 **English** · 🇧🇷 [Português](README.pt-BR.md)</sub>

# CustomerFlow

**CustomerFlow** is a customer management service designed to be highly performant, scalable and resilient, built on an event-driven architecture optimized for speed and data consistency.

## Architecture highlights

- **Event-Driven + CQRS**: Clear separation between commands (writes) and queries (reads) for maximum performance and maintainability. Writes use Entity Framework (EF) for transactional consistency; reads use Dapper for fast, direct database access returning optimized DTOs.
- **Unit of Work + Outbox Pattern**: Every write runs in an atomic transaction, where database changes and integration events are only committed if the whole command and its domain events succeed. This guarantees reliability and prevents inconsistencies in distributed scenarios.
- **Domain Events and Integration Events**: An event-rich domain that makes integrations easy and paves the way to Event Sourcing or microservices.
- **Ready for existing databases**: Designed to be applied over existing databases, making it easier to evolve legacy systems incrementally towards a modern approach.
- **Scalability and High Availability**: A decoupled design, messaging and modern integrations allow reads and writes to scale independently and support high availability.
- **Maintainability**: Read DTOs don't need to be persisted across layers, keeping the code cleaner and easier to evolve.
- **Observability and Resilience**: Instrumented with OpenTelemetry, Feature Flags and resilience policies for external integrations.
- **Easy migration to databases without auto-increment**: The chosen pattern simplifies moving to databases that don't use auto-increment or that support strategies like HiLo. This matters because MySQL makes HiLo hard to use with EF Core, while other databases allow that transition more easily.

## Trade-offs and limitations

**Dependency on Entity Framework**: The system relies on EF Core change tracking, mainly because of MySQL auto-increment IDs. This coupling can make repository abstraction harder and limit the flexibility to swap the ORM or database in the future.
**Tracking active until the handler**: Tracking stays active until the handler, which makes entity changes easy but can cause unwanted side effects without proper control. It is required so that domain events depending on the ID are only raised after the transaction commits, when the ID is available.
**Domain events depending on the ID**: To raise domain events, the full object (e.g. `Customer`) must be passed so the handler can access the generated ID. This reinforces the dependency on the entity lifecycle and the transaction commit.


## Recommendations and remediations

**Teams with DDD knowledge**: This application should be developed by teams with solid Domain-Driven Design knowledge, able to separate contexts well and use rich entities.
**Study the architecture first**: A prior study of the proposed architecture is essential and brings significant benefits to development and maintenance.
**Experience with Entity Framework and events**: The team should be experienced with Entity Framework and event-driven architecture, ensuring the patterns are used correctly and avoiding common tracking and event publishing issues.
**Classes that need attention**: The team must deeply understand how `UnitOfWorkBehavior` and `DispatchDomainEventsInterceptor` work, since they handle transaction control and event publishing and directly affect the system's consistency and traceability.

## Technologies and patterns

- **Entity Framework Core** (writes)
- **Dapper** (reads)
- **Mediator** (command and query pipeline)
- **FluentValidation** (validation)
- **OpenTelemetry** (observability)
- **CAP** (event bus)
- **MySQL** (relational database)
- **Outbox Pattern**
- **Unit of Work**
- **Domain Events & Integration Events**
- **Feature Management**
- **RESTful API with ASP.NET Core**
