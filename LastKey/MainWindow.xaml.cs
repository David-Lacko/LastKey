using LastKey.Backend;
using System.Windows;
using System.Windows.Input;

namespace LastKey
{
    public partial class MainWindow : Window
    {
        SavePassword savePassword = new SavePassword();
        LoadPassword loadPassword = new LoadPassword();
        LogedPage page1 = new LogedPage();

        public MainWindow()
        {

            InitializeComponent();

        }
        private void Run_Click(object sender, RoutedEventArgs e)
        {
            if (Password.Visibility == Visibility.Hidden)
            {
                Password.Password = PasswordShow.Text;
            }
            if (loadPassword.LoadMPassword(Password.Password))
            {


                page1.setMPassword(Password.Password);
                this.Content = page1;
                Application.Current.MainWindow.Width = 800;
                Application.Current.MainWindow.Height = 500;
            }



        }

        private void NewLogin_Click(object sender, RoutedEventArgs e)
        {
            if (Password.Visibility == Visibility.Hidden)
            {
                Password.Password = PasswordShow.Text;
            }
            if (loadPassword.LoadMPassword(Password.Password))
            {
                ConfirmPopup confirmPopup = new ConfirmPopup();
                confirmPopup.Show();
                this.IsEnabled = false;

            }
        }
        public void Save()
        {
            if (Password.Visibility == Visibility.Hidden)
            {
                Password.Password = PasswordShow.Text;
            }
            if (loadPassword.LoadMPassword(Password.Password))
            {
                savePassword.SavePasswords(loadPassword.LoadPasswords(Password.Password), AddNewLogin.Text);

                savePassword.SaveMPassword(AddNewLogin.Text);
                Password.Password = AddNewLogin.Text;
                PasswordShow.Text = AddNewLogin.Text;
                AddNewLogin.Visibility = Visibility.Hidden;
                NewLogin.Visibility = Visibility.Hidden;
                AddNewLogin.Text = "";
                this.IsEnabled = true;
                CheckBoxNewLogin.IsChecked = false;
            }
        }
        public void DeletePassword()
        {
            page1.DeletePassword();

        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            if (Password.Visibility == Visibility.Visible)
            {
                PasswordShow.Text = Password.Password;
                Password.Visibility = Visibility.Hidden;
                PasswordShow.Visibility = Visibility.Visible;

            }
            else
            {
                Password.Password = PasswordShow.Text;
                Password.Visibility = Visibility.Visible;
                PasswordShow.Visibility = Visibility.Hidden;
            }
        }


        private void pressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Run_Click(this, new RoutedEventArgs());
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AddNewLogin.Visibility = Visibility.Visible;
            NewLogin.Visibility = Visibility.Visible;
        }


        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            AddNewLogin.Visibility = Visibility.Hidden;
            NewLogin.Visibility = Visibility.Hidden;
        }
    }
}
