using _03.DepInv.Contracts;
using _03.DepInv.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.DepInv.Models
{
    public class Calculator : ICalculator
    {
        private IStrategy calculationStrategy;

        public Calculator()
            : this(new AdditionStrategy())
        {
        }

        public Calculator(IStrategy strategy)
        {
            this.calculationStrategy = strategy;
        }

        public void ChangeStrategy(IStrategy strategy) => this.calculationStrategy = strategy;

        public int PerformCalculation(int firstOperand, int secondOperand) => this.calculationStrategy.Calculate(firstOperand, secondOperand);
    }
}
