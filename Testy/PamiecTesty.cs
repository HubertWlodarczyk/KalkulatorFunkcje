using KalkulatorFunkcje;

namespace Testy;

[TestFixture]
public class PamiecTesty
{
    [SetUp]
    public void UstawPamiecNaZero()
    {
        Pamiec.pamiec = 0;
    }
    [Test]
    public void WyczyscTest()
    {
        Pamiec.Dodaj(2);
        Pamiec.Wyczysc();
        Assert.That(Pamiec.Zwroc(),Is.EqualTo(0));
    }
    [Test]
    public void ZwrocTest()
    {
        Pamiec.Dodaj(2);
        Assert.That(Pamiec.Zwroc(),Is.EqualTo(2));
    }
    [Test]
    public void DodajZero()
    {
        Pamiec.Dodaj(0);
        Assert.That(Pamiec.pamiec,Is.EqualTo(0));
    }
    [Test]
    public void DodajDodatnia()
    {
        Pamiec.Dodaj(5);
        Assert.That(Pamiec.pamiec,Is.EqualTo(5));
    }
    [Test]
    public void DodajUjemna()
    {
        Pamiec.Dodaj(-5);
        Assert.That(Pamiec.pamiec, Is.EqualTo(-5));
    }
    [Test]
    public void OdejmijZero()
    {
        Pamiec.Odejmij(0);
        Assert.That(Pamiec.pamiec,Is.EqualTo(0));
    }
    [Test]
    public void OdejmijDodatnia()
    {
        Pamiec.Odejmij(5);
        Assert.That(Pamiec.pamiec,Is.EqualTo(-5));
    }
    [Test]
    public void OdejmijUjemna()
    {
        Pamiec.Odejmij(-5);
        Assert.That(Pamiec.pamiec,Is.EqualTo(5));
    }

}