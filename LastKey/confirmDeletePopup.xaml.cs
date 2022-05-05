using System.Windows;

namespace LastKey
{
    /// <summary>
    /// Interaction logic for confirmDeletePopup.xaml
    /// </summary>
    public partial class confirmDeletePopup : Window
    {
        public confirmDeletePopup()
        {
            InitializeComponent();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).DeletePassword();
            this.Close();

        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
