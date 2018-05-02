using System;
using System.Collections.Generic;
using System.Text;

public interface IMyCollection : IAddRemoveCollection
{
    int Used { get; }
}
