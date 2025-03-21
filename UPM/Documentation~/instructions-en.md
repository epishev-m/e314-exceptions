# E314.Exceptions

## Description

The `E314.Exceptions` module provides enhanced exception classes that improve standard error handling mechanisms in .NET. These exceptions include additional data such as a unique error code (`ErrorCode`), extra data (`ErrorData`). This makes debugging and logging more informative.

## Content tree

- [E314.Exceptions](#e314exceptions)
  - [Description](#description)
  - [Content tree](#content-tree)
  - [Advantages](#advantages)
  - [When to Use the Module?](#when-to-use-the-module)
  - [How to Use the Module?](#how-to-use-the-module)
    - [Method Parameter Validation](#method-parameter-validation)
    - [Object State Validation](#object-state-validation)
    - [Using an Object After It Has Been Disposed](#using-an-object-after-it-has-been-disposed)
    - [Handling Complex Scenarios](#handling-complex-scenarios)
    - [Logging and Diagnostics](#logging-and-diagnostics)
  - [Recommendations](#recommendations)

## Advantages

- **Informativeness**: Exceptions contain more data, simplifying problem diagnosis.
- **Flexibility**: Support for additional data via the `ErrorData` property.
- **Serialization**: Support for serialization through the `SerializationInfo` constructor.

## When to Use the Module?

Use the `E314.Exceptions` module if:

- You want to add more context to errors (e.g., a unique error code or additional data).
- You want to simplify logging and problem diagnostics.
- You need specialized exceptions for typical scenarios (e.g., argument validation, out-of-range values).

## How to Use the Module?

### Method Parameter Validation

When to use:

- If a parameter must not be null.
- If a string or collection must not be empty.
- If a numeric value must be within a specific range.

``` csharp
using E314.Exceptions;

public void SetPlayerName(string name)
{
    if (string.IsNullOrEmpty(name))
    {
        throw new ArgNullException(nameof(name));
    }
    // ...
}

public void SetHealth(int health)
{
    if (health < 0 || health > 100)
    {
        throw new ArgOutOfRangeException(
            nameof(health),
            health,
            "Health must be between 0 and 100.",
            errorData: new { MinValue = 0, MaxValue = 100 });
    }
    // ...
}
```

### Object State Validation

When to use:

- If a method depends on prior object initialization.
- If you need to ensure the object is in a valid state.

``` csharp
private bool _isInitialized;

public void PerformAction()
{
    if (!_isInitialized)
    {
        throw new InvOpException(
            "Object must be initialized before use.",
            errorCode: "INIT_REQUIRED",
            errorData: new { IsInitialized = _isInitialized });
    }
    // ...
}
```

### Using an Object After It Has Been Disposed

When to use:

- If you want to explicitly state that the object has been released and cannot be used.

``` csharp
public class DisposableResource : IDisposable
{
    private bool _isDisposed;

    public void Dispose()
    {
        _isDisposed = true;
        // ...
    }

    public void PerformAction()
    {
        if (_isDisposed) throw new ObjDisposedException();
        // ...
    }
}
```

### Handling Complex Scenarios

When to use:

- If you need to pass additional error-related data (e.g., context or metadata).
- If you want to use a unique error code to identify the issue.

``` csharp
public void ProcessOrder(Order order)
{
    if (order == null)
    {
        throw new ArgNullException(
            nameof(order),
            errorData: new { Context = "Order processing", Timestamp = DateTime.UtcNow });
    }

    if (!order.IsValid())
    {
        throw new InvOpException(
            "Order is not valid.",
            errorCode: "ORDER_INVALID",
            errorData: new { OrderId = order.Id, Status = order.Status });
    }
    // ...
}
```

### Logging and Diagnostics

When to use:

- If you want to get a full error description for logging.

``` csharp
try
{
    PerformCriticalOperation();
}
catch (DetailedException ex)
{
    Console.WriteLine(ex.ToString());
    
    Logger.LogError(
        message: ex.Message,
        errorCode: ex.ErrorCode,
        errorData: ex.ErrorData);
}
```

## Recommendations

- Use unique error codes:
  - Each error type should have a unique code (ErrorCode) to make it easily identifiable during logging or debugging.
- Add context via ErrorData:
  - Pass additional data through the ErrorData property. This could be an object containing metadata, timestamps, or other useful details.
- Specialized exceptions:
  - Use classes like `ArgNullException`, `ArgOutOfRangeException`, and `InvOpException` for common scenarios. This makes the code more readable and understandable.
- Logging:
  - Always log errors using all available data (`Message`, `ErrorCode`, `ErrorData`).
