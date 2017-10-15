using System.Collections.Generic;
using System.Diagnostics;

namespace TestTask.ChessTask
{
    /// <summary>
    /// Фігура коня
    /// </summary>
    public class HorseFigure : ChessFigure
    {
        /// <summary>
        /// Фігура коня
        /// </summary>
        public HorseFigure(int row, int col) : base(row, col)
        {
        }
        /// <inheritdoc />
        /// <summary>
        /// Фігура коня
        /// </summary>
        public HorseFigure((int row, int col) point) : this(point.row, point.col)
        {
        }
        public override int NextWay(ChessFigure toFigure)
        {
            int steps = int.MaxValue;
            NextWay(this, this, toFigure);
            if (steps == int.MaxValue)
            {
                var swaped = (HorseFigure) toFigure;
                NextWay(swaped, swaped, this);
            }
            return steps == int.MaxValue ? -1 : steps;

            
            // Локальна рекурсивна функція пошуку наступного ходу (поточна точка, початкова точка, кінцева точка)
            void NextWay(HorseFigure currentPoint, ChessFigure mainPoint, ChessFigure endPoint)
            {
                if (endPoint.CurrentPosition.row == currentPoint.CurrentPosition.row &&
                    endPoint.CurrentPosition.col == currentPoint.CurrentPosition.col)
                {
                    var count = currentPoint.PreviousCounter(mainPoint.CurrentPosition);
                    if (steps > count)
                    {
                        steps = count;
                    }
                    return;
                }
                //Визначення напрямків ходів за годинниковим ходом
                var availableWays = new Queue<(int row, int col)?>
                {
                    currentPoint.NorthEastHorse(),
                    currentPoint.EastNorthHorse(),
                    currentPoint.EastSouthHorse(),
                    currentPoint.SouthEastHorse(),
                    currentPoint.SouthWestHorse(),
                    currentPoint.WestNorthHorse(),
                    currentPoint.WestSouthHorse(),
                    currentPoint.NorthWestHorse()
                };
                foreach (var way in availableWays)
                {
                    Debug.Assert(way != null, $"{nameof(way)} != null");
                    if (!currentPoint.HasPrevious(way.Value))
                    {
                        var next = new HorseFigure(way.Value.row, way.Value.col) {Previous = currentPoint};
                        NextWay(next, mainPoint, endPoint);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        #region Directions

        private (int row, int col)? NorthWestHorse()
        {
            int x = CurrentPosition.row - 1;
            int y = CurrentPosition.col - 2;

            if (x < 'a' || y < 1)
            {
                return null;
            }
            return (x, y);
        }

        private (int row, int col)? NorthEastHorse()
        {
            int x = CurrentPosition.row + 1;
            int y = CurrentPosition.col - 2;

            if (x > 'h' || y < 1)
            {
                return null;
            }
            return (x, y);
        }

        private (int row, int col)? EastNorthHorse()
        {
            int x = CurrentPosition.row + 2;
            int y = CurrentPosition.col - 1;

            if (x > 'h' || y < 1)
            {
                return null;
            }
            return (x, y);
        }

        private (int row, int col)? EastSouthHorse()
        {
            int x = CurrentPosition.row + 2;
            int y = CurrentPosition.col + 1;

            if (x > 'h' || y > 8)
            {
                return null;
            }
            return (x, y);
        }

        private (int row, int col)? SouthEastHorse()
        {
            int x = CurrentPosition.row + 1;
            int y = CurrentPosition.col + 2;

            if (x > 'h' || y > 8)
            {
                return null;
            }
            return (x, y);
        }

        private (int row, int col)? SouthWestHorse()
        {
            int x = CurrentPosition.row - 1;
            int y = CurrentPosition.col + 2;

            if (x < 'a' || y > 8)
            {
                return null;
            }
            return (x, y);
        }

        private (int row, int col)? WestSouthHorse()
        {
            int x = CurrentPosition.row - 2;
            int y = CurrentPosition.col + 1;

            if (x < 'a' || y > 8)
            {
                return null;
            }
            return (x, y);
        }

        private (int row, int col)? WestNorthHorse()
        {
            int x = CurrentPosition.row - 2;
            int y = CurrentPosition.col - 1;

            if (x < 'a' || y < 1)
            {
                return null;
            }
            return (x, y);
        }

        #endregion
    }
}