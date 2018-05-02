using _02.KingsGambit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02.KingsGambit.Models
{
    public class King : IPerson
    {
        public event EventHandler UnderAttack;

        private IWriter writer;

        public King(string name, IWriter writer)
        {
            this.Name = name;
            this.writer = writer;
        }

        public string Name { get; private set; }

        public void OnUnderAttack()
        {
            this.writer.WriteLine($"King {this.Name} is under attack!");
            this.UnderAttack?.Invoke(this, new EventArgs());
        }
    }
}
