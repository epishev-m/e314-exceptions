using NUnit.Framework;

namespace E314.Exceptions.Tests
{

[TestFixture]
internal sealed class ArgOutOfRangeExceptionTests
{
	private const string TestParamName = "testParam";
	private const int TestActualValue = 150;
	private const string TestMessage = "Specified argument was out of the range of valid values.";
	private const string TestErrorCode = "ARG_OUT_OF_RANGE";
	private const string TestFileName = "TestFile.cs";
	private const string TestMethodName = "TestMethod";
	private const int TestLineNumber = 42;
	private readonly object _testErrorData = new { MinValue = 0, MaxValue = 100 };

	[Test]
	public void Constructor_WithAllParameters_SetsPropertiesCorrectly()
	{
		// Arrange & Act
		var exception = new ArgOutOfRangeException(
			TestParamName,
			TestActualValue,
			TestMessage,
			TestErrorCode,
			_testErrorData,
			TestFileName,
			TestMethodName,
			TestLineNumber);

		// Assert
		Assert.That(exception.Message,
			Does.Contain(TestMessage).And.Contain(TestParamName).And
				.Contain(TestActualValue.ToString()));
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
		var exception = new ArgOutOfRangeException(TestParamName, TestActualValue);

		// Assert
		Assert.That(exception.Message,
			Does.Contain("Specified argument was out of the range of valid values.").And
				.Contain(TestParamName).And.Contain(TestActualValue.ToString()));
		Assert.That(exception.ErrorCode, Is.EqualTo("ARG_OUT_OF_RANGE"));
		Assert.That(exception.ErrorData, Is.Null);
		Assert.That(exception.FileName, Is.Not.Null.And.Not.Empty);
		Assert.That(exception.MethodName, Is.Not.Null.And.Not.Empty);
		Assert.That(exception.LineNumber, Is.GreaterThan(0));
	}

	[Test]
	public void ToString_IncludesAllDetails()
	{
		// Arrange
		var exception = new ArgOutOfRangeException(
			TestParamName,
			TestActualValue,
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
		Assert.That(toStringResult, Does.Contain(TestActualValue.ToString()));
	}
}

}