namespace KalkulatorFunkcje;

public class PodstawoweFunkcjeKalkulatora
{
    int Dodawanie(int x, int y)
    {
        return x + y;
    }
    int Odejmowanie(int x, int y)
    {
        return x - y;
    }
    int Mnozenie(int x, int y)
    {
        return x * y;
    }
    int Dzielenie(int x, int y)
    {
        return x / y;
    }
    int Pierwiastkowanie(int x)
    {
        return (int)Math.Sqrt(x);
    }
    int LiczenieOdwrotnosci(int x)
    {
        return 1/x;
    }
    int DzielenieModulo(int x, int y)
    {
        return x % y;
    }
}