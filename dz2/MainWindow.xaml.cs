using System;
using System.Collections.Generic;
using System.Data;
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

namespace dz2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool zero = false;
        string ptr;
        int a;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void CE_Click(object sender, RoutedEventArgs e)
        {
            Naw.Text = String.Empty;
        }

        private void q7_Click(object sender, RoutedEventArgs e)
        {
            Naw.Text = Zer(Naw.Text, "7");
        }

        private void q4_Click(object sender, RoutedEventArgs e)
        {
            Naw.Text = Zer(Naw.Text, "4");
        }

        private void q1_Click(object sender, RoutedEventArgs e)
        {
            Naw.Text = Zer(Naw.Text, "1");
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            Naw.Text = String.Empty;
            History.Text= String.Empty;
        }

        private void q8_Click(object sender, RoutedEventArgs e)
        {
            Naw.Text = Zer(Naw.Text, "8");
        }

        private void q5_Click(object sender, RoutedEventArgs e)
        {
            Naw.Text = Zer(Naw.Text, "5");
        }

        private void q2_Click(object sender, RoutedEventArgs e)
        {
            Naw.Text= Zer(Naw.Text, "2");

        }
        private string Zer(string NawText, string number)
        {
            ptr = NawText;
            a = ptr.Length;

            if (zero)
            {
                NawText = ptr.Substring(0, a - 1);
                NawText += number;
                zero = false;
            }
            else NawText += number;
            return NawText;
        }

        private void q0_Click(object sender, RoutedEventArgs e)
        {
            Naw.Text += "0";
            a = Naw.Text.Length;
            if (Naw.Text.Length == 1)
            {
                zero = true;
            }
            else if(Naw.Text[a - 2] == '/' ||
                  Naw.Text[a - 2] == '*' ||
                  Naw.Text[a - 2] == '-' ||
                  Naw.Text[a - 2] == '+') { zero = true; }    
        }

        private void Rem_Click(object sender, RoutedEventArgs e)
        {
            ptr = Naw.Text;
            a = ptr.Length;
            if (a > 0)
            {
                Naw.Text = ptr.Substring(0, a - 1);
            }
        }

        private void q9_Click(object sender, RoutedEventArgs e)
        {
            Naw.Text = Zer(Naw.Text, "9");
        }

        private void q6_Click(object sender, RoutedEventArgs e)
        {
            Naw.Text = Zer(Naw.Text, "6");
        }

        private void q3_Click(object sender, RoutedEventArgs e)
        {
            Naw.Text = Zer(Naw.Text, "3");
        }

        private void equal_Click(object sender, RoutedEventArgs e)
        {
            History.Text= Naw.Text;
            string expression = Naw.Text;
            DataTable table = new DataTable();
            try
            {
                object result = table.Compute(expression, "");
                Naw.Text = result.ToString();
            }
            catch (Exception ex)
            {
                Naw.Text = "Error: " + ex.Message;
            }
        }

        private void share_Click(object sender, RoutedEventArgs e)
        {
            if (Naw.Text == String.Empty) { }
            else if (check_naw(Naw.Text))
            {
                Naw.Text = Naw.Text.Substring(0, Naw.Text.Length - 1);
                Naw.Text += "/";
            }
            else Naw.Text += "/";
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            if (Naw.Text == String.Empty) { }
            else if (check_naw(Naw.Text))
            {
                Naw.Text = Naw.Text.Substring(0, Naw.Text.Length - 1);
                Naw.Text += "*";
            }
            else Naw.Text += "*";
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            if (Naw.Text == String.Empty) { }
            else if (check_naw(Naw.Text))
            {
                Naw.Text = Naw.Text.Substring(0, Naw.Text.Length - 1);
                Naw.Text += "-";
            }
            else  Naw.Text += "-";
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            if (Naw.Text == String.Empty) { }
            else if (check_naw(Naw.Text))
            {
              Naw.Text = Naw.Text.Substring(0, Naw.Text.Length - 1);
              Naw.Text += "+";
            }
            else Naw.Text += "+";
        }

        private void point_Click(object sender, RoutedEventArgs e)
        {
            zero = false;
           
            if (Naw.Text.Length == 1)
            {
                Naw.Text += ".";
            }
            else if (check_naw(Naw.Text)|| Naw.Text.Length == 0) {
               Naw.Text += "0.";
            }  
            else Naw.Text += ".";
        }
        private bool check_naw(string NawText)
        {
            try
            {
                a = NawText.Length;
                if (Naw.Text[a - 1] == '/' ||
                      Naw.Text[a - 1] == '*' ||
                      Naw.Text[a - 1] == '-' ||
                      Naw.Text[a - 1] == '+')
                {
                    return true;
                }
            }
            catch (Exception ex) { }
            return false;
        }
    }
}
