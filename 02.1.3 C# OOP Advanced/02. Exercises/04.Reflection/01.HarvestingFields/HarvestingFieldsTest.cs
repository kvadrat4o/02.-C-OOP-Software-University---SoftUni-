namespace _01HarestingFields
{
    using System;
    using System.Text;
    using System.Reflection;
    using System.Linq;

    class HarvestingFieldsTest
    {
        static void Main(string[] args)
        {
            var input = "";
            string result = "";
            StringBuilder sb = new StringBuilder();
            var typeOfHarvester = typeof(HarvestingFields);
            FieldInfo[] fields = typeOfHarvester.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                switch (input)
                {
                    case "private":
                        result = GetAllFields(fields.Where(f => f.IsPrivate).ToArray(),sb);
                        break;
                    case "public":
                        result = GetAllFields(fields.Where(f => f.IsPublic).ToArray(), sb);
                        break;
                    case "protected":
                        result = GetAllFields(fields.Where(f => f.IsFamily).ToArray(), sb);
                        break;
                    case "all":
                        result = GetAllFields(fields, sb);
                        break;
                    default:
                        break;
                }

            }
            Console.WriteLine(result);
        }

        private static string GetAllFields(FieldInfo[] fields, StringBuilder sb)
        {
            foreach (var field in fields)
            {
                var accessModifier = field.Attributes.ToString().ToLower();
                if (accessModifier.Equals("family"))
                {
                    accessModifier = "protected";
                }
                sb.AppendLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
