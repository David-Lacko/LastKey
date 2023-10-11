using LastKey.Backend;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace LastKey
{
    /// <summary>
    /// Interaction logic for logedPage.xaml
    /// </summary>
    public partial class LogedPage : Page
    {
        private readonly int[] lenght = { 15, 25, 50, 100 };
        private int selectedLenght;
        private string password;
        public Dictionary<string, string> passwords = new Dictionary<string, string>();
        CreatePassword createPassword = new CreatePassword();
        SavePassword savePassword = new SavePassword();
        LoadPassword loadPassword = new LoadPassword();
        private string MPassword = "12345";
        private Data row_list;
        public LogedPage()
        {
            InitializeComponent();

        }
        public void setMPassword(string masterPassword,bool old)
        {
            MPassword = masterPassword;
            pasvordLenght.ItemsSource = lenght;
            pasvordLenght.SelectedIndex = 3;

            if (old)
            {
                passwords = loadPassword.LoadPasswords(MPassword,old);

                savePassword.SavePasswords(passwords, MPassword);
            }
            else
            {
                passwords = loadPassword.LoadPasswords(MPassword);
            }
            DataAdd();

        }
        private void DataAdd()
        {

            data.Items.Clear();

            foreach (KeyValuePair<string, string> password in passwords)
            {
                Data temporalData = new Data();
                temporalData.web = password.Key;
                temporalData.pass = PasswordLength(password.Value);
                data.Items.Add(temporalData);

            }
            web.Text = "Type your Web here...";
            web.Foreground = Brushes.Gray;
            PasswordText.Text = "Type your Password here...";
            PasswordText.Foreground = Brushes.Gray;
        }
        private string PasswordLength( string value)
        {
            int[] array = new int[value.Length];
            string myString = new string('*', value.Length);
            return myString;

        }


        public class Data
        {
            public string web { get; set; }
            public string pass { get; set; }
        }

        private void pasvordLenght_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedLenght = (int)pasvordLenght.SelectedItem;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            password = createPassword.GeneratePassword(selectedLenght);
            var webText = "Name";
            if (web.Text != "Type your Web here...")
            {
                webText = web.Text;
            }
            try
            {
                if ((bool)MyPassword.IsChecked)
                {
                    if (PasswordText.Text != "" && PasswordText.Text != "Type your Password here...")
                    {
                        passwords.Add(webText, PasswordText.Text);
                        savePassword.SavePasswords(passwords, MPassword);
                        DataAdd();
                    }
                }
                else
                {
                    passwords.Add(webText, password);
                    savePassword.SavePasswords(passwords, MPassword);
                    DataAdd();
                }
                

            }
            catch (ArgumentException)
            {
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            confirmDeletePopup confirmPopup = new confirmDeletePopup();
            confirmPopup.Show();

        }

        public void DeletePassword()
        {
            row_list = (Data)data.SelectedItem;
            if (row_list != null)
            {
                passwords.Remove(row_list.web);
            }
            savePassword.SavePasswords(passwords, MPassword);
            DataAdd();

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Type your Web here..." || textBox.Text == "Type your Password here...")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "" && textBox.Name == "web")
            {
                textBox.Text = "Type your Web here...";
                textBox.Foreground = Brushes.Gray;
            }
            else if (textBox.Text == "" && textBox.Name == "PasswordText")
            {
                textBox.Text = "Type your Password here...";
                textBox.Foreground = Brushes.Gray;
            }
        }



        private void CopyButtonClick(object sender, RoutedEventArgs e)
        {
            row_list = (Data)data.SelectedItem;
            if (row_list != null)
            {
                foreach (KeyValuePair<string, string> password in passwords)
                {
                    if (password.Key == row_list.web)
                    {
                        Clipboard.SetText(password.Value);
                    }
                }
            }
        }


        public class Item
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PasswordText.Visibility = Visibility.Visible;
            pasvordLenght.Visibility = Visibility.Hidden;
            CustomPasswordLabel.Visibility = Visibility.Hidden;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordText.Visibility = Visibility.Hidden;
            pasvordLenght.Visibility = Visibility.Visible;
            CustomPasswordLabel.Visibility = Visibility.Visible;
        }

        private void Eye_Checked(object sender, RoutedEventArgs e)
        {
            data.Items.Clear();

            foreach (KeyValuePair<string, string> password in passwords)
            {
                Data temporalData = new Data();
                temporalData.web = password.Key;
                temporalData.pass = password.Value;
                data.Items.Add(temporalData);

            }
            Uri resourceUri = new Uri("Images/xeye.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            var brush = new ImageBrush();
            brush.ImageSource = temp;

            Eye.Background = brush;
        }

        private void Eye_Unchecked(object sender, RoutedEventArgs e)
        {
            data.Items.Clear();

            foreach (KeyValuePair<string, string> password in passwords)
            {
                Data temporalData = new Data();
                temporalData.web = password.Key;
                temporalData.pass = PasswordLength(password.Value);
                data.Items.Add(temporalData);

            }
            Uri resourceUri = new Uri("Images/eye.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            var brush = new ImageBrush();
            brush.ImageSource = temp;

            Eye.Background = brush;
        }
    }
}
