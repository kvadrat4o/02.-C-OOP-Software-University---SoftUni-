using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IWriter
{
    void WriteLine(string message);

    void WriteLine(string format, params string[] args);
}
