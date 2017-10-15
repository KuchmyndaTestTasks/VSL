using System;
using System.Linq;
using TestTask.NestedArraySum;
using TestTask.Ui.Helpers;

namespace TestTask.Ui.ViewModels
{
    public class NestedArrayCheckerViewModel : ViewModelBase
    {
        #region Fields & Properties

        private int[] _array;

        /// <summary>
        /// Вхідний/Вихідний масив, визначений ArrayConverter
        /// </summary>
        public int[] Array
        {
            get => _array;
            set
            {
                if (value == null || !value.Any())
                {
                    throw new ArgumentException("Empty array");
                }
                _array = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public NestedArrayCheckerViewModel()
        {
            CheckCommand = new Command(CheckExpression);
            Array = new []{0};
        }

        #region Methods

        private void CheckExpression()
        {
            NestedArrayCalculator calculator = new NestedArrayCalculator();
            Array = calculator.NestedArraySum(_array);
        }

        #endregion
    }
}