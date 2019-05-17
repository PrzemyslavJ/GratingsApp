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

namespace GratingsApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        double L = 0, W = 0, tb = 0, t = 0, MeshB = 0, MeshC = 0, CorValue = 0;
        int OptionB = 1, OptionC = 1, OptionCor = 0;
        double a1 = 0, a = 0, a2 = 0;
        double b1 = 0, b = 0, b2 = 0;
        int QuantityB = 0, QuantityC = 0;

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aplikacja została stworzona przez Przemysława Jaworskkiego,pracownika firmy Staco Polska, adres ul. Fabryczna 8, Niepołomice. Powstała jako pomocniczne narzędzie konstrukutorów,rysowników krat pomostowych. Poprawność funkcjonowania programu była weryfikowana. Wszelkie uwagi proszę kierować na adres email: jaworskiprzemyslaw95@gmail.com.","Informacje");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Correction_Click(object sender, RoutedEventArgs e)
        {
            Functions CalcCor = new Functions();


            if (CorValue > 0 && OptionCor > 0)
            {
                switch (OptionCor)
                {
                    case 1:
                        CalcCor.Correction(ref CorValue, ref t, ref a2, ref a, ref a1);
                        a1t.Text = Convert.ToString(a1);
                        a1t.Foreground = Brushes.Red;
                        a2t.Text = Convert.ToString(a2);
                        a2t.Foreground = Brushes.Red;
                        Statement.Content = "Dokonano korekcji !";
                        break;
                    case 2:
                        CalcCor.Correction(ref CorValue, ref t, ref a1, ref a, ref a2);
                        a1t.Text = Convert.ToString(a1);
                        a1t.Foreground = Brushes.Red;
                        a2t.Text = Convert.ToString(a2);
                        a2t.Foreground = Brushes.Red;
                        Statement.Content = "Dokonano korekcji !";
                        break;
                    case 3:
                        CalcCor.Correction(ref CorValue, ref t, ref b1, ref b, ref b2);
                        b1t.Text = Convert.ToString(b1);
                        b1t.Foreground = Brushes.Red;
                        b2t.Text = Convert.ToString(b2);
                        b2t.Foreground = Brushes.Red;
                        Statement.Content = "Dokonano korekcji !";
                        break;
                    case 4:
                        CalcCor.Correction(ref CorValue, ref t, ref b2, ref b, ref b1);
                        b1t.Text = Convert.ToString(b1);
                        b1t.Foreground = Brushes.Red;
                        b2t.Text = Convert.ToString(b2);
                        b2t.Foreground = Brushes.Red;
                        Statement.Content = "Dokonano korekcji !";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Statement.Content = "Zdefiniuj wszystkie dane do korekcji ! ";
            }
            
        }
        
        private void CorrectionV_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (OptionCor > 0 && a > 0 && b> 0)
            {
                try
                {
                    CorValue = Convert.ToDouble(CorrectionV.Text);
                    Statement.Content = " ";
                }
                catch
                {
                    Statement.Content = "Nieprawidłowa wartość korekcji, wprowadź poprawną !";
                    CorValue = 0;
                }
                if (OptionCor == 1 || OptionCor == 2)
                {
                    if (CorValue <= 0 || CorValue > a)
                    { Statement.Content = "Nieprawidłowa wartość korekcji, wprowadź poprawną, mniejszą od wielkości oczka !";
                      CorrectionV.Text = "";
                    }
                }
                else if (OptionCor == 3 || OptionCor == 4)
                {
                    if (CorValue <= 0 || CorValue > b)
                    { Statement.Content = "Nieprawidłowa wartość korekcji, wprowadź poprawną, mniejszą od wielkości oczka !";
                        CorrectionV.Text = "";
                    }
                }

            }
            else
            {
                Statement.Content = "Wybierz najpierw opcję przesunięcia lub zdefiniuj oczka ! ";
                CorrectionV.Text = "";
            }
        }
        

        private void OptionCorection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OptionCorection.SelectedIndex == 0) { OptionCor = 1; }
            if (OptionCorection.SelectedIndex == 1) { OptionCor = 2; }
            if (OptionCorection.SelectedIndex == 2) { OptionCor = 3; }
            if (OptionCorection.SelectedIndex == 3) { OptionCor = 4; }
        }
        
        private void Length_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                L = Convert.ToDouble(Length.Text);
                Statement.Content = " ";
            }
            catch
            {
                Statement.Content = "Nieprawidłowa wartość długości kraty, wprowadź poprawną !";
                L = 0;
            }
            
            if (L <= 0 || L > 20000)
            {
                Statement.Content = "Nieprawidłowa wartość długości kraty, wprowadź poprawną !";
                L = 0;
                Length.Text = "";
            }
            
        }

        private void MeshCrossBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MeshC = Convert.ToDouble(MeshCrossBar.Text);
                Statement.Content = " ";
            }
            catch
            {
                Statement.Content = "Nieprawidłowa wartość oczka poprzecznego, wprowadź poprawną !";
                MeshC = 0;
            }

            if (MeshC <= 0 || MeshC > 250)
            {
                Statement.Content = "Nieprawidłowa wartość oczka poprzecznego, wprowadź poprawną !";
                MeshC = 0;
                MeshCrossBar.Text = "";
            }
        }

        private void OptionCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OptionCBox.SelectedIndex == 0) { OptionC = 1; }
            if (OptionCBox.SelectedIndex == 1) { OptionC = 2; }
        }

        private void OptionBBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            if (OptionBBox.SelectedIndex == 0) { OptionB = 1; }
            if (OptionBBox.SelectedIndex == 1) { OptionB = 2; }
            if (OptionBBox.SelectedIndex == 2) { OptionB = 3; }
            
        }

        private void Calculations_Click(object sender, RoutedEventArgs e)
        {
            Functions calc = new Functions();

            if (L > 0 && W > 0 && MeshB > 0 && MeshC > 0 && t > 0)
            {
                switch (OptionB)
                {
                    case 1:
                        calc.CentreMesh(ref W, ref MeshB, ref a1, ref QuantityB);
                        a = MeshB;
                        a2 = a1;
                        at.Text = Convert.ToString(a);
                        a1t.Text = a2t.Text = Convert.ToString(a1);
                        QuantityBearingBar.Text = Convert.ToString(QuantityB);
                        break;
                    case 2:
                        calc.EvenEye(ref W, ref t, ref MeshB, ref a, ref QuantityB);
                        a1 = a2 = a + t / 2;
                        at.Text = Convert.ToString(a);
                        a1t.Text = a2t.Text = Convert.ToString(a1);
                        QuantityBearingBar.Text = Convert.ToString(QuantityB);
                        break;
                    case 3:
                        calc.FromFullMesh(ref W, ref t, ref MeshB, ref a2, ref QuantityB);
                        a = MeshB;
                        a1 = a + t / 2;
                        at.Text = Convert.ToString(a);
                        a1t.Text = Convert.ToString(a1);
                        a2t.Text = Convert.ToString(a2);
                        QuantityBearingBar.Text = Convert.ToString(QuantityB);
                        break;
                    default:
                        break;
                }
                switch (OptionC)
                {
                    case 1:
                        calc.CentreMesh(ref L, ref MeshC, ref b1, ref QuantityC);
                        b = MeshC;
                        b2 = b1;
                        bt.Text = Convert.ToString(b);
                        b1t.Text = b2t.Text = Convert.ToString(b1);
                        QuantityCrossBar.Text = Convert.ToString(QuantityC);
                        break;
                    case 2:
                        calc.FromFullMesh(ref L, ref t, ref MeshC, ref b2, ref QuantityC);
                        b = MeshC;
                        b1 = b + t / 2;
                        bt.Text = Convert.ToString(b);
                        b1t.Text = Convert.ToString(b1);
                        b2t.Text = Convert.ToString(b2);
                        QuantityCrossBar.Text = Convert.ToString(QuantityC);
                        break;
                    default:
                        break;
                }
            } 
            else
            {
                Statement.Content = "Wprowadź najpierw wszystkie dane !";
            }
        }

        private void MeshBearingBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                MeshB = Convert.ToDouble(MeshBearingBar.Text);
                Statement.Content = " ";
            }
            catch
            {
                Statement.Content = "Nieprawidłowa wartość oczka nośnego, wprowadź poprawną !";
                MeshB = 0;
            }

            if (MeshB <= 0 || MeshB > 250)
            {
                Statement.Content = "Nieprawidłowa wartość oczka nośnego, wprowadź poprawną !";
                MeshB = 0;
                MeshBearingBar.Text = "";
            }
        }

        private void ThicknessB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                t = Convert.ToDouble(ThicknessB.Text);
                Statement.Content = " ";
            }
            catch
            {
                Statement.Content = "Nieprawidłowa wartość grubości obramowania, wprowadź poprawną !";
                t = 0;
            }

            if (t <= 0 || t > 50)
            {
                Statement.Content = "Nieprawidłowa wartość grubości obramowania, wprowadź poprawną !";
                t = 0;
                ThicknessB.Text = "";
            }
        }

        private void Thickness_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                tb = Convert.ToDouble(Thickness.Text);
                Statement.Content = " ";
                ThicknessB.Text = Thickness.Text;
            }
            catch
            {
                Statement.Content = "Nieprawidłowa wartość grubości płaskownika nośnego, wprowadź poprawną !";
                tb = 0;
            }

            if (tb <= 0 || tb > 50)
            {
                Statement.Content = "Nieprawidłowa wartość grubości płaskownika nośnego, wprowadź poprawną !";
                tb = 0;
                Thickness.Text = "";
            }
        }

        private void Width_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                W = Convert.ToDouble(Width.Text);
                Statement.Content = " ";
            }
            catch
            {
                Statement.Content = "Nieprawidłowa wartość szerokości kraty, wprowadź poprawną !";
                W = 0;
            }

            if (W <= 0 || W > 20000)
            {
                Statement.Content = "Nieprawidłowa wartość szerokości kraty, wprowadź poprawną !";
                W = 0;
                Width.Text = "";
            }
        }
    }
}
