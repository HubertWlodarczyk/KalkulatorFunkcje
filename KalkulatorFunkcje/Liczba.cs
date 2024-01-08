namespace KalkulatorFunkcje;

public static class Liczba
{
    public static int rozmiar=8;
    public static int format=10;
    public static int wartosc=0;

    static int ToInt(String liczba)
    { 
        return Convert.ToInt32(liczba, format);
    }

    static String ToString(int liczba)
    {
        return Convert.ToString(liczba, format).PadLeft(rozmiar, '0');
    }
}