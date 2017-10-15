using System.Collections.Generic;
using System.Linq;

namespace TestTask.ChessTask
{
    /// <summary>
    /// Шахова дошка NxN
    /// </summary>
    public class ChessField
    {
        private readonly List<ChessFigure> _chessFigures;

        public ChessField(int size)
        {
            _chessFigures = new List<ChessFigure>(size * 4);
        }

        /// <summary>
        /// Долучати фігуру до гри
        /// </summary>
        /// <param name="figure"></param>
        public void AddFigure(ChessFigure figure)
        {
            _chessFigures.Add(figure);
        }

        /// <summary>
        /// Зробити хід фігурою, яка присутня у грі
        /// </summary>
        /// <param name="figure">Існуюча фігура</param>
        /// <param name="otherFigure">Коодинати ходу/фігуру, котру необхідно убити</param>
        /// <returns></returns>
        public int Go(ChessFigure figure, ChessFigure otherFigure)
        {
            if (_chessFigures.Any(x => x == figure))
            {
                return figure.NextWay(otherFigure);
            }
            return -1;
        }
    }
}
