# Pull Request

## Summary
Provide a short description of the change and the problem it solves.

Example:
Adds retry policy to RabbitMQ consumer to prevent message loss when transient errors occur.

---

## Motivation
Why is this change needed?

- Fix bug
- Improve performance
- Refactor code
- New feature
- Tech debt reduction

Explain the context or the problem being solved.

---

## Changes
Describe the main changes introduced in this PR.

- Added `RetryPolicyMiddleware`
- Updated `OrderConsumer`
- Introduced new configuration `Messaging:Retry`
- Refactored message handling pipeline

---

## Architecture Impact
Explain any architectural impact.

- [ ] No architectural change
- [ ] New dependency added
- [ ] Infrastructure change
- [ ] Messaging contract change
- [ ] Database schema change

Details:

---

## Breaking Changes
If applicable, describe breaking changes.

Example:
Consumers must now implement `IMessageHandler<T>`.

---

## How to Test
Steps to verify the changes.

1. Run the application
2. Publish a message to `orders.created`
3. Force a temporary failure
4. Verify retry behavior

---

## Screenshots / Logs (if applicable)

Add logs, screenshots, traces, or metrics.

---

## Observability
Describe logging, metrics, or tracing added.

Example:
- Structured log added for retry attempts
- OpenTelemetry span added for message processing

---

## Checklist

- [ ] Code follows project conventions
- [ ] Tests added or updated
- [ ] No sensitive information committed
- [ ] Documentation updated
- [ ] Logging added where appropriate
- [ ] Error handling considered
- [ ] PR is small and focused
