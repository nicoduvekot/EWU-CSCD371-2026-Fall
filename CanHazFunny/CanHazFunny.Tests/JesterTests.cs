using System;
using Moq;
using Xunit;

namespace CanHazFunny.Tests;

// Core 6: Unit test the Jester class. Code coverage should be above 90%.
public class JesterTests
{
    private const string fakeJoke = "Testing found this joke funny, production never finds it all";

    private readonly Mock<IJokeService> _mockJokeService = new();
    private readonly Mock<IOutputService> _mockOutputService = new();

    [Fact]
    public void TellJoke_UsesJokeService_WritesToOutputService()
    {
        // arrange
        // setup mockJokeService to return the fakeJoke
        _mockJokeService.Setup(service => service.GetJoke()).Returns(fakeJoke);
        
        Jester jester = new(_mockJokeService.Object, _mockOutputService.Object);
        
        // act
        jester.TellJoke();
        
        // assert
        _mockOutputService.Verify(service => service.Output(fakeJoke), Times.Once);
    }

    [Theory]
    [InlineData(false, true, "jokeService")]
    [InlineData(true, false, "outputService")]
    public void Constructor_Throws(bool useValidJokeService, bool useValidOutputService, string expected)
    {
        // arrange
        IJokeService? jokeService = useValidJokeService ?
                _mockJokeService.Object
                : null;
        
        IOutputService? outputService = useValidOutputService ?
                _mockOutputService.Object
                : null;
        
        // act
        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => 
            new Jester(jokeService!, outputService!));
        
        // assert
        Assert.Contains(expected, ex.Message);
    }

    [Theory]
    [InlineData("This contains Chuck Norris", true)]
    [InlineData("Joke", false)]
    public void ContainsChuckNorris_GivenJoke_ReturnsDetection(string joke, bool shouldSkip)
    {
        // arrange
        JokeService service = new();
        
        // act and assert
        Assert.Equal(shouldSkip, service.ContainsChuckNorris(joke));
    }
}
