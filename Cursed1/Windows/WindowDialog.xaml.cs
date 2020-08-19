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

namespace Cursed1
{
    /// <summary>
    /// Логика взаимодействия для WindowDialog.xaml
    /// </summary>
    public partial class WindowDialog : Window
    {
        private const string login = "Qwerty43";
        private const string password = "admin";

        public WindowDialog()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Autorization_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckLoginPassword())
                MessageBox.Show("Incorrect login or password");
            else
                this.DialogResult = true;
        }

        private bool CheckLoginPassword()
        {
            if ((Login.Text ?? "").Equals(login) && (Password.Password ?? "").Equals(password))
                return true;
            return false;
        }
    }
}
