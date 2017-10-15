using System.Windows;
using System.Windows.Controls;

namespace TestTask.Ui.Frames
{
    /// <summary>
    /// NestedArray.xaml
    /// </summary>
    public partial class NestedArray : Page
    {
        public NestedArray()
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
