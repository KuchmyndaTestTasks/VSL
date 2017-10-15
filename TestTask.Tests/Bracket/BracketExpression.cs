using TestTask.BracketChecker.Helpers;

namespace TestTask.BracketChecker.Bracket
{
    public abstract class BracketExpression
    {
        private readonly Brackets _endBracket;
        private bool _isClosed;
        /// <summary>
        /// Загальний вираз
        /// </summary>
        /// <param name="endBracket"></param>
        protected BracketExpression(Brackets endBracket)
        {
            _endBracket = endBracket;
            _isClosed = false;
        }
        /// <summary>
        /// Закрити вираз
        /// </summary>
        /// <param name="c">Символ закритої дужки</param>
        /// <returns></returns>
        public bool Close(char c)
        {
            if (_endBracket.IsEquals(c))
            {
                _isClosed = true;                
            }
            return _isClosed;
        }
        /// <summary>
        /// Перевірка чи дужка відкрита
        /// </summary>
        /// <param name="c">Символ дужки</param>
        /// <returns></returns>
        public static bool IsOpenedBracket(char c) =>
            Brackets.StartBracket.IsEquals(c) || Brackets.StartQuadBracket.IsEquals(c);
        /// <summary>
        /// Перевірка чи дужка закрита
        /// </summary>
        /// <param name="c">Символ дужки</param>
        /// <returns></returns>
        public static bool IsClosedBracket(char c) =>
            Brackets.EndBracket.IsEquals(c) || Brackets.EndQuadBracket.IsEquals(c);        
    }
}
