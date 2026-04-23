namespace CommonService.Extensions;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        var name = value.ToString();
        var member = value.GetType().GetField(name);
        if (member?.GetCustomAttribute<DescriptionAttribute>() is { } attribute)
        {
            return attribute.Description;
        }

        return name;
    }
}
