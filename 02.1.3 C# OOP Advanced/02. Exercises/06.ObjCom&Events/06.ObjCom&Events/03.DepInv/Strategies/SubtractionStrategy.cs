using _03.DepInv.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.DepInv.Strategies
{
    public class SubtractionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
