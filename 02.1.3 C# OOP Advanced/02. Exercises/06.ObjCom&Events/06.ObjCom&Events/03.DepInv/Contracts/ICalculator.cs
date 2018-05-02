using System;
using System.Collections.Generic;
using System.Text;

namespace _03.DepInv.Contracts
{
    public interface ICalculator
    {
        void ChangeStrategy(IStrategy strategy);

        int PerformCalculation(int firstOperand, int secondOperand);
    }
}
