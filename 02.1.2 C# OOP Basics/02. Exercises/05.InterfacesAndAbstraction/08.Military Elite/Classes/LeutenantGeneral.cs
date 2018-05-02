using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public HashSet<Private> Privates { get; set; }

    
    public LeutenantGeneral(string firstName, string lastName, string id, double salary) : base(firstName,lastName,id,salary)
    {
        Privates = new HashSet<Private>();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString() + "\nPrivates: ");
        foreach (var priv in this.Privates)
        {
            sb.AppendLine("  " + priv.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}
