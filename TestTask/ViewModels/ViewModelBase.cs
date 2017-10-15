using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TestTask.Ui.Annotations;

namespace TestTask.Ui.ViewModels
{
    public class ViewModelBase:INotifyPropertyChanged
    {
        ICommand _checkCommand;

        public ICommand CheckCommand
        {
            get => _checkCommand;
            set
            {
                _checkCommand = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
