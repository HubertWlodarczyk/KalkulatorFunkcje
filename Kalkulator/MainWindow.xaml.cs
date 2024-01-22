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
            UpdateButtonEnabledState();
            UpdateWordLengthValue();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            var text = (e.Source as Button).Content.ToString();
            if(Liczba.ToInt(ValueBox.Text)+Liczba.ToInt(text)>=Math.Pow(2,Liczba.rozmiar)) return;
            ValueBox.Text = ValueBox.Text == "0" ? ValueBox.Text = text : ValueBox.Text += text;
            BinBox.Text = Liczba.ToString(Liczba.ToInt(ValueBox.Text), 2,true);

        }
        private void ClearEvrything(object sender, RoutedEventArgs e)
        {
            ValueBox.Text = "0";
            KalkulatorFunkcje.Liczba.wartosc = 0;
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            ValueBox.Text = "0";
        }

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

        private void Equal(object sender, RoutedEventArgs e)
        {
            if(operation==null)return;
            ValueBox.Text = Liczba.ToString(operation(Liczba.firstValue, Liczba.ToInt(ValueBox.Text)), false);
        }

        private void NumberSystemType(int formatToConvert)
        {
            ValueBox.Text = Liczba.ToString(Convert.ToInt64(ValueBox.Text, Liczba.format), formatToConvert);
        }

        private void ButtonSystemHex(object sender, RoutedEventArgs e)
        {
            NumberSystemType(16); Liczba.SetHexagonal(); 
            UpdateButtonEnabledState();
        }

        private void ButtonSystemDec(object sender, RoutedEventArgs e)
        {
            NumberSystemType(10); Liczba.SetDecimal(); 
            UpdateButtonEnabledState();
        }

        private void ButtonSystemOct(object sender, RoutedEventArgs e)
        {
            NumberSystemType(8); Liczba.SetOctal(); 
            UpdateButtonEnabledState();
        }

        private void ButtonSystemBin(object sender, RoutedEventArgs e)
        {
            NumberSystemType(2); Liczba.SetBinary(); 
            UpdateButtonEnabledState();
        }


        private void ButtonSystemlengthQword(object sender, RoutedEventArgs e)
        {
            Liczba.SetQword(); 
            UpdateButtonEnabledState(); 
            UpdateWordLengthValue();
        }

        private void ButtonSystemlengthDword(object sender, RoutedEventArgs e)
        {
            Liczba.SetDword(); 
            UpdateButtonEnabledState(); 
            UpdateWordLengthValue();
        }

        private void ButtonSystemlengthWord(object sender, RoutedEventArgs e)
        {
            Liczba.SetWord(); 
            UpdateButtonEnabledState(); 
            UpdateWordLengthValue();
        }

        private void ButtonSystemlengthByte(object sender, RoutedEventArgs e)
        {
            Liczba.SetByte(); 
            UpdateButtonEnabledState(); 
            UpdateWordLengthValue();
        }
        
        private void UpdateWordLengthValue()
        {
            long currentValue = Liczba.ToInt(ValueBox.Text);

            switch (Liczba.rozmiar)
            {
                case 64:
                    // Ogranicz wartość do 64-bitowej liczby całkowitej (Qword)
                    Liczba.SetQword();
                    ValueBox.Text = Liczba.ToString(currentValue, false);
                    break;

                case 32:
                    // Ogranicz wartość do 32-bitowej liczby całkowitej (Dword)
                    Liczba.SetDword();
                    ValueBox.Text = Liczba.ToString(currentValue, false);
                    break;

                case 16:
                    // Ogranicz wartość do 16-bitowej liczby całkowitej (Word)
                    Liczba.SetWord();
                    ValueBox.Text = Liczba.ToString(currentValue, false);
                    break;

                case 8:
                    // Ogranicz wartość do 8-bitowej liczby całkowitej (Byte)
                    Liczba.SetByte();
                    ValueBox.Text = Liczba.ToString(currentValue, false);
                    break;
            }
        }


        private void UpdateButtonEnabledState()
        {
            // Kolekcje przycisków dla różnych systemów liczbowych
            List<Button> hexButtons = new List<Button> { btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btnA, btnB, btnC, btnD, btnE, btnF };
            List<Button> decButtons = new List<Button> { btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            List<Button> octButtons = new List<Button> { btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7 };
            List<Button> binButtons = new List<Button> { btn0, btn1 };

            // Wszystkie przyciski
            List<Button> allButtons = new List<Button> { btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btnA, btnB, btnC, btnD, btnE, btnF };

            switch (Liczba.format)
            {
                case 16:
                    DisableButtons(allButtons);
                    EnableButtons(hexButtons);
                    break;

                case 10:
                    DisableButtons(allButtons);
                    EnableButtons(decButtons);
                    break;

                case 8:
                    DisableButtons(allButtons);
                    EnableButtons(octButtons);
                    break;

                case 2:
                    DisableButtons(allButtons);
                    EnableButtons(binButtons);
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
      
        private void ButtonAnd(object sender, RoutedEventArgs e)
        {
            Liczba.firstValue = Liczba.ToInt(ValueBox.Text);
            ValueBox.Clear();
            operation = OperacjeNaBitach.And;
        }

        private void ButtonOr(object sender, RoutedEventArgs e)
        {
            Liczba.firstValue = Liczba.ToInt(ValueBox.Text);
            ValueBox.Clear();
            operation = OperacjeNaBitach.Or;
        }

        private void ButtonXor(object sender, RoutedEventArgs e)
        {
            Liczba.firstValue = Liczba.ToInt(ValueBox.Text);
            ValueBox.Clear();
            operation = OperacjeNaBitach.Xor;
        }

        private void ButtonRotateR(object sender, RoutedEventArgs e)
        {
            Liczba.firstValue = Liczba.ToInt(ValueBox.Text);
            ValueBox.Clear();
            operation = (x, y) => OperacjeNaBitach.RotateR(x, (int)y);
            UpdateButtonEnabledState();
            UpdateWordLengthValue();
        }

        private void ButtonRotateL(object sender, RoutedEventArgs e)
        {
            Liczba.firstValue = Liczba.ToInt(ValueBox.Text);
            ValueBox.Clear();
            operation = (x, y) => OperacjeNaBitach.RotateL(x, (int)y);
            UpdateButtonEnabledState();
            UpdateWordLengthValue();
        }

        private void ButtonShiftR(object sender, RoutedEventArgs e)
        {
            Liczba.firstValue = Liczba.ToInt(ValueBox.Text);
            ValueBox.Clear();
            operation = (x, y) => OperacjeNaBitach.ShiftR(x, (int)y);
            UpdateButtonEnabledState();
            UpdateWordLengthValue();
        }

        private void ButtonShiftL(object sender, RoutedEventArgs e)
        {
            Liczba.firstValue = Liczba.ToInt(ValueBox.Text);
            ValueBox.Clear();
            operation = (x, y) => OperacjeNaBitach.ShiftL(x, (int)y);
            UpdateButtonEnabledState();
            UpdateWordLengthValue();
        }

        private void ButtonNot(object sender, RoutedEventArgs e)
        {
            Liczba.firstValue = Liczba.ToInt(ValueBox.Text);
            ValueBox.Clear();
            ValueBox.Text = Liczba.ToString(OperacjeNaBitach.Not(Liczba.firstValue),Liczba.format);
            UpdateButtonEnabledState();
            UpdateWordLengthValue();
        }

        private void ButtonEqualBitwise(object sender, RoutedEventArgs e)
        {
            ValueBox.Text = Liczba.ToString(operation(Liczba.firstValue, Liczba.ToInt(ValueBox.Text)), false);
        }
        
    }
}