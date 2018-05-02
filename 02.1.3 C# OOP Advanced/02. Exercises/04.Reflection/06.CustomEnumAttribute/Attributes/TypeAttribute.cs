using System;
using System.Collections.Generic;
using System.Text;

[AttributeUsage(AttributeTargets.Enum)]
public class TypeAttribute : Attribute
{
    public string Type { get; set; }

    public string Description { get; set; }

    public string Category { get; set; }

    public TypeAttribute(string type, string description, string category)
    {
        this.Type = type;
        this.Description = description;
        this.Category = category;
    }

    public override string ToString()
    {
        return $"Type = {this.Type}, Description = {this.Description}";
    }
}
