﻿using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

[TestFixture]
public class HeroTests
{
    [Test]
    public void CheckIfHeroGainsXPPointsAfterAttack()
    {
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget.Setup(p => p.Health).Returns(0);
        fakeTarget.Setup(p => p.GiveExperience()).Returns(20);
        fakeTarget.Setup(p => p.IsDead()).Returns(true);
        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        Hero hero = new Hero("Pesho", fakeWeapon.Object);

        hero.Attack(fakeTarget.Object);

        Assert.That(hero.Experience, Is.EqualTo(20));

    }

}