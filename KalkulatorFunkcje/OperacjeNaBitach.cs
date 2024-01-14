using System.Diagnostics;

namespace KalkulatorFunkcje;

static public class OperacjeNaBitach
{
    static public long And(long x, long y)
    {
        return x & y;
    }
    static public long Or(long x, long y)
    {
        return x | y;
    }
    static public long Xor(long x, long y)
    {
        return x ^ y;
    }
    static public long RotateR(long x, int y)
    {
        long a = x >> y;
        long b = (x << (Liczba.rozmiar - y));
        long c = (long)Math.Pow(2, Liczba.rozmiar);
        return (a | b)%c;     
    }
    static public long RotateL(long x, int y)
    {
        long a = x << y;
        long b = (x >> (Liczba.rozmiar - y));
        long c = (int)Math.Pow(2, Liczba.rozmiar);
        return (a | b)%c;     
    }
    static public long ShiftR(long x, int y)
    {
        y = y % Liczba.rozmiar;
        long a = x >> y;
        long c = (long)Math.Pow(2, Liczba.rozmiar);
        return a%c;     
    }
    static public long ShiftL(long x, int y)
    {
        y = y % Liczba.rozmiar;
        long a = x << y;
        long c = (long)Math.Pow(2, Liczba.rozmiar);
        return a%c;     
    }
    
    static public long Not(long x)
    {
        return ~x;
    }
}