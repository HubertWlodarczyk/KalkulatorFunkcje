namespace KalkulatorFunkcje;

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

        if (liczba == String.Empty) return 0;
        try
        {
            return Convert.ToInt64(liczba, format);
        }
        catch (FormatException)
        {
            Console.WriteLine("Nie udało się przekonwertować ciągu na liczbę w danym formacie.");
            return 0;
        }
        catch (OverflowException)
        {
            return 0;
        }
    }


    public static String ToString(long liczba,bool Padding)
    {
        var bin = ToString(liczba, 2);
        var a =bin.Substring(Math.Max(0, bin.Length - rozmiar));        
        a = ConvertToString(Convert.ToInt64(a, 2), format);
        if(Padding) a=a.PadLeft(rozmiar, '0');
        return a;
    }

    public static String ToString(long liczba, int formatToConvert,bool Padding=false)
    {
        var a = ConvertToString(liczba, formatToConvert);
        a = a.Substring(Math.Max(0, a.Length - rozmiar));
        if(Padding) a=a.PadLeft(rozmiar, '0');
        return a;
    }
    static string ConvertToString(long liczba, int formatLiczbowy)
    {
        if (formatLiczbowy < 2 || formatLiczbowy > 36)
        {
            throw new ArgumentException("Nieprawidłowy format liczbowy. Format musi być w zakresie od 2 do 36.");
        }

        if (liczba == 0)
        {
            return "0"; // Obsługa przypadku, gdy liczba wynosi 0
        }

        bool czyUjemna = liczba < 0;
        if (czyUjemna)
        {
            // Konwersja na kod uzupełnień do dwóch
            liczba = (1L << 63) + liczba; // Dodajemy najbardziej znaczący bit
        }

        string znaki = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        char[] wynikChar = new char[64]; // Maksymalna długość wyniku (w przypadku formatu 2)
        int pozycja = 63; // Początkowa pozycja w tablicy wyniku

        while (liczba != 0)
        {
            int reszta = (int)(liczba % formatLiczbowy);
            wynikChar[pozycja--] = znaki[reszta];
            liczba /= formatLiczbowy;
        }

        // Dodanie znaku minus, jeśli liczba była ujemna

        // Konwersja tablicy char do stringa, pomijając wiodące zera
        return new string(wynikChar, pozycja + 1, 63 - pozycja);
    }
}