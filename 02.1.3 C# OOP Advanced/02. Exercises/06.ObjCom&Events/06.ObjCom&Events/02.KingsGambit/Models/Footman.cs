using _02.KingsGambit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02.KingsGambit.Models
{
    public class Footman : Soldier
    {
        public Footman(string name, IWriter writer) : base(name, writer)
        {
        }

        public override void KingUnderAttack(object sender, EventArgs e)
        {
            this.Writer.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
