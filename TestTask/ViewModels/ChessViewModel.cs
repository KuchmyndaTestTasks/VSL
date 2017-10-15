using System;
using TestTask.ChessTask;
using TestTask.Ui.Helpers;

namespace TestTask.Ui.ViewModels
{
    public class ChessViewModel : ViewModelBase
    {
        #region Fields & Properties

        private ((char row, int col) first, (char row, int col) second) _points;
        private string _answer;

        /// <summary>
        /// Вхідні дані, визначених PointConverter
        /// </summary>
        public ((char row, int col) first, (char row, int col) second) Points
        {
            get => _points;
            set
            {
                _points = value;
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

        public ChessViewModel()
        {
            CheckCommand = new Command(CheckExpression);
        }

        #region Methods

        private void CheckExpression()
        {
            ChessField field = new ChessField(8);
            ChessFigure horse = new HorseFigure(Points.first);
            field.AddFigure(horse);
            Answer = field.Go(horse, new HorseFigure(Points.second)).ToString();
        }

        #endregion
    }
}
