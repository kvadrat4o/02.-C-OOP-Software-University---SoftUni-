using System;
using System.Collections.Generic;
using System.Text;

public interface IFactory<T>
{
    T CreateInstance<T>(params string[] data);
}