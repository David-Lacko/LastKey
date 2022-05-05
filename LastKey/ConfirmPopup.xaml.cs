using System.Windows;

namespace LastKey
{
    /// <summary>
    /// Interaction logic for ConfirmPopup.xaml
    /// </summary>
    public partial class ConfirmPopup : Window
    {
        public ConfirmPopup()
        {
            InitializeComponent();
        }


        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Save();
            this.Close();

        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
