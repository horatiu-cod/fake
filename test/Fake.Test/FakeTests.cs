using FluentAssertions;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace Fake.Test;

public class FakeTests
{
    [Fact]
    public void GetClassName_ShouldReturnNameOfGenericClass()
    {
        //Arrange
        var className = "UserInformationReceivedContext";

        //Act
        var expectedClassName = Fake<UserInformationReceivedContext>.GetClassName();

        //Assert
        expectedClassName.Should().Be(className);
    }
    [Fact]
    public void Map_ShouldReturnTypeOfMethodParameter()
    {
        //Arrange
        var parameter = FakeUserInformationReceivedContext.CreateFake([]);

        //Act
        var expected = Fake<UserInformationReceivedContext>.Map(parameter);

        //Assert
        expected.Should().NotBeNull();
        expected.Should().BeOfType<UserInformationReceivedContext>();
    }
    [Fact]
    public void Create_ShouldReturnTypeOfGenericClass()
    {
        //Arrange
        string clientId = "client";
        string authenticationType = "Basic";
        string[] constructorParameters = [clientId, authenticationType];

        //Act
        var expected = Fake<UserInformationReceivedContext>.Create(constructorParameters);

        //Assert
        expected.Should().BeOfType<UserInformationReceivedContext>();
        expected.Should().BeAssignableTo<UserInformationReceivedContext>();
    }
}
