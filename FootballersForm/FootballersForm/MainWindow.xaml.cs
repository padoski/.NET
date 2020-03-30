using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            TextBoxError.BrushForAll = Brushes.Red;
            InitializeComponent();
            for (int i = 15; i < 70; i++)
            {
                cbAge.Items.Add(i);
            }
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
            if (isNoEmpty(tbName) & isNoEmpty(tbSurname))
            {
                var currentFootballer = new Footballer(tbName.Text.Trim(), tbSurname.Text.Trim(), Convert.ToByte(cbAge.Text), (float)slweight.Value);
                bool isOnList = false;
                foreach (var p in lb_LisOfPlayers.Items)
                {
                    var pilkarz = p as Footballer;
                    if (pilkarz.isInList(currentFootballer))
                    {
                        isOnList = true;
                        break;
                    }
                }
                if(isOnList==false)
                {
                    lb_LisOfPlayers.Items.Add(currentFootballer);
                    ResetValues();
                }
                else
                {
                    var dialog = MessageBox.Show("Piłkarz którego chcesz dodać jest już na liście!", "Uwaga", MessageBoxButton.OK);
                    ResetValues();
                } 
            }

        }

        private void slweight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender != null)
            {
                tbweight.Text = Math.Round(slweight.Value,1).ToString() + " kg";
            }
        }

        private void RemoveFootballer(object sender, RoutedEventArgs e)
        {
            if (lb_LisOfPlayers.SelectedIndex == -1)
            {
                var dialog = MessageBox.Show("Nie wybrales nikogo do usuniecia", "Uwaga", MessageBoxButton.OK);
            }
            else { 
                var dialog = MessageBox.Show("Czy na pewno usunać piłkarza?", "Uwaga", MessageBoxButton.OKCancel);
            if (dialog == MessageBoxResult.OK)
            {
                lb_LisOfPlayers.Items.Remove(lb_LisOfPlayers.SelectedItem);
                ResetValues();
            }
            }
        }

        private void ModifyFootballer(object sender, RoutedEventArgs e)
        {
            if (lb_LisOfPlayers.SelectedIndex != -1)
            {
                var dialog = MessageBox.Show("Czy na pewno chcesz modyfikować dane piłkarza?", "Uwaga", MessageBoxButton.OKCancel);
                int index = 0;
                if (dialog == MessageBoxResult.OK)
                {

                    index = lb_LisOfPlayers.SelectedIndex;
                   // lb_LisOfPlayers.SelectedIndex = -1;
                    if (index != -1 && isNoEmpty(tbName) & isNoEmpty(tbSurname))
                    {
                        var currentFootballer = new Footballer(tbName.Text.Trim(), tbSurname.Text.Trim(), Convert.ToByte(cbAge.Text), (float)slweight.Value);
                        bool isOnList = false;
                        foreach (var p in lb_LisOfPlayers.Items)
                        {
                            var pilkarz = p as Footballer;
                            if (pilkarz.isInList(currentFootballer))
                            {
                                isOnList = true;
                                break;
                            }
                        }
                        if (isOnList == false)
                        {
                            lb_LisOfPlayers.Items.Remove(lb_LisOfPlayers.SelectedItem);
                            lb_LisOfPlayers.Items.Insert(index, currentFootballer);
                        }
                        else
                        {
                            var dialog2 = MessageBox.Show("Już taki piłkarz jest na liście, wprowadź innego!", "Uwaga", MessageBoxButton.OK);
                        }
                    }
                    ResetValues();
                }
            }
        }

        private void IsSelect(object sender, SelectionChangedEventArgs e)
        {
            //lb_LisOfPlayers.SelectedIndex != -1
            if (sender != null && lb_LisOfPlayers.SelectedIndex != -1)
            {
                Footballer player = (Footballer)lb_LisOfPlayers.SelectedItem;
                tbName.Text = player.getName();
                tbSurname.Text = player.getSurname();
                slweight.Value = player.getWeight();
                cbAge.Text = player.getAge().ToString();

            }
        }
        private void ResetValues()
        {
            tbName.Text = "";
            tbSurname.Text = "";
            slweight.Value = 50;
            cbAge.SelectedIndex = 0;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int countOfPlayers = lb_LisOfPlayers.Items.Count;
            string path = @"E:\SemestrIV\.NET\FootballersForm\FootballersForm\dane.txt";
            System.IO.File.WriteAllText(path, string.Empty);

            for (int i = 0; i < countOfPlayers; i++)
            {
                var temp  = lb_LisOfPlayers.Items[i] as Footballer;
                File.AppendAllText(path,
                temp.FormatSaving() + Environment.NewLine);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] lines = File.ReadAllLines(@"E:\SemestrIV\.NET\FootballersForm\FootballersForm\dane.txt");
                foreach (string line in lines)
                {
                    lb_LisOfPlayers.Items.Add(Footballer.FootballerReadyToAdd(line));
                }
            }
            catch
            {
                MessageBox.Show("Nie udało się wczytać danych z pliku! Sprawdź czy plik istenieje i jego poporawność");
            }
            
        }
    }
}
