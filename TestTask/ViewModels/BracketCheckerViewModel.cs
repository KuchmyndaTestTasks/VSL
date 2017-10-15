using System;
using System.Linq;
using TestTask.Ui.Helpers;

namespace TestTask.Ui.ViewModels
{
    public class BracketCheckerViewModel : ViewModelBase
    {
        #region Fields & Properties

        private string _expression;
        private string _answer;

        /// <summary>
        /// Вхідний вираз, визначений ExpressionRule
        /// </summary>
        public string Expression
        {
            get => _expression;
            set
            {
                if (value == null || !value.Any())
                {
                    throw new ArgumentException("Empty expression");
                }
                _expression = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Результат команди
        /// </summary>
        public string Answer
        {
            get => _answer;
            set
            {
                _answer = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public BracketCheckerViewModel()
        {
            CheckCommand = new Command(CheckExpression);
        }

        #region Methods

        private void CheckExpression()
        {
            if (!string.IsNullOrEmpty(_expression))
            {
                BracketChecker.BracketChecker bracketChecker = new BracketChecker.BracketChecker();
                Answer = bracketChecker.Check(_expression) ? "Yes" : "No";
            }
        }

        #endregion
    }
}
