namespace TestTask.ChessTask
{
    public abstract class ChessFigure
    {
        public (int row, int col) CurrentPosition { get; set; }

        /// <summary>
        /// Батько/попередній хід у формі однонаправленого списку.
        /// </summary>
        public ChessFigure Previous { get; set; }

        /// <summary>
        /// Перевірка, чи входить точка у історії ходів
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        protected bool HasPrevious((int row, int col) figure)
        {
            if (figure.col == CurrentPosition.col && figure.row == CurrentPosition.row)
            {
                return true;
            }
            return Previous != null && Previous.HasPrevious(figure);
        }

        /// <summary>
        /// Обрахунок к-сті кроків від початку
        /// </summary>
        /// <param name="tuple"></param>
        /// <returns></returns>
        protected int PreviousCounter((int row, int col) tuple)
        {
            if (Previous == null)
            {
                return 0;
            }
            if (Previous.CurrentPosition.row == tuple.row && Previous.CurrentPosition.col == tuple.col)
            {
                return 1;
            }
            return Previous.PreviousCounter(tuple) + 1;
        }

        protected ChessFigure(int row, int col)
        {
            CurrentPosition = (row, col);
        }

        /// <summary>
        /// Хід
        /// </summary>
        /// <param name="toFigure">Куди йти</param>
        /// <returns></returns>
        public abstract int NextWay(ChessFigure toFigure);
    }
}