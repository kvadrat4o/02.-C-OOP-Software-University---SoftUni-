using NUnit.Framework;
using System;



namespace TestAxe.Tests
{
    [TestFixture]
    public class AxeTests
    {
        public const int DefaultWeaponAttack = 10;
        public const int DefaultWeaponDurability = 10;
        public const int DefaultDummyHealth = 10;
        public const int DefaultDummyXP = 10;


        [Test]
        public void CheckIfWeaponLosesDurabilityAfterAttack()
        {

           
            //Assign
            Axe axe = new Axe(DefaultWeaponAttack, DefaultWeaponDurability);
            Dummy dummy = new Dummy(DefaultDummyHealth, DefaultDummyXP);

            //Act
            axe.Attack(dummy);

            //Assert

            Assert.That(axe.DurabilityPoints ,Is.EqualTo(9), "Axe's durability points don't change after the attack");
        }


        [Test]
        public void CheckAttackWithBrokenWeapon()
        {
            //Assign
            Axe axe = new Axe(15, -1);
            Dummy dummy = new Dummy(DefaultDummyHealth,DefaultDummyXP);

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy),"Axe is broken");
        }
    }
}
