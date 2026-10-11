using System;
using System.Collections.Generic;
namespace Logger.Tests;

[TestClass]
public class BaseLoggerMixinsTests
{
    [TestMethod]
    public void Error_WithNullLogger_ThrowsException()
    {
        Assert.ThrowsExactly<ArgumentNullException>(() =>
            BaseLoggerMixins.Error(null!, ""));
    }

    [TestMethod]
    public void Error_WithData_LogsMessage()
    {
        // Arrange
        var logger = new TestLogger(nameof(BaseLoggerMixinsTests));

        // Act
        logger.Error("Message 42");

        // Assert
        Assert.ContainsSingle(logger.LoggedMessages);
        Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
        Assert.AreEqual("Message 42", logger.LoggedMessages[0].Message);
    }

}
