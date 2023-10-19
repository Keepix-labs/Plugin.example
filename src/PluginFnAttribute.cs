[System.AttributeUsage(System.AttributeTargets.Method |
                       System.AttributeTargets.Struct,
                       AllowMultiple = true)  // Multiuse attribute.
]
public class PluginFnAttribute : System.Attribute
{
    string Key;

    public System.Type? InputType;

    public PluginFnAttribute(string key)
    {
        Key = key;
    }

    public string GetKey() => Key;
}