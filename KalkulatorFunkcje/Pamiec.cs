namespace KalkulatorFunkcje;

public static class Pamiec
{
    public static long pamiec = 0;

    public static void Dodaj(long x)
    {
        pamiec += x;
    } 
    public static void Odejmij(long x)
    {
        pamiec -= x;
    }

    public static long Zwroc()
    {
        return pamiec;
    }

    public static void Wyczysc()
    {
        pamiec = 0;
    }
}