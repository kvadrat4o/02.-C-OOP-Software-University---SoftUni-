using System;
using System.Collections.Generic;
using System.Text;

namespace _03.DepInv.Contracts
{
    public interface IStrategy
    {
        int Calculate(int firstOperand, int secondOperand);
    }
}
