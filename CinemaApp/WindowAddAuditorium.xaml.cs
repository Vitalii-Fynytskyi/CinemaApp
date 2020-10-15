using CinemaApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CinemaApp
{
    /// <summary>
    /// Логика взаимодействия для WindowAddAuditorium.xaml
    /// </summary>
    public partial class WindowAddAuditorium : Window
    {
        public WindowAddAuditorium()
        {
            InitializeComponent();
        }
        private bool hasErrors()
        {
            if (!Int32.TryParse(TextBoxAuditoriumNumber.Text, out int auditoriumNumber))
            {
                MessageBox.Show("Невірно введено номер аудиторії");
                return true;
            }
            ///check if auditorium with same internal number already exist
            Auditorium existedAuditorium = (from a in SharedData.AuditoriumsFromDatabase where a.InternalNumber == auditoriumNumber select a).FirstOrDefault();
            if(existedAuditorium != null)
            {
                MessageBox.Show("Зал з вказаним номером вже існує");
                return true;
            }
            if (!Int32.TryParse(TextBoxCountPlaces.Text, out int countPlaces))
            {
                MessageBox.Show("Невірно введено кількість місць");
                return true;
            }
            if (!Int32.TryParse(TextBoxCountRows.Text, out int countRows))
            {
                MessageBox.Show("Невірно введено кількість рядів");
                return true;
            }
            if (countPlaces % countRows != 0)
            {
                MessageBox.Show("Кількість місць у кожному ряді повинна бути однакова");
                return true;
            }
            return false;
        }
        private void ButtonAddAuditorium_Click(object sender, RoutedEventArgs e)
        {
            if (hasErrors()) return;
            Auditorium newAuditorium = new Auditorium()
            {
                InternalNumber = Convert.ToInt32(TextBoxAuditoriumNumber.Text),
                CountPlaces = Convert.ToInt32(TextBoxCountPlaces.Text),
                CountRows = Convert.ToInt32(TextBoxCountRows.Text)
            };
            int row = 0;
            using (SQLiteConnection connection = new SQLiteConnection(SharedData.DatabaseLocation))
            {
                connection.CreateTable<Auditorium>();
                row = connection.Insert(newAuditorium);
                if (row == 0)
                {
                    MessageBox.Show("Не вдалось додати аудиторію");
                }
            }
            if (row > 0)
            {
                SharedData.AuditoriumsToView.Add(newAuditorium);
                SharedData.AuditoriumsFromDatabase.Add(newAuditorium);
            }
            this.Close();
        }
    }
}
