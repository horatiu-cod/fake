namespace Fake;

public sealed class Fake<TClass>  where TClass : class
{
    private Fake() { }
    /// <summary>
    /// Create <see cref="UserInformationReceivedContext"/>
    /// </summary>
    /// <param name="constructorParameters"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static TClass Create( params string[] constructorParameters)
    {
        var name = GetClassName();
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(name));
        if(constructorParameters.Length ==0)
        {
            #warning "Add params"
        }
         
        TClass resp() => name switch
        {
            "UserInformationReceivedContext" => Map(FakeUserInformationReceivedContext.CreateFake(constructorParameters)),
            _ => throw new ArgumentNullException(name),
        };

        return resp();
    }

    internal static string GetClassName()
    {
        var name = typeof(TClass).Name;
        return name;
    }

    internal static TClass Map(object toMapp)
    {
        if (toMapp is TClass @class)
        {
            return @class;
        }
        var cls = (TClass)Convert.ChangeType(toMapp, typeof(TClass));
        return cls;
    }
}
