# Pipeline Behavior (CQRS / Mediator style)
Essa é a abordagem mais comum em arquiteturas CQRS.

## Conceito da Pipeline
A pipeline funciona como uma cadeia:

```mermaid
flowchart TD
    A[HTTP Request] --> B[Command]
    B --> C[Mediator.Send()]
    C --> D[Validation Behavior]
    D --> E[Logging Behavior]
    E --> F[Transaction Behavior]
    F --> G[Handler]
```