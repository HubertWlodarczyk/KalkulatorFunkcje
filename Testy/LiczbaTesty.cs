using KalkulatorFunkcje;

namespace Testy;

[TestFixture]
public class LiczbaTesty
{
    [SetUp]
    public void UstawLiczba()
    {
        Liczba.rozmiar = 8;
        Liczba.format = 10;
        Liczba.wartosc = 0;
    }

    [Test]
    public void UstawQword()
    {
        Liczba.SetQword();
        Assert.That(Liczba.rozmiar,Is.EqualTo(64));
    }
    [Test]
    public void UstawDword()
    {
        Liczba.SetDword();
        Assert.That(Liczba.rozmiar,Is.EqualTo(32));
    }
    [Test]
    public void UstawWord()
    {
        Liczba.SetWord();
        Assert.That(Liczba.rozmiar,Is.EqualTo(16));
    }
    [Test]
    public void UstawByte()
    {
        Liczba.SetByte();
        Assert.That(Liczba.rozmiar,Is.EqualTo(8));
    }

    [Test]
    public void UstawBinarny()
    {
        Liczba.SetBinary();
        Assert.That(Liczba.format,Is.EqualTo(2));
    }
    [Test]
    public void UstawOktalny()
    {
        Liczba.SetOctal();
        Assert.That(Liczba.format,Is.EqualTo(8));
    }
    [Test]
    public void UstawHeksagonalny()
    {
        Liczba.SetHexagonal();
        Assert.That(Liczba.format,Is.EqualTo(16));
    }
    [Test]
    public void UstawDziesietny()
    {
        Liczba.SetDecimal();
        Assert.That(Liczba.format,Is.EqualTo(10));
    }

    [Test]
    public void KonwertujDecymalna()
    {
        Liczba.SetDecimal();
        Assert.That(10,Is.EqualTo(Liczba.ToInt("10")));
    }
    [Test]
    public void KonwertujHeksagonalna()
    {
        Liczba.SetHexagonal();
        Assert.That(16,Is.EqualTo(Liczba.ToInt("10")));
    }
    [Test]
    public void KonwertujOktalna()
    {
        Liczba.SetOctal();
        Assert.That(8,Is.EqualTo(Liczba.ToInt("10")));
    }
    [Test]
    public void KonwertujBinarna()
    {
        Liczba.SetBinary();
        Assert.That(2,Is.EqualTo(Liczba.ToInt("10")));
    }

    [Test]
    public void ZwrocStringDziesietnyDword()
    {
        Liczba.SetDecimal();
        Liczba.SetDword();
        Assert.That("10",Is.EqualTo(Liczba.ToString(10,false)));
    }
    [Test]
    public void ZwrocStringDziesietnyDwordUjemny()
    {
        Liczba.SetDecimal();
        Liczba.SetDword();
        Assert.That("-10",Is.EqualTo(Liczba.ToString(-10,false)));
    }
    [Test]
    public void ZwrocStringBinarnyQword()
    {
        Liczba.SetBinary();
        Liczba.SetQword();
        Assert.That("0000000000000000000000000000000000000000000000000000000000001010",Is.EqualTo(Liczba.ToString(10,true)));
    }
    [Test]
    public void ZwrocStringBinarnyWordUjemny()
    {
        Liczba.SetBinary();
        Liczba.SetByte();
        Assert.That(Liczba.ToString(-10,false),Is.EqualTo("11110110"));
    }
    [Test]
    public void ZwrocStringSzesnastkowyWord()
    {
        Liczba.SetHexagonal();
        Liczba.SetWord();
        Assert.That("11",Is.EqualTo(Liczba.ToString(17,false)));
    }
}