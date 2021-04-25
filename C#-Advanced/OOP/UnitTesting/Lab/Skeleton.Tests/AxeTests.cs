using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        this.axe = new Axe(5, 5);
        this.dummy = new Dummy(30, 30);

    }

    [Test]
    public void TestIfConstructorWorksCorrectly()
    {
        int attackPoints = 5;
        int durabilityPoints = 5;

        Assert.AreEqual(this.axe.AttackPoints, attackPoints);
        Assert.AreEqual(this.axe.DurabilityPoints, durabilityPoints);
    }

    [Test]
    public void AttackShouldDecreaseDurabilityPointsByOne()
    {
        int expectedAxeDurability = 4;

        this.axe.Attack(dummy);

        Assert.AreEqual(this.axe.DurabilityPoints, expectedAxeDurability);
    }

    [Test]
    public void AttackWithBrokenWeaponShouldThrowException()
    {
        

        for (int i = 0; i < 5; i++)
        {
            this.axe.Attack(dummy);
        }

        Assert.Throws<InvalidOperationException>(() =>
        {
            this.axe.Attack(dummy);
        }, "Axe is broken.");
        
                
    }
}