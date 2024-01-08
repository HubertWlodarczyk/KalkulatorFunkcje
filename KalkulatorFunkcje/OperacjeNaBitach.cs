namespace KalkulatorFunkcje;

public class OperacjeNaBitach
{
    int And(int x, int y)
    {
        return x & y;
    }
    int Or(int x, int y)
    {
        return x | y;
    }
    int Xor(int x, int y)
    {
        return x ^ y;
    }
    int ShiftR(int x, int y)
    {
        return (x >> y) | (x << (Liczba.rozmiar - y));     }

    int ShiftL(int x, int y)
    {
        return (x << y) | (x >> (Liczba.rozmiar - y)); 
    }

    int Not(int x)
    {
        return ~x;
    }
}