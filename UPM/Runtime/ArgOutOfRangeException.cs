using System;
using System.Runtime.Serialization;

namespace E314.Exceptions
{

/// <summary>
/// Represents an exception that provides detailed information about an argument being out of its valid range.
/// This class extends <see cref="DetailedException"/> to include parameter-specific details and the actual value that caused the exception.
/// </summary>
[Serializable]
public class ArgOutOfRangeException : DetailedException
{
	/// <summary>
	/// Initializes a new instance of the <see cref="ArgOutOfRangeException"/> class with a specified parameter name, actual value, error message, error code, and additional error data.
	/// </summary>
	/// <param name="paramName">The name of the parameter that caused the exception.</param>
	/// <param name="actualValue">The actual value of the parameter that was out of range.</param>
	/// <param name="message">The error message that explains the reason for the exception. Default is "Specified argument was out of the range of valid values.".</param>
	/// <param name="errorCode">A unique error code associated with the exception. Default is "ARG_OUT_OF_RANGE".</param>
	/// <param name="errorData">Additional data related to the error. Default is null.</param>
	public ArgOutOfRangeException(
		string paramName,
		object actualValue,
		string message = "Specified argument was out of the range of valid values.",
		string errorCode = "ARG_OUT_OF_RANGE",
		object errorData = null)
		: base(
			$"{message} (Parameter '{paramName}' with value '{actualValue}')",
			errorCode,
			errorData)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="ArgOutOfRangeException"/> class with serialized data.
	/// </summary>
	/// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
	/// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
	protected ArgOutOfRangeException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}

}