using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using KalkulatorFunkcje;

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Func<long, long, long> operation;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            var text = (e.Source as Button).Content.ToString();
            ValueBox.Text = ValueBox.Text == "0" ? ValueBox.Text = text : ValueBox.Text += text;
        }
        private void ClearEvrything(object sender, RoutedEventArgs e)
        {
            ValueBox.Text = "0";
            KalkulatorFunkcje.Liczba.wartosc = 0;
        }

        private void Clear(object sender, RoutedEventArgs e) {ValueBox.Text = "0";}

        private void Add(object sender, RoutedEventArgs e)
        {
            Liczba.firstValue = Liczba.ToInt(ValueBox.Text);
            ValueBox.Clear();
            operation = PodstawoweFunkcje.Dodawanie;
        }
        
        private void Substract(object sender, RoutedEventArgs e)
        {
            Liczba.firstValue = Liczba.ToInt(ValueBox.Text);
            ValueBox.Clear();
            operation = PodstawoweFunkcje.Odejmowanie;
        }
        private void Multiplication(object sender, RoutedEventArgs e)
        {
            Liczba.firstValue = Liczba.ToInt(ValueBox.Text);
            ValueBox.Clear();
            operation = PodstawoweFunkcje.Mnozenie;
        }
        private void Division(object sender, RoutedEventArgs e)
        {
            Liczba.firstValue = Liczba.ToInt(ValueBox.Text);
            ValueBox.Clear();
            operation = PodstawoweFunkcje.Dzielenie;
        }
        private void ModuloDivision(object sender, RoutedEventArgs e)
        {
            Liczba.firstValue = Liczba.ToInt(ValueBox.Text);
            ValueBox.Clear();
            operation = PodstawoweFunkcje.DzielenieModulo;
        }
        private void Equal(object sender, RoutedEventArgs e) {ValueBox.Text = Liczba.ToString(operation(Liczba.firstValue, Liczba.ToInt(ValueBox.Text)), false) ;}

        private void NumberSystemType(int formatToConvert) {ValueBox.Text = Liczba.ToString(Convert.ToInt64(ValueBox.Text, Liczba.format), formatToConvert);}
        //private void NumberSystemLength(int formatToConvert) {ValueBox.Text = }
        private void ButtonSystemHex(object sender, RoutedEventArgs e) {NumberSystemType(16); Liczba.SetHexagonal(); ButtonsLock((e.Source as Button).Content.ToString());}
        private void ButtonSystemDec(object sender, RoutedEventArgs e) {NumberSystemType(10); Liczba.SetDecimal(); ButtonsLock((e.Source as Button).Content.ToString());}
        private void ButtonSystemOct(object sender, RoutedEventArgs e) {NumberSystemType(8); Liczba.SetOctal(); ButtonsLock((e.Source as Button).Content.ToString());}
        private void ButtonSystemBin(object sender, RoutedEventArgs e) {NumberSystemType(2); Liczba.SetBinary(); ButtonsLock((e.Source as Button).Content.ToString());}
        private void ButtonSystemlengthQword(object sender, RoutedEventArgs e) {Liczba.SetQword();}
        private void ButtonSystemlengthDword(object sender, RoutedEventArgs e) {Liczba.SetDword();}
        private void ButtonSystemlengthWord(object sender, RoutedEventArgs e) {Liczba.SetWord();}
        private void ButtonSystemlengthByte(object sender, RoutedEventArgs e) {Liczba.SetByte();}

        private void UpdateButtonEnabledState()
        {
            // Kolekcje przycisków dla różnych systemów liczbowych
            List<Button> hexButtons = new List<Button> { Button.NameProperty.Name };
            List<Button> decButtons = new List<Button> { /* Dodaj przyciski dziesiętne */ };
            List<Button> octButtons = new List<Button> { /* Dodaj przyciski ósemkowe */ };
            List<Button> binButtons = new List<Button> { /* Dodaj przyciski binarne */ };

            // Wszystkie przyciski
            List<Button> allButtons = new List<Button> { /* Dodaj wszystkie przyciski */ };

            switch (currentNumberSystem)
            {
                case NumberSystem.Hex:
                    EnableButtons(hexButtons);
                    DisableButtons(decButtons, octButtons, binButtons);
                    break;

                case NumberSystem.Dec:
                    EnableButtons(decButtons);
                    DisableButtons(hexButtons, octButtons, binButtons);
                    break;

                case NumberSystem.Oct:
                    EnableButtons(octButtons);
                    DisableButtons(hexButtons, decButtons, binButtons);
                    break;

                case NumberSystem.Bin:
                    EnableButtons(binButtons);
                    DisableButtons(hexButtons, decButtons, octButtons);
                    break;
            }
        }

// Metoda do włączania przycisków
        private void EnableButtons(List<Button> buttons)
        {
            foreach (var button in buttons)
            {
                button.IsEnabled = true;
            }
        }

// Metoda do wyłączania przycisków
        private void DisableButtons(params List<Button>[] buttonLists)
        {
            foreach (var buttons in buttonLists)
            {
                foreach (var button in buttons)
                {
                    button.IsEnabled = false;
                }
            }
        }
      
        
    }
}