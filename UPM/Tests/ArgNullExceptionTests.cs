using NUnit.Framework;


namespace E314.Exceptions.Tests
{

[TestFixture]
internal sealed class ArgNullExceptionTests
{
	private const string TestParamName = "testParam";
	private const string TestMessage = "Test error message.";
	private const string TestErrorCode = "TEST_ERROR_CODE";
	private readonly object _testErrorData = new { Key = "Value" };

	[Test]
	public void Constructor_WithAllParameters_SetsPropertiesCorrectly()
	{
		// Arrange & Act
		var exception = new ArgNullException(
			TestParamName,
			TestMessage,
			TestErrorCode,
			_testErrorData);

		// Assert
		Assert.That(exception.Message, Does.Contain(TestMessage).And.Contain(TestParamName));
		Assert.That(exception.ErrorCode, Is.EqualTo(TestErrorCode));
		Assert.That(exception.ErrorData, Is.EqualTo(_testErrorData));
	}

	[Test]
	public void Constructor_WithDefaultValues_SetsPropertiesCorrectly()
	{
		// Arrange & Act
		var exception = new ArgNullException(TestParamName);

		// Assert
		Assert.That(exception.Message,
			Does.Contain("Value cannot be null.").And.Contain(TestParamName));
		Assert.That(exception.ErrorCode, Is.EqualTo("ARG_NULL"));
		Assert.That(exception.ErrorData, Is.Null);
	}

	[Test]
	public void ToString_IncludesAllDetails()
	{
		// Arrange
		var exception = new ArgNullException(
			TestParamName,
			TestMessage,
			TestErrorCode,
			_testErrorData);

		// Act
		var toStringResult = exception.ToString();

		// Assert
		Assert.That(toStringResult, Does.Contain(TestMessage));
		Assert.That(toStringResult, Does.Contain(TestErrorCode));
		Assert.That(toStringResult, Does.Contain(_testErrorData.ToString()));
	}
}

}