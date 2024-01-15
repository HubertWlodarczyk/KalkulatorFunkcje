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

        private void NumberSystemType()
        {
            ValueBox.Text = Liczba.ToString(Liczba.ToInt(ValueBox.Text), false);
        }
        private void ButtonSystemHex(object sender, RoutedEventArgs e) {Liczba.SetHexagonal(); NumberSystemType();}
        private void ButtonSystemDec(object sender, RoutedEventArgs e) {Liczba.SetDecimal(); NumberSystemType();}
        private void ButtonSystemOct(object sender, RoutedEventArgs e) {Liczba.SetOctal(); NumberSystemType();}
        private void ButtonSystemBin(object sender, RoutedEventArgs e) {Liczba.SetBinary(); NumberSystemType();}
        private void ButtonSystemlengthQword(object sender, RoutedEventArgs e) {Liczba.SetQword();}
        private void ButtonSystemlengthDword(object sender, RoutedEventArgs e) {Liczba.SetDword();}
        private void ButtonSystemlengthWord(object sender, RoutedEventArgs e) {Liczba.SetWord();}
        private void ButtonSystemlengthByte(object sender, RoutedEventArgs e) {Liczba.SetByte();}
        
    }
}