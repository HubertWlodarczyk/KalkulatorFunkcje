namespace KalkulatorFunkcje;

public static class Pamiec
{
    public static int pamiec = 0;

    public static void Dodaj(int x)
    {
        pamiec += x;
    } 
    public static void Odejmij(int x)
    {
        pamiec -= x;
    }

    public static int Zwroc()
    {
        return pamiec;
    }

    public static void Wyczysc()
    {
        pamiec = 0;
    }
}