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
using System.Windows.Shapes;
using TemporaryMailApp.Logic;

namespace TemporaryMailApp.View
{
    /// <summary>
    /// Логика взаимодействия для OperationsOnMailWindow.xaml
    /// </summary>
    public partial class OperationsOnMailWindow : Window
    {
        HelpQuery helpQuery = new HelpQuery();
        public OperationsOnMailWindow(string name)
        {
            InitializeComponent();
            MailTextBox.Text+= helpQuery.Operations("new&name=" + name);
        }

        private void ListOfEmailsButton_Click(object sender, RoutedEventArgs e)
        {
            MailTextBox.Text += helpQuery.Operations("getlist&key=" + helpQuery.key)+"\n";
        }

        private void LifetimeButton_Click(object sender, RoutedEventArgs e)
        {
            MailTextBox.Text += helpQuery.Operations("livetime&key=" + helpQuery.key) + "сек\n";
        }

        private void LifeTimeMinButton_Click(object sender, RoutedEventArgs e)
        {
            helpQuery.Operations("update&key=" + helpQuery.key);

        }

        private void RemoveEmailButton_Click(object sender, RoutedEventArgs e)
        {
            helpQuery.Operations("delete&key=" + helpQuery.key);
            CreateMailWindow createMailWindow = new CreateMailWindow();
            createMailWindow.Show();
            this.Close();
        }

        private void ClearEmailButton_Click(object sender, RoutedEventArgs e)
        {
            helpQuery.Operations("clear&key=" + helpQuery.key);
        }

        private void RemoveAllEmailButton_Click(object sender, RoutedEventArgs e)
        {
            helpQuery.Operations("deleteall");
            CreateMailWindow createMailWindow = new CreateMailWindow();
            createMailWindow.Show();
            this.Close();
        }

        private void MessageTextButton_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                MailTextBox.Text += helpQuery.Operations("getlist&key=" + helpQuery.key + "&id=" + IdTextBox.Text) + "\n";
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            CreateMailWindow createMailWindow = new CreateMailWindow();
            createMailWindow.Show();
            this.Close();
        }
        private bool Check()
        {
            int a;
            if (!int.TryParse(IdTextBox.Text, out a))
            {
                MessageBox.Show("Укажите Id");
                return false;
            }
            else
                return true;

        }
    }
}
