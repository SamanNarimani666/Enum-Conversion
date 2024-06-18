using System.Reflection;

namespace Enum_Conversion.Converter;
public static class EnumConvertor
{

    public static Type GetEnumType(string enumName)
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .Where(assembly => !assembly.IsDynamic)
            .SelectMany(assembly => assembly.GetTypes())
            .FirstOrDefault(type => type.Name == enumName && type.IsEnum);
    }

    public static Dictionary<string, int> GetEnumValueNamePairs(string enumName)
    {
        Type enumType = GetEnumType(enumName);
        if (enumType == null)
            throw new ArgumentException($"Enum type '{enumName}' not found.");

        return GetEnumValueNamePairs(enumType);
    }

    private static Dictionary<string, int> GetEnumValueNamePairs(Type enumType, Func<string, string> keySelector = null)
    {
        if (keySelector == null)
        {
            keySelector = s => s.ToLower();
        }

        return Enum.GetValues(enumType)
            .Cast<Enum>()
            .ToDictionary(enumValue => keySelector(enumValue.ToString()), enumValue => Convert.ToInt32(enumValue));
    }
}

