using System;
using System.Runtime.Serialization;
using System.Text;

namespace E314.Exceptions
{

/// <summary>
/// An exception that contains detailed information about an error.
/// </summary>
[Serializable]
public class DetailedException : Exception
{
	/// <summary>
	/// A unique error code for identifying the type of problem.
	/// </summary>
	public string ErrorCode { get; }

	/// <summary>
	/// Additional data related to the error.
	/// </summary>
	public object ErrorData { get; }

	/// <summary>
	/// Initializes a new instance of the <see cref="DetailedException"/> class.
	/// </summary>
	/// <param name="message">The error message.</param>
	/// <param name="errorCode">The error code.</param>
	/// <param name="errorData">Additional data related to the error (optional).</param>
	public DetailedException(
		string message,
		string errorCode = null,
		object errorData = null)
		: base(message)
	{
		ErrorCode = errorCode;
		ErrorData = errorData;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="DetailedException"/> class with an inner exception.
	/// </summary>
	/// <param name="message">The error message.</param>
	/// <param name="innerException">The inner exception.</param>
	/// <param name="errorCode">The error code.</param>
	/// <param name="errorData">Additional data related to the error (optional).</param>
	public DetailedException(
		string message,
		Exception innerException,
		string errorCode = null,
		object errorData = null)
		: base(message, innerException)
	{
		ErrorCode = errorCode;
		ErrorData = errorData;
	}

	/// <summary>
	/// Gets the data object for serialization.
	/// </summary>
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(nameof(ErrorCode), ErrorCode);
		info.AddValue(nameof(ErrorData), ErrorData);
	}

	/// <summary>
	/// Returns a string representation of the exception, including all details.
	/// </summary>
	public override string ToString()
	{
		return new StringBuilder($"DetailedException: {Message}")
			.AppendLine($"\nError Code: {ErrorCode ?? "N/A"}")
			.AppendLine($"\nError Data: {ErrorData ?? "N/A"}")
			.AppendLine($"\nStack Trace: {StackTrace ?? "N/A"}")
			.ToString();
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="DetailedException"/> class with serialized data.
	/// </summary>
	/// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
	/// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
	protected DetailedException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		ErrorCode = info.GetString(nameof(ErrorCode));
		ErrorData = info.GetValue(nameof(ErrorData), typeof(object));
	}
}

}