using System;
using System.Collections.Generic;
using System.Text;

public interface ICommando
{
    HashSet<Mission> Missions { get; }
}
