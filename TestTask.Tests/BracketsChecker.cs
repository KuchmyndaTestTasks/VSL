using System.Collections.Generic;
using TestTask.BracketChecker.Bracket;
using TestTask.BracketChecker.Helpers;

namespace TestTask.BracketChecker
{
    /// <summary>
    /// Клас перевірки виразу на дужки
    /// </summary>
    public class BracketChecker
    {
        private readonly Stack<BracketExpression> _bracketExpressions = new Stack<BracketExpression>();

        /// <summary>
        /// Перевірка виразу
        /// </summary>
        /// <param name="expression">Вхідний вираз</param>
        /// <returns></returns>
        public bool Check(string expression)
        {
            expression = $"({expression})";
            foreach (var letter in expression)
            {
                if (!Check(letter))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Перевірка виразу посимвольно через стек відкритих дужок
        /// </summary>
        /// <param name="letter">Символ</param>
        /// <returns></returns>
        private bool Check(char letter)
        {
            //Якщо це дужка ( чи [, то поміщуємо у стек
            if (BracketExpression.IsOpenedBracket(letter))
            {
                _bracketExpressions.Push(ExpressionChecker.CreateExpression(letter));
                return true;
            }
            //Якщо дужка ) чи ], то видаляємо з стеку, також закриваємо вираз
            if (BracketExpression.IsClosedBracket(letter))
            {
                var previous = _bracketExpressions.Peek();
                var res = previous.Close(letter);
                if (res)
                {
                    _bracketExpressions.Pop();
                }
                return res;
            }
            return true;
        }
    }
}