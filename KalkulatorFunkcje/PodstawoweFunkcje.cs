namespace KalkulatorFunkcje;

public static class PodstawoweFunkcje
{
    public static long Dodawanie(long x, long y)
    {
        return x + y;
    }
    public static long Odejmowanie(long x, long y)
    {
        return x - y;
    }
    public static long Mnozenie(long x, long y)
    {
        return x * y;
    }
    public static long Dzielenie(long x, long y)
    {
        if (y == 0) throw new Exception("Nie można dzielić przez zero");
        return x / y;
    }
    public static long DzielenieModulo(long x, long y)
    {
        if (y == 0) throw new Exception("Nie można dzielić przez zero");
        return x % y;
    }
}