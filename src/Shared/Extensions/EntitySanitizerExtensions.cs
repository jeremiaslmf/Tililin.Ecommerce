namespace Tililin.Shared.Extensions;

public static class EntitySanitizerExtensions
{
    public static void Sanitize<T>(this T entity, params string[] exceptProperties)
    {
        var props = typeof(T).GetProperties()
            .Where(p => p.PropertyType == typeof(string) && p.CanRead && p.CanWrite)
            .Where(p => exceptProperties == null || !exceptProperties.Contains(p.Name));

        foreach (var prop in props)
        {
            var value = (string)prop.GetValue(entity);
            if (!string.IsNullOrWhiteSpace(value))
            {
                prop.SetValue(entity, value.Trim());
            }
        }
    }
}