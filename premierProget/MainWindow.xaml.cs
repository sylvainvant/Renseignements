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

namespace premierProget
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            slider1.ValueChanged += new RoutedPropertyChangedEventHandler<double>(slider1_ValueChanged);
        }
            // déplacement du slider 
        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (label2 != null)
            label2.Content = ((int)slider1.Value).ToString();
        }      
            //button réinitialiser
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            slider1.Value = slider1.Minimum;
            textBox1.Text = "Votre nom";
            textBox2.Text = "Votre prénom";
            radioButton1.IsChecked = true;
            listBox1.SelectedIndex = -1;  // déselection
        }
            //button valider
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                MessageBox.Show("Choisissez une nationalité", "Nationalité",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                string resume = textBox2.Text + " " + textBox1.Text;
                resume += " de sexe " + (radioButton1.IsChecked == true ? "masculin" : "féminin");
                resume += " né" + (radioButton1.IsChecked == true ? "" : "e")
                                   + " en " + ((int)slider1.Value).ToString();
                resume += " de nationalité " + ((ListBoxItem)listBox1.SelectedItem).Content;
                MessageBox.Show(resume);
            }
        }
        //Conversion Double Entier 
        public class ConversionDoubleEntier : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value != null)
                {
                    double dblValue = (double)value;
                    return (int)dblValue;
                }
                return 0;
            }
            // obligation d’interface d’implémenter aussi la méthode ConvertBack
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }             
    }
}
