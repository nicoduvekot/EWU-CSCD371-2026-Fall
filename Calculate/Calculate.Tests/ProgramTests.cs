namespace Calculate.Tests;

[TestClass]
public sealed class ProgramTests
{
    [TestMethod]
    public void WriteLine_WithProvidedDelegate_CapturesProvidedValue()
    {
        const string expectedValue = "Foo";
        
        // captures the value of the param passed to the delegate
        string? receivedValue = null;

        Program program = new()
        {
            WriteLine = value => receivedValue = value,
            ReadLine = () => string.Empty
        };
        
        program.WriteLine(expectedValue);
        
        Assert.AreEqual<string?>(expectedValue, receivedValue);
    }

    [TestMethod]
    public void ReadLine_WithProvidedDelegate_ReturnsProvidedValue()
    {
        const string expectedValue = "Foo";
        
        Program program = new()
        {
            WriteLine = _ => { },
            ReadLine = () => expectedValue
        };
        
        string? actualValue = program.ReadLine();
        
        Assert.AreEqual<string?>(expectedValue, actualValue);
    }
}