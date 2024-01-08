namespace KalkulatorFunkcje;

public static class PodstawoweFunkcje
{
    public static int Dodawanie(int x, int y)
    {
        return x + y;
    }
    public static int Odejmowanie(int x, int y)
    {
        return x - y;
    }
    public static int Mnozenie(int x, int y)
    {
        return x * y;
    }
    public static int Dzielenie(int x, int y)
    {
        if (y == 0) throw new Exception("Nie można dzielić przez zero");
        return x / y;
    }
    public static int DzielenieModulo(int x, int y)
    {
        if (y == 0) throw new Exception("Nie można dzielić przez zero");
        return x % y;
    }
}