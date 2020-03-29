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

namespace FootballersForm
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            TextBoxError.BrushForAll = Brushes.Red;
            InitializeComponent();


        }

        private bool isNoEmpty(TextBoxError tb)
        {
            if (tb.Text.Trim() == "")
            {
                tb.SetError("Pole nie może być puste!");
                return false;
            }
            tb.SetError("");
            return true;
        }


        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            //zwróć uwagę na różnicę między operatorem logicznym & - wyznacza obydwa operandy i liczy wynik
            //a operatorem warunkowym && który w przypadku lewego operandu fałszywego nie wyznacza prawego perandu
            //i wówczas nie zgłosi błędu w drugim polu!!!
            if (isNoEmpty(textBox) & isNoEmpty(textBox1))
            {
                //tu poprawnie mamy wpisane dane
            }

        }
    }
}
