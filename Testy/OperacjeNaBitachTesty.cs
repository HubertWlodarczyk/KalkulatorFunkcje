using KalkulatorFunkcje;

namespace Testy;

[TestFixture]
public class OperacjeNaBitachTesty
{
    [Test]
    public void And1()
    {
        Assert.That(OperacjeNaBitach.And(4,4),Is.EqualTo(4));
    }
    [Test]
    public void And2()
    {
        Assert.That(OperacjeNaBitach.And(4,0),Is.EqualTo(0));
    }
    [Test]
    public void And3()
    {
        Assert.That(OperacjeNaBitach.And(1,5),Is.EqualTo(1));
    }
    [Test]
    public void Or1()
    {
        Assert.That(OperacjeNaBitach.Or(4,4),Is.EqualTo(4));
    }
    [Test]
    public void Or2()
    {
        Assert.That(OperacjeNaBitach.Or(4,1),Is.EqualTo(5));
    }
    [Test]
    public void Or3()
    {
        Assert.That(OperacjeNaBitach.Or(4,-1),Is.EqualTo(-1));
    }
    [Test]
    public void Xor1()
    {
        Assert.That(OperacjeNaBitach.Xor(4,4),Is.EqualTo(0));
    }
    [Test]
    public void Xor2()
    {
        Assert.That(OperacjeNaBitach.Xor(4,1),Is.EqualTo(5));
    }
    [Test]
    public void Xor3()
    {
        Assert.That(OperacjeNaBitach.Xor(4,-1),Is.EqualTo(-5));
    }

    [Test]
    public void RotateL1()
    {
        Liczba.SetByte();
        Liczba.SetBinary();
        Assert.That(OperacjeNaBitach.RotateL(2,4),Is.EqualTo(32));
    }
    
    [Test]
    public void RotateL2()
    {
        Liczba.SetQword();
        Liczba.SetBinary();
        Assert.That(OperacjeNaBitach.RotateL(2,64),Is.EqualTo(2));
    }
    [Test]
    public void RotateR1()
    {
        Liczba.SetByte();
        Liczba.SetBinary();
        Assert.That(OperacjeNaBitach.RotateR(1,0),Is.EqualTo(1));
    }
    
    [Test]
    public void RotateR2()
    {
        Liczba.SetQword();
        Liczba.SetBinary();
        Assert.That(OperacjeNaBitach.RotateR(2,64),Is.EqualTo(2));
    }
    [Test]
    public void RotateR3()
    {
        Liczba.SetQword();
        Liczba.SetBinary();
        Assert.That(OperacjeNaBitach.RotateR(2,1),Is.EqualTo(1));
    }
    [Test]
    public void ShiftL1()
    {
        Liczba.SetByte();
        Liczba.SetBinary();
        Assert.That(OperacjeNaBitach.ShiftL(2,4),Is.EqualTo(32));
    }

    [Test]
    public void ShiftL2()
    {
        Liczba.SetQword();
        Liczba.SetBinary();
        Assert.That(OperacjeNaBitach.ShiftL(2, 64), Is.EqualTo(2));

    }
    [Test]
    public void ShiftR1()
    {
        Liczba.SetByte();
        Liczba.SetBinary();
        Assert.That(OperacjeNaBitach.ShiftR(32,4),Is.EqualTo(2));
    }
    
    [Test]
    public void ShiftR2()
    {
        Liczba.SetQword();
        Liczba.SetBinary();
        Assert.That(OperacjeNaBitach.ShiftR(2,64),Is.EqualTo(2));
    }

    [Test]
    public void Not1()
    {
        Liczba.SetByte();
        Assert.That(OperacjeNaBitach.Not(2),Is.EqualTo(-3));
    }
    [Test]
    public void Not2()
    {
        Liczba.SetByte();
        Assert.That(OperacjeNaBitach.Not(-2),Is.EqualTo(1));
    }
}