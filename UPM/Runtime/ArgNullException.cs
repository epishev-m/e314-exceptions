using System;
using System.Runtime.Serialization;

namespace E314.Exceptions
{

/// <summary>
/// Represents an exception that provides detailed information about a null argument error.
/// This class extends <see cref="DetailedException"/> to include parameter-specific details.
/// </summary>
[Serializable]
public class ArgNullException : DetailedException
{
	/// <summary>
	/// Initializes a new instance of the <see cref="ArgNullException"/> class with a specified parameter name, error message, error code, and additional error data.
	/// </summary>
	/// <param name="paramName">The name of the parameter that caused the exception.</param>
	/// <param name="message">The error message that explains the reason for the exception. Default is "Value cannot be null.".</param>
	/// <param name="errorCode">A unique error code associated with the exception. Default is "ARG_NULL".</param>
	/// <param name="errorData">Additional data related to the error. Default is null.</param>
	public ArgNullException(
		string paramName,
		string message = "Value cannot be null.",
		string errorCode = "ARG_NULL",
		object errorData = null)
		: base(
			$"{message} (Parameter '{paramName}')",
			errorCode,
			errorData)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="ArgNullException"/> class with serialized data.
	/// </summary>
	/// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
	/// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
	protected ArgNullException(SerializationInfo info, StreamingContext context) 
		: base(info, context)
	{
	}
}

}