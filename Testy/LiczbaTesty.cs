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
    public void KonwertujHeksagonalna1()
    {
        Liczba.SetHexagonal();
        Assert.That(16,Is.EqualTo(Liczba.ToInt("10")));
    }
    [Test]
    public void KonwertujHeksagonalna2()
    {
        Liczba.SetHexagonal();
        Assert.That(0,Is.EqualTo(Liczba.ToInt("fadadfg")));
    }
    [Test]
    public void KonwertujHeksagonalna3()
    {
        Liczba.SetHexagonal();
        Liczba.SetBinary();
        Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo("Niepoprawny format lub ciąg znaków zawiera litery."), 
            () => Is.EqualTo(Liczba.ToInt("-e0")));
    }
    [Test]
    public void KonwertujHeksagonalna4()
    {
        Liczba.SetHexagonal();
        Assert.That(0,Is.EqualTo(Liczba.ToInt("10rea")));
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
    public void KonwertujBinarna2()
    {
        Liczba.SetBinary();
        Liczba.SetBinary();
        Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo("Minus dostępny tylko w formacie dziesiętnym."), 
            () => Is.EqualTo(Liczba.ToInt("-10")));
    }
    [Test]
    public void KonwertujBinarna3()
    {
        Liczba.SetBinary();
        Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo("Niepoprawny format lub ciąg znaków zawiera litery."), 
            () => Is.EqualTo(Liczba.ToInt("-fadfadadfadfafd")));
    }
    [Test]
    public void KonwertujBinarna4()
    {
        Liczba.SetBinary();
        Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo("Minus dostępny tylko w formacie dziesiętnym."), 
            () => Is.EqualTo(Liczba.ToInt("-0")));
    }
    [Test]
    public void ZwrocStringDziesietnyDword()
    {
        Liczba.SetDecimal();
        Liczba.SetDword();
        Assert.That("10",Is.EqualTo(Liczba.ToString(10,false)));
    }
    [Test]
    public void ZwrocStringDziesietnyDword1()
    {
        Liczba.SetDecimal();
        Liczba.SetDword();
        Assert.That("0",Is.EqualTo(Liczba.ToString(-0,false)));
    }
    [Test]
    public void ZwrocStringDziesietnyQword()
    {
        Liczba.SetDecimal();
        Liczba.SetQword();
        Assert.That("654656456454567856",Is.EqualTo(Liczba.ToString(654656456454567856,false)));
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
    public void MinusPrzyBinarnym()
    {
        Liczba.SetBinary();
        Liczba.SetQword();
        Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo("Minus dostępny tylko w formacie dziesiętnym."), 
            () => Liczba.ToInt("-01010101"));
    }
    [Test]
    public void ZwrocStringSzesnastkowyWord()
    {
        Liczba.SetHexagonal();
        Liczba.SetWord();
        Assert.That("11",Is.EqualTo(Liczba.ToString(17,false)));
    }
}