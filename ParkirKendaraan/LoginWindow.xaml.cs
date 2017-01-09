using System;
using System.Windows;

namespace ParkirKendaraan
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            String username = txUserName.Text;
            String password = txPassword.Password;

            if(String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username atau Password kosong.", "Perhatian", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                LoadingWindow.DoWorkWithModal(progress =>
                {
                    bool result = Services.Instance.UserClient.IsUserExist(username, password);
                    if(result)
                    {
                        OnLoginSuccess();
                    }
                    else
                    {
                        OnLoginFailed();
                    }
                });
            }
        }

        private void OnLoginSuccess()
        {
            Application.Current.Dispatcher.Invoke((Action)delegate 
            {
                MainWindow main = new MainWindow();
                main.Show();
                Close();
            });
        }

        private void OnLoginFailed()
        {
            MessageBox.Show("Username atau Password tidak terdaftar.", "Perhatian", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }
}
