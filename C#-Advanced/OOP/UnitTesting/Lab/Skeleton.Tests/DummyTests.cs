using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;
    private Axe axe;

    [SetUp]
    public void SetUp()
    {
        this.dummy = new Dummy(50, 50);
        this.axe = new Axe(10, 10);
    }

    [Test]
    public void TestIfConstructorWorksCorrectly()
    {
        int expectedHealth = 50;

        Assert.AreEqual(this.dummy.Health, expectedHealth);
    }

    [Test]
    public void IsDeadShouldWorkCorrectly()
    {
        int attackPoints = 50;

        this.dummy.TakeAttack(attackPoints);

        Assert.IsTrue(this.dummy.IsDead());
    }

    [Test]
    public void TakeAttackShouldDecreaseHealth()
    {
        int attackPoints = 10;
        int expectedHealthAfterAttack = 40;

        this.dummy.TakeAttack(attackPoints);

        Assert.AreEqual(this.dummy.Health, expectedHealthAfterAttack);
    }

    [Test]
    public void TakeAttackShouldThrowExceptionIfDummyIsDead()
    {
        int attackPoints = 50;
        dummy.TakeAttack(attackPoints);

        Assert.Throws<InvalidOperationException>(() =>
        {
            this.dummy.TakeAttack(attackPoints);

        }, "Dummy is dead.");

    }

    [Test]
    public void GiveExperienceShouldReturnTheRightAmount()
    {
        int expectedExp = 50;
        int attackPoints = 50;
        this.dummy.TakeAttack(attackPoints);

        int actuealExp = this.dummy.GiveExperience();

        Assert.AreEqual(expectedExp, actuealExp);
        
    }

    [Test]
    public void GiveExperienceShouldThrowExceptionIfDummyIsNotDead()
    {
        Assert.That(() => 
        {
            this.dummy.GiveExperience();

        }, Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));

    }
}
