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
using TemporaryMailApp.View;

namespace TemporaryMailApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class CreateMailWindow : Window
    {
        public CreateMailWindow()
        {
            InitializeComponent();
        }

        private void CreateMailButton_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                OperationsOnMailWindow operationsOnMailWindow = new OperationsOnMailWindow(NameMailTextBox.Text);
                operationsOnMailWindow.Show();
                this.Close();
            }
        }
        private bool Check()
        {
            if (NameMailTextBox.Text == "")
            {
                MessageBox.Show("Введите имя почты");
                return false;
            }
            else
                return true;

        }
    }
}
