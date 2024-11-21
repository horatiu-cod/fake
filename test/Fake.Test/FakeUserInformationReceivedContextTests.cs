
using FluentAssertions;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace Fake.Test;

public class FakeUserInformationReceivedContextTests
{
    [Fact]
    public void CreateFake_ShouldReturnUserInformationReceivedContextType()
    {
        //Arrange
        string clientId = "client";
        string authenticationType = "Basic";
        string[] constructorParameters = [clientId, authenticationType];

        //Act
        var expected = FakeUserInformationReceivedContext.CreateFake(constructorParameters);

        //Assert
        expected.Should().BeOfType<UserInformationReceivedContext>();
        expected.Should().BeAssignableTo<UserInformationReceivedContext>();
    }
    [Fact]
    public void CreateFake_ShouldReturnIsAuthenticated_WhenAuthenticationTypeIsBasic()
    {
        //Arrange
        string clientId = "client";
        string authenticationType = "Basic";
        string[] constructorParameters = [clientId, authenticationType];

        //Act
        var expected = FakeUserInformationReceivedContext.CreateFake(constructorParameters);

        //Assert
        expected.Principal?.Identity.Should().NotBeNull();
        expected.Principal?.Identity?.IsAuthenticated.Should().BeTrue();
    }
    [Fact]
    public void CreateFake_ShouldReturnIsAuthenticatedFalse_WhenAuthenticationTypeIsNotBasic()
    {
        //Arrange
        string clientId = "client";
        string authenticationType = string.Empty;
        string[] constructorParameters = [clientId, authenticationType];

        //Act
        var expected = FakeUserInformationReceivedContext.CreateFake(constructorParameters);

        //Assert
        expected.Principal?.Identity.Should().NotBeNull();
        expected.Principal?.Identity?.IsAuthenticated.Should().BeFalse();
    }
}
