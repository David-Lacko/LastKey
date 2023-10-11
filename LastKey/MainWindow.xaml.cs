using LastKey.Backend;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace LastKey
{
    public partial class MainWindow : Window
    {
        SavePassword savePassword = new SavePassword();
        LoadPassword loadPassword = new LoadPassword();
        CheckFiles checkFiles = new CheckFiles();
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

                
                page1.setMPassword(Password.Password, (bool)old.IsChecked);
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
        public void Enabled()
        {
            this.IsEnabled = true;
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
                Uri resourceUri = new Uri("Images/xeye.png", UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;

                Show.Background = brush;

            }
            else
            {
                Password.Password = PasswordShow.Text;
                Password.Visibility = Visibility.Visible;
                PasswordShow.Visibility = Visibility.Hidden;
                Uri resourceUri = new Uri("Images/eye.png", UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                var brush = new ImageBrush();
                brush.ImageSource = temp;

                Show.Background = brush;
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
            TestBlock.Visibility = Visibility.Visible;
            NewLogin.Visibility = Visibility.Visible;
            ProgresNewLogin.Visibility=Visibility.Visible;
            Uri resourceUri = new Uri("Images/topX.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            var brush = new ImageBrush();
            brush.ImageSource = temp;

            CheckBoxNewLogin.Background = brush;
        }


        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            AddNewLogin.Visibility = Visibility.Hidden;
            NewLogin.Visibility = Visibility.Hidden;
            TestBlock.Visibility=Visibility.Hidden;
            ProgresNewLogin.Visibility = Visibility.Hidden;
            Uri resourceUri = new Uri("Images/top.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            var brush = new ImageBrush();
            brush.ImageSource = temp;

            CheckBoxNewLogin.Background = brush;

        }

        private void Password_MouseEnter(object sender, MouseEventArgs e)
        {
            for( int i = 0; i <= 100; i++)
            {
                Progres.Value = i;
            }
        }

        private void Password_MouseLeave(object sender, MouseEventArgs e)
        {
            for (int i = 100 ; i >= 0; i--)
            {
                Progres.Value = i;
            }

        }

        private void Password_MouseEnter2(object sender, MouseEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                ProgresNewLogin.Value = i;
            }
        }

        private void Password_MouseLeave2(object sender, MouseEventArgs e)
        {
            for (int i = 100; i >= 0; i--)
            {
                ProgresNewLogin.Value = i;
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            checkFiles.checkFiles();
        }
    }
}
