using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace E314.Exceptions
{
/// <summary>
/// Represents an exception that provides detailed information about an invalid operation.
/// This class extends <see cref="DetailedException"/> to include context-specific details.
/// </summary>
[Serializable]
public class DetailedInvalidOperationException : DetailedException
{
	/// <summary>
	/// Initializes a new instance of the <see cref="DetailedInvalidOperationException"/> class with a specified error message, error code, and additional error data.
	/// </summary>
	/// <param name="message">The error message that explains the reason for the exception. Default is "Operation is not valid due to the current state of the object.".</param>
	/// <param name="errorCode">A unique error code associated with the exception. Default is "INVALID_OPERATION".</param>
	/// <param name="errorData">Additional data related to the error. Default is null.</param>
	/// <param name="fileName">The full path of the source file that contains the caller. Automatically populated by the runtime.</param>
	/// <param name="methodName">The name of the method or property that invoked the exception. Automatically populated by the runtime.</param>
	/// <param name="lineNumber">The line number in the source file at which the exception was thrown. Automatically populated by the runtime.</param>
	public DetailedInvalidOperationException(
		string message = "Operation is not valid due to the current state of the object.",
		string errorCode = "INVALID_OPERATION",
		object errorData = null,
		[CallerFilePath] string fileName = "",
		[CallerMemberName] string methodName = "",
		[CallerLineNumber] int lineNumber = 0)
		: base(
			message,
			errorCode,
			errorData,
			fileName,
			methodName,
			lineNumber)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="DetailedInvalidOperationException"/> class with serialized data.
	/// </summary>
	/// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
	/// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
	protected DetailedInvalidOperationException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}

}