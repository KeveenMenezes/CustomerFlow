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
- **Facilidade de migração para bancos sem autoincremento**: O padrão adotado facilita a migração para bancos que não utilizam autoincremento ou que suportam estratégias como HiLO. Isso é especialmente relevante, pois o MySQL apresenta dificuldades para uso do HiLO com EF Core, enquanto outros bancos podem permitir essa transição de forma mais simples.

## Trade-offs e Limitações

**Dependência do Entity Framework**: O sistema depende do EF Core para manter o tracking das entidades, especialmente por causa do autoincremento de IDs no MySQL. Esse acoplamento pode dificultar a abstração do repositório e limitar a flexibilidade para trocar o ORM ou o banco de dados no futuro.
**Tracking ativo até o handler**: O tracking permanece ativo até o handler, facilitando alterações nas entidades e podendo causar efeitos colaterais indesejados se não houver controle. Isso é necessário para garantir que eventos de domínio que dependem do ID só sejam disparados após o commit da transação, quando o ID está disponível.
**Eventos de domínio dependentes do ID**: Para levantar eventos de domínio, é necessário passar o objeto completo (por exemplo, `Customer`) para garantir que o handler tenha acesso ao ID gerado. Isso reforça a dependência do ciclo de vida da entidade e do commit da transação.


## Recomendações e Remediações

**Equipes com conhecimento em DDD**: Esta aplicação deve ser desenvolvida por equipes com conhecimento adequado em Domain-Driven Design, capazes de separar bem os contextos e utilizar entidades ricas.
**Pré-estudo da arquitetura**: É fundamental realizar um pré-estudo da arquitetura proposta, pois isso trará benefícios significativos ao desenvolvimento e à manutenção do sistema.
**Experiência com Entity Framework e eventos**: O time deve possuir experiência com Entity Framework e arquitetura baseada em eventos, garantindo o uso correto dos padrões e evitando problemas comuns de tracking e publicação de eventos.

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
