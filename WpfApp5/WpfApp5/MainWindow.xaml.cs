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

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class Fraction
        {
            private int numerator;
            private int denumerator;

            public int Numerator
            {
                get
                {
                    return numerator;
                }
                set
                {
                    numerator = value;
                }
            }

            public int Denumerator
            {
                get
                {
                    return denumerator;
                }
                set
                {
                    if (value != 0)
                    {
                        denumerator = value;
                    }
                }
            }

            public void Set_Fraction(string SF)
            {
                string[] pieces = SF.Split('/');
                try
                {
                    if (int.Parse(pieces[1]) == 0)
                    {
                        MessageBox.Show("На 0 делить нельзя!\n повторите ввод");
                    }
                    else
                    {

                        Numerator = int.Parse(pieces[0]);
                        Denumerator = int.Parse(pieces[1]);
                    }
                }
                catch
                {
                    MessageBox.Show("Проверьте введенные значения", "Ошибка данных", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            public string Get_Fraction()
            {
                return $"{numerator}/{denumerator}";
            }
            public override string ToString()
            {
                return $"числитель: {numerator}, Знаменатель: {denumerator}";
            }
            public void Sum(string one, string two, out string sum)
            {
                sum = "";
                int n_one;
                int d_one;
                int n_two;
                int d_two;
                string[] piece_one = one.Split('/');
                string[] piece_two = two.Split('/');
                try
                {
                    if (int.Parse(piece_one[1]) == 0)
                    {
                        MessageBox.Show("На 0 делить нельзя!\n повторите ввод");
                    }
                    else
                    {
                        n_one = int.Parse(piece_one[0]);
                        d_one = int.Parse(piece_one[1]);
                        n_two = int.Parse(piece_two[0]);
                        d_two = int.Parse(piece_two[1]);
                        if (d_one == d_two)
                        {
                            sum= $"{n_one + n_two}/{d_one}";
                        }
                        else
                        {
                            sum= $"{n_one * d_two + n_two * d_one}/{d_one * d_two}";
                        }

                    }
                }
                catch
                {
                    MessageBox.Show("Проверьте введенные значения", "Ошибка данных", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Denumerator_Tb.Visibility = Visibility.Visible;
            Denumerator_Lb.Visibility = Visibility.Visible;
            if (Add_RB.IsChecked == true)
            {
                Fraction_Lb.Items.Clear();
                Add_Bt.Content = "Добавить";
                Numerator_Lb.Content = "Числитель";
                Denumerator_Lb.Content = "Знаменатель";
            }
            if (Sum_RB.IsChecked == true)
            {
                Fraction_Lb.Items.Clear();
                Add_Bt.Content = "Рассчитать";
                Numerator_Lb.Content = "Первая дробь";
                Denumerator_Lb.Content = "Вторая дробь";
            }
            if (Mode_RB.IsChecked == true)
            {
                Fraction_Lb.Items.Clear();
                Add_Bt.Content = "Добавить";
                Numerator_Lb.Content = "Числитель";
                Denumerator_Lb.Content = "Знаменатель";
            }
            if (In_RB.IsChecked == true)
            {
                Denumerator_Lb.Visibility = Visibility.Hidden;
                Denumerator_Tb.Visibility = Visibility.Hidden;
                Fraction_Lb.Items.Clear();
                Add_Bt.Content = "Добавить";
                Numerator_Lb.Content = "Числитель";
                Denumerator_Lb.Content = "Знаменатель";
            }

        }
        List<Fraction> fractions = new List<Fraction>
        {
            new Fraction {Numerator=2,Denumerator=5},
            new Fraction {Numerator=1,Denumerator=7},
            new Fraction {Numerator=11,Denumerator=35},
             new Fraction {Numerator=26,Denumerator=71},
            new Fraction {Numerator=12,Denumerator=37},

        };

        private void Add_Bt_Click(object sender, RoutedEventArgs e)
        {
           
            if (Add_RB.IsChecked == true)
            {
                try
                {
                    Fraction fraction = new Fraction
                    {
                        Numerator = int.Parse(Numerator_Tb.Text),
                        Denumerator = int.Parse(Denumerator_Tb.Text)
                    };
                    fractions.Add(fraction);
                    Fraction_Lb.Items.Clear();
                    foreach (var fract in fractions)
                    {
                        Fraction_Lb.Items.Add(fract);
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Проверьте введенные значения", "Ошибка данных", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if(In_RB.IsChecked==true)
            {
                try
                {
                    Fraction_Lb.Items.Clear();
                    Fraction fraction = new Fraction();
                    fraction.Set_Fraction(Numerator_Tb.Text);
                    fractions.Add(fraction);
                    foreach (var fract in fractions)
                    {
                        Fraction_Lb.Items.Add(fract);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Проверьте введенные значения", "Ошибка данных", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (Sum_RB.IsChecked == true)
            {
                string Sum;
                Fraction fraction = new Fraction();
                Fraction_Lb.Items.Clear();
                fraction.Sum(Numerator_Tb.Text, Denumerator_Tb.Text, out Sum);
                foreach (var fract in fractions)
                {
                    Fraction_Lb.Items.Add(fract);
                }
                Fraction_Lb.Items.Add(Sum);

            }
            if(Mode_RB.IsChecked==true)
            {
                try
                {
                    Fraction fraction = new Fraction
                    {
                        Numerator = int.Parse(Numerator_Tb.Text),
                        Denumerator = int.Parse(Denumerator_Tb.Text)
                    };
                    fractions.Add(fraction);
                    Fraction_Lb.Items.Clear();
                    for(int fract=0; fract<fractions.Count-1; fract++)
                    {
                        Fraction_Lb.Items.Add(fractions[fract]);
                    }
                    Fraction_Lb.Items.Add(fractions[fractions.Count - 1].Get_Fraction());
                }
                catch (Exception)
                {
                    MessageBox.Show("Проверьте введенные значения", "Ошибка данных", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }
    }
}
