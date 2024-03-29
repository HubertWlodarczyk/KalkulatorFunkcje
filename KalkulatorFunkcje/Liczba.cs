﻿namespace KalkulatorFunkcje;

public static class Liczba
{
    public static int rozmiar = 64;
    public static int format = 10;
    public static long firstValue;
    public static long wartosc = 0;

    public static void SetQword()
    {
        rozmiar = 64;
    }
    public static void SetDword()
    {
        rozmiar = 32;
    }
    public static void SetWord()
    {
        rozmiar = 16;
    }
    public static void SetByte()
    {
        rozmiar = 8;
    }

    public static void SetBinary()
    {
        format = 2;
    }
    public static void SetOctal()
    {
        format = 8;
    }
    public static void SetDecimal()
    {
        format = 10;
    }
    public static void SetHexagonal()
    {
        format = 16;
    }

    public static long ToInt(string liczba)
    {
        if (format != 16 && liczba.Any(char.IsLetter))
        {
            Console.WriteLine("Niepoprawny format lub ciąg znaków zawiera litery.");
            return 0;
        }

        try
        {
            return Convert.ToInt64(liczba, format);
        }
        catch (FormatException)
        {
            Console.WriteLine("Nie udało się przekonwertować ciągu na liczbę w danym formacie.");
            return 0;
        }
    }


    public static String ToString(long liczba,bool Padding)
    {
        var a = Convert.ToString(liczba, format);
        a = a.Substring(Math.Max(0, a.Length - rozmiar));        
        if(Padding) a=a.PadLeft(rozmiar, '0');
        return a;
    }

    public static String ToString(long liczba, int formatToConvert)
    {
        var a = Convert.ToString(liczba, formatToConvert);
        a = a.Substring(Math.Max(0, a.Length - rozmiar));
        return a;
    }
}