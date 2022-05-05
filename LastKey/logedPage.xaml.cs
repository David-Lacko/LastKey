using LastKey.Backend;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace LastKey
{
    /// <summary>
    /// Interaction logic for logedPage.xaml
    /// </summary>
    public partial class LogedPage : Page
    {
        private int count;
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
        public void setMPassword(string masterPassword)
        {
            MPassword = masterPassword;
            pasvordLenght.ItemsSource = lenght;
            pasvordLenght.SelectedIndex = 3;
            passwords = loadPassword.LoadPasswords(MPassword);
            DataAdd();

        }
        private void DataAdd()
        {

            data.Items.Clear();

            foreach (KeyValuePair<string, string> password in passwords)
            {
                Data temporalData = new Data();
                temporalData.web = password.Key;
                temporalData.pass = password.Value;
                data.Items.Add(temporalData);

            }
            web.Text = "";
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
            count++;
            password = createPassword.GeneratePassword(selectedLenght);
            try
            {
                passwords.Add(web.Text, password);
                savePassword.SavePasswords(passwords, MPassword);
                DataAdd();

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
            if (row_list != null)
            {
                passwords.Remove(row_list.web);
            }
            savePassword.SavePasswords(passwords, MPassword);
            DataAdd();

        }

        private void data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            DataGrid dataGrid = (DataGrid)sender;
            row_list = (Data)data.SelectedItem;
            if (row_list != null)
            {
                Clipboard.SetText(row_list.pass);
            }
        }

        public class Item
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

    }
}
