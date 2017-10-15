using NUnit.Framework;
using TestTask.BracketChecker;
using TestTask.ChessTask;
using TestTask.NestedArraySum;

namespace TestTasks.Tests
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void CheckExpression()
        {
            //string inputExpression = First();
            string inputExpression = Second();
            BracketChecker expression = new BracketChecker();
            Assert.True(expression.Check(inputExpression));

            string First() => "(1+([2]))*([((1+(3)))]-[4+5])";
            string Second() => "(1+2)*(3-[4+5)]";
        }

        [Test]
        public void NestedArraySum()
        {
            int[] array = First();
            //int[] array = Second();
            NestedArrayCalculator calculator = new NestedArrayCalculator();
            Assert.NotNull(calculator.NestedArraySum(array));

            int[] First() => new[] {-20, 10, -5, 1, 10, -20, 9};
            int[] Second() => new[] {-5, 3, 2, -6};
        }

        [Test]
        public void HorseWays()
        {
            ChessField chessField = new ChessField(8);
            ChessFigure figure = new HorseFigure('a', 1);
            chessField.AddFigure(figure);
            Assert.IsTrue(2 == chessField.Go(figure, new HorseFigure('c', 5)));
        }
    }
}