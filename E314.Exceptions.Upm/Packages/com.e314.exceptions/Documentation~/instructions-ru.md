# E314.Exceptions

## Описание

Модуль `E314.Exceptions` предоставляет расширенные классы исключений, которые улучшают стандартные механизмы обработки ошибок в .NET. Эти исключения содержат дополнительные данные, такие как уникальный код ошибки (`ErrorCode`), дополнительные данные (`ErrorData`), имя файла, метода и номер строки, где возникло исключение. Это делает отладку и логирование более информативными.

## Содержание

- [E314.Exceptions](#e314exceptions)
  - [Описание](#описание)
  - [Содержание](#содержание)
  - [Преимущества](#преимущества)
  - [Когда использовать модуль?](#когда-использовать-модуль)
  - [Как использовать модуль?](#как-использовать-модуль)
    - [Проверка параметров метода](#проверка-параметров-метода)
    - [Проверка состояния объекта](#проверка-состояния-объекта)
    - [Обработка сложных сценариев](#обработка-сложных-сценариев)
    - [Логирование и диагностика](#логирование-и-диагностика)
  - [Рекомендации](#рекомендации)

## Преимущества

- **Информативность**: Исключения содержат больше данных, что упрощает диагностику проблем.
- **Гибкость**: Поддержка дополнительных данных через свойство `ErrorData`.
- **Автоматическая** трассировка: Атрибуты `[CallerFilePath]`, `[CallerMemberName]` и `[CallerLineNumber]` автоматически добавляют информацию о месте возникновения ошибки.
- **Сериализация**: Поддержка сериализации через конструктор `SerializationInfo`.

## Когда использовать модуль?

Используйте модуль `E314.Exceptions`, если:

- Вы хотите добавить больше контекста к ошибкам (например, уникальный код ошибки или дополнительные данные).
- Вам нужно автоматически отслеживать место возникновения ошибки (файл, метод, строка).
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
        throw new DetailedArgNullException(nameof(name));
    }
    // ...
}

public void SetHealth(int health)
{
    if (health < 0 || health > 100)
    {
        throw new DetailedArgOutOfRangeException(
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
        throw new DetailedInvalidOperationException(
            "Object must be initialized before use.",
            errorCode: "INIT_REQUIRED",
            errorData: new { IsInitialized = _isInitialized });
    }
    // ...
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
        throw new DetailedArgNullException(
            nameof(order),
            errorData: new { Context = "Order processing", Timestamp = DateTime.UtcNow });
    }

    if (!order.IsValid())
    {
        throw new DetailedInvalidOperationException(
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
- Если вам нужно автоматически включать место возникновения ошибки (файл, метод, строка).

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
- Автоматическое отслеживание места ошибки:
  - Используйте атрибуты [CallerFilePath], [CallerMemberName] и [CallerLineNumber], чтобы автоматически фиксировать место возникновения ошибки.
- Специализированные исключения:
  - Используйте классы `DetailedArgNullException`, `DetailedArgOutOfRangeException` и `DetailedInvalidOperationException` для типичных сценариев. Это делает код более читаемым и понятным.
- Логирование:
  - Всегда логируйте ошибки с использованием всех доступных данных (`Message`, `ErrorCode`, `ErrorData`, `FileName`, `MethodName`, `LineNumber`).
