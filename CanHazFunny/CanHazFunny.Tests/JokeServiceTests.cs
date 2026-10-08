///summary
/// This class contains unit tests for the JokeService class, which is responsible for fetching jokes from an external API. The tests ensure that the service behaves correctly under various conditions, including successful responses, error handling, and edge cases.
///summary
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;              


namespace CanHazFunny.Tests;

public class JokeServiceTests
{
    

    //Test to ensure that GetJoke returns a joke when the API returns a valid response
    public void GetJoke_ShouldReturnJoke_WhenApiReturnsValidJoke(){}



    //Test to ensure that GetJoke throws an exception when the API returns an error response
    //Simulate or intentionally cause API to throw an error 
    public void GetJoke_ShouldThrowException_WhenApiReturnsErrorResponse(){}
}