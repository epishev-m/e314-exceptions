using System;
using System.Runtime.Serialization;

namespace E314.Exceptions
{
/// <summary>
/// Represents an exception that provides detailed information about an invalid operation.
/// This class extends <see cref="DetailedException"/> to include context-specific details.
/// </summary>
[Serializable]
public class InvOpException : DetailedException
{
	/// <summary>
	/// Initializes a new instance of the <see cref="InvOpException"/> class with a specified error message, error code, and additional error data.
	/// </summary>
	/// <param name="message">The error message that explains the reason for the exception. Default is "Operation is not valid due to the current state of the object.".</param>
	/// <param name="errorCode">A unique error code associated with the exception. Default is "INVALID_OPERATION".</param>
	/// <param name="errorData">Additional data related to the error. Default is null.</param>
	public InvOpException(
		string message = "Operation is not valid due to the current state of the object.",
		string errorCode = "INVALID_OPERATION",
		object errorData = null)
		: base(
			message,
			errorCode,
			errorData)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="InvOpException"/> class with serialized data.
	/// </summary>
	/// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
	/// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
	protected InvOpException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}

}