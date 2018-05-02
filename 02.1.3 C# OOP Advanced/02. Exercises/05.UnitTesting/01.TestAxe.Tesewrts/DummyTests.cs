using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAxe.Tests
{
    [TestFixture]
    public class DummyTests
    {
        public Dummy dummy { get; set; }

        public Axe axe { get; set; }


        public const int DefaultDummyHealth = 10;
        public const int DefaultDummyXP = 10;
        public const int MinWeaponDurability = 10;
        public const int MinWeaponAttack = 1;

        [SetUp]
        public void CreateInstances()
        {
            this.axe = new Axe(MinWeaponAttack, MinWeaponDurability);
            this.dummy = new Dummy(DefaultDummyHealth, DefaultDummyXP);
        }

        [Test]
        public void DummyLoosesPointsAfterAttack()
        {
            //Assign


            //Act
            this.axe.Attack(this.dummy);

            //Assert
            Assert.That(this.dummy.Health, Is.EqualTo(9), "Dummy's health is not going down after attack");

        }

        [Test]
        public void CheckIfDeadDummyThrowsExceptionWhenAttacked()
        {
            //Assign
            this.dummy = new Dummy(0,20);


            //Act

            //Assert

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Dead dummy cannot be attacked");

        }

        [Test]
        public void CheckIfDeadDummyGivesXP()
        {
            //Assign
            Hero hero = new Hero("KuraMiYanko",new Axe(10,10));
            this.dummy = new Dummy(0, DefaultDummyXP);

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => hero.Attack(dummy), "Dead dummy should not give XP points to the hero");

        }

        [Test]
        public void CheckIfAliveDummyGivesXP()
        {
            //Assign
            Hero hero = new Hero("KuraMiYanko",new Axe(10,10));

            //Act
            hero.Attack(this.dummy);

            //Assert
            Assert.AreEqual(hero.Experience, DefaultDummyXP, "Dead dummy should not give XP points to the hero");
        }
    }
}
