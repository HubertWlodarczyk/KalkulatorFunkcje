namespace KalkulatorFunkcje;

public static class Pamiec
{
    public static int pamiec = 0;

    static void Dodaj(int x)
    {
        pamiec += x;
    }
    static void Odejmij(int x)
    {
        pamiec -= x;
    }
    static int Zwroc(int x)
    {
        return pamiec;
    }
}