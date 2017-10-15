using System.Windows;
using System.Windows.Controls;

namespace TestTask.Ui.Frames
{
    /// <summary>
    /// BracketChecker.xaml
    /// </summary>
    public partial class BracketChecker : Page
    {
        public BracketChecker()
        {
            InitializeComponent();
        }
        private void PointsError(object sender, ValidationErrorEventArgs e)
        {
            ErrorBlock.Visibility = Visibility.Visible;
            ErrorBlock.Text = e.Error.ErrorContent.ToString();
        }

        private void ErrorBlock_OnGotFocus(object sender, RoutedEventArgs e)
        {
            ErrorBlock.Visibility = Visibility.Collapsed;
        }
    }
}
