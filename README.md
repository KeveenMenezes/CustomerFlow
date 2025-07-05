# CustomerFlow

O **CustomerFlow** é um serviço de gestão de clientes projetado para ser altamente performático, escalável e resiliente, utilizando uma arquitetura baseada em eventos e otimizada para velocidade e consistência de dados.

## Principais diferenciais da arquitetura

- **Event-Driven + CQRS**: Separação clara entre comandos (escrita) e queries (leitura) para máxima performance e facilidade de manutenção. Escrita com Entity Framework (EF) garantindo consistência transacional; leitura com Dapper para acesso rápido e direto ao banco, retornando DTOs otimizados.
- **Unit of Work + Outbox Pattern**: Toda operação de escrita ocorre em transação atômica, onde alterações no banco e eventos de integração só são efetivados se todo o comando e eventos de domínio forem concluídos com sucesso. Isso garante confiabilidade e evita inconsistências em cenários distribuídos.
- **Domain Events e Integration Events**: O domínio é rico em eventos, facilitando integrações e evolução para cenários de Event Sourcing ou microserviços.
- **Pronto para bancos incrementais**: Pensado para ser aplicado sobre bancos já existentes, facilitando a evolução de sistemas legados para uma abordagem moderna e incremental.
- **Escalabilidade e Alta Disponibilidade**: Design desacoplado, uso de mensageria e integração moderna permitem escalar leitura e escrita, além de suportar alta disponibilidade.
- **Facilidade de manutenção**: DTOs de leitura não precisam ser persistidos entre camadas, tornando o código mais limpo e fácil de evoluir.
- **Observabilidade e Resiliência**: Instrumentação para OpenTelemetry, Feature Flags e políticas de resiliência para integrações externas.

## Tecnologias e padrões utilizados

- **Entity Framework Core** (escrita)
- **Dapper** (leitura)
- **Mediator** (pipeline de comandos e queries)
- **FluentValidation** (validação)
- **OpenTelemetry** (observabilidade)
- **CAP** (event bus)
- **MySQL** (banco de dados relacional)
- **Outbox Pattern**
- **Unit of Work**
- **Domain Events & Integration Events**
- **Feature Management**
- **API RESTful com ASP.NET Core**
