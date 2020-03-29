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
    /// Logika interakcji dla klasy TextBoxError.xaml
    /// </summary>
    public partial class TextBoxError : UserControl
    {
        #region Wlasciwosci
        public static Brush BrushForAll { get; set; } = Brushes.Brown;

        public Brush TextBoxBorderBrush
        {
            get
            {

                return borer.BorderBrush;
            }
            set
            {

                borer.BorderBrush = value;
            }
        }

        public string Text
        {
            get
            {
                return textBox.Text;
            }
            set
            {
                textBox.Text = value;
            }
        }


        #endregion



        public TextBoxError()
        {
            InitializeComponent();
            borer.BorderBrush = BrushForAll;
        }

        public void SetError(string errorText)
        {
            textBlockToolTip.Text = errorText;
            if (errorText != "")
            {
                borer.BorderThickness = new Thickness(1);
                tooltip.Visibility = Visibility.Visible;
            }
            else
            {
                borer.BorderThickness = new Thickness(0);
                tooltip.Visibility = Visibility.Hidden;
            }
        }
    }
}
