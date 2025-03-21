# E314.Exceptions

## Описание

Модуль `E314.Exceptions` предоставляет расширенные классы исключений, которые улучшают стандартные механизмы обработки ошибок в .NET. Эти исключения содержат дополнительные данные, такие как уникальный код ошибки (`ErrorCode`) и дополнительные данные (`ErrorData`). Это делает отладку и логирование более информативными.

## Содержание

- [E314.Exceptions](#e314exceptions)
  - [Описание](#описание)
  - [Содержание](#содержание)
  - [Преимущества](#преимущества)
  - [Когда использовать модуль?](#когда-использовать-модуль)
  - [Как использовать модуль?](#как-использовать-модуль)
    - [Проверка параметров метода](#проверка-параметров-метода)
    - [Проверка состояния объекта](#проверка-состояния-объекта)
    - [Использование объекта после его освобождения](#использование-объекта-после-его-освобождения)
    - [Обработка сложных сценариев](#обработка-сложных-сценариев)
    - [Логирование и диагностика](#логирование-и-диагностика)
  - [Рекомендации](#рекомендации)

## Преимущества

- **Информативность**: Исключения содержат больше данных, что упрощает диагностику проблем.
- **Гибкость**: Поддержка дополнительных данных через свойство `ErrorData`.
- **Сериализация**: Поддержка сериализации через конструктор `SerializationInfo`.

## Когда использовать модуль?

Используйте модуль `E314.Exceptions`, если:

- Вы хотите добавить больше контекста к ошибкам (например, уникальный код ошибки или дополнительные данные).
- Вы хотите упростить логирование и диагностику проблем.
- Вам нужны специализированные исключения для типичных сценариев (например, проверка аргументов, выход за пределы диапазона).

## Как использовать модуль?

### Проверка параметров метода

Когда использовать:

- Если параметр не должен быть null.
- Если строка или коллекция не должна быть пустой.
- Если числовое значение должно находиться в определённом диапазоне.

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

### Проверка состояния объекта

Когда использовать:

- Если метод зависит от предварительной инициализации объекта.
- Если нужно убедиться, что объект находится в корректном состоянии.

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

### Использование объекта после его освобождения

Когда использовать:

- Вы хотите явно указать, что объект был освобожден и не может быть использован.

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

### Обработка сложных сценариев

Когда использовать:

- Если нужно передать дополнительные данные об ошибке (например, контекст или метаданные).
- Если вы хотите использовать уникальный код ошибки для идентификации проблемы.

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

### Логирование и диагностика

Когда использовать:

- Если вы хотите получить полное описание ошибки для логирования.

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
        errorData: ex.ErrorData,
        fileName: ex.FileName,
        methodName: ex.MethodName,
        lineNumber: ex.LineNumber);
}
```

## Рекомендации

- Используйте уникальные коды ошибок:
  - Каждый тип ошибки должен иметь уникальный код (`ErrorCode`), чтобы его можно было легко идентифицировать при логировании или отладке.
- Добавляйте контекст через `ErrorData`:
  - Передавайте дополнительные данные через свойство ErrorData. Это может быть объект, содержащий метаданные, временные метки или другие полезные детали.
- Специализированные исключения:
  - Используйте классы `ArgNullException`, `ArgOutOfRangeException` и `InvOpException` для типичных сценариев. Это делает код более читаемым и понятным.
- Логирование:
  - Всегда логируйте ошибки с использованием всех доступных данных (`Message`, `ErrorCode`, `ErrorData`).
