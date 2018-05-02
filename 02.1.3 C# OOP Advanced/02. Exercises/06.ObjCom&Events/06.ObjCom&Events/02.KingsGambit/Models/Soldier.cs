using _02.KingsGambit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02.KingsGambit.Models
{
    public abstract class Soldier : IPerson
    {
        public Soldier(string name, IWriter writer)
        {
            this.Name = name;
            this.Writer = writer;
        }

        public string Name { get; private set; }

        protected IWriter Writer { get; private set; }

        public abstract void KingUnderAttack(object sender, EventArgs e);
    }
}
