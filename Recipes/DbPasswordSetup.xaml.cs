using System.Windows;

namespace Recipes
{
    public partial class DbPasswordSetup : Window
    {
        #region Result
        public static readonly DependencyProperty ResultProperty = DependencyProperty.Register("Result", typeof(MessageBoxResult), typeof(DbPasswordSetup), new FrameworkPropertyMetadata(MessageBoxResult.None));
        public MessageBoxResult Result
        {
            get { return (MessageBoxResult)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }
        #endregion
        public DbPasswordSetup()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default["DbPassword"] = txtPassword.Text;
            Properties.Settings.Default.Save();
            Result = MessageBoxResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Cancel;
            Close();
        }
    }
}