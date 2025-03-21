using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace E314.Exceptions
{

/// <summary>
/// Represents an exception that provides detailed information about an error related to the use of an object after it has been released.
/// This class extends <see cref="DetailedException"/> to include parameter-specific details.
/// </summary>
[Serializable]
public class ObjDisposedException : DetailedException
{
	/// <summary>
	/// Initializes a new instance of the <see cref="ObjDisposedException"/> class with a specified parameter name, error message, error code, and additional error data.
	/// </summary>
	/// <param name="message">The error message that explains the reason for the exception. Default is "The object has been disposed and cannot be used.".</param>
	/// <param name="errorCode">A unique error code associated with the exception. Default is "OBJ_DISPOSED".</param>
	/// <param name="errorData">Additional data related to the error. Default is null.</param>
	public ObjDisposedException(
		string message = "The object has been disposed and cannot be used.",
		string errorCode = "OBJ_DISPOSED",
		object errorData = null)
		: base(
			message,
			errorCode,
			errorData)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="ArgException"/> class with serialized data.
	/// </summary>
	/// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
	/// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
	protected ObjDisposedException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}

}