using NUnit.Framework;


namespace E314.Exceptions.Tests
{

[TestFixture]
internal sealed class ArgNullExceptionTests
{
	private const string TestParamName = "testParam";
	private const string TestMessage = "Value cannot be null.";
	private const string TestErrorCode = "ARG_NULL";
	private const string TestFileName = "TestFile.cs";
	private const string TestMethodName = "TestMethod";
	private const int TestLineNumber = 42;
	private readonly object _testErrorData = new { Key = "Value" };

	[Test]
	public void Constructor_WithAllParameters_SetsPropertiesCorrectly()
	{
		// Arrange & Act
		var exception = new ArgNullException(
			TestParamName,
			TestMessage,
			TestErrorCode,
			_testErrorData,
			TestFileName,
			TestMethodName,
			TestLineNumber);

		// Assert
		Assert.That(exception.Message, Does.Contain(TestMessage).And.Contain(TestParamName));
		Assert.That(exception.ErrorCode, Is.EqualTo(TestErrorCode));
		Assert.That(exception.ErrorData, Is.EqualTo(_testErrorData));
		Assert.That(exception.FileName, Is.EqualTo(TestFileName));
		Assert.That(exception.MethodName, Is.EqualTo(TestMethodName));
		Assert.That(exception.LineNumber, Is.EqualTo(TestLineNumber));
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
		Assert.That(exception.FileName, Is.Not.Null.And.Not.Empty);
		Assert.That(exception.MethodName, Is.Not.Null.And.Not.Empty);
		Assert.That(exception.LineNumber, Is.GreaterThan(0));
	}

	[Test]
	public void ToString_IncludesAllDetails()
	{
		// Arrange
		var exception = new ArgNullException(
			TestParamName,
			TestMessage,
			TestErrorCode,
			_testErrorData,
			TestFileName,
			TestMethodName,
			TestLineNumber);

		// Act
		var toStringResult = exception.ToString();

		// Assert
		Assert.That(toStringResult, Does.Contain(TestMessage));
		Assert.That(toStringResult, Does.Contain(TestErrorCode));
		Assert.That(toStringResult, Does.Contain(_testErrorData.ToString()));
		Assert.That(toStringResult, Does.Contain(TestFileName));
		Assert.That(toStringResult, Does.Contain(TestMethodName));
		Assert.That(toStringResult, Does.Contain(TestLineNumber.ToString()));
	}
}

}