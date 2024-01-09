using System.ComponentModel;

namespace HealthDeclaration.Models
{
    public class MyEnum
    {
        public enum field_type : byte
        {
            Dropdown = 1,[Description("Input Text")] InputText, Checkbox, Radio
        }

        public static string GetDescriptionFromEnum(Enum value)
        {
            DescriptionAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }

}
