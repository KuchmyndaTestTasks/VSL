using TestTask.BracketChecker.Bracket;

namespace TestTask.BracketChecker.Helpers
{
    /// <summary>
    /// Додаткові можливості
    /// </summary>
    public static class ExpressionChecker
    {
        /// <summary>
        /// Перевірка на символи
        /// </summary>
        /// <param name="bracket">Дужка</param>
        /// <param name="c">Символ</param>
        /// <returns></returns>
        public static bool IsEquals(this Brackets bracket, char c)
        {
            return (int) bracket == c;
        }
        /// <summary>
        /// Шаблонний метод для визначення підвиразу у залежності від дужки
        /// </summary>
        /// <param name="c">Символ з дужкою</param>
        /// <returns></returns>
        public static BracketExpression CreateExpression(char c)
        {
            if (Brackets.StartBracket.IsEquals(c))
            {
                return new SimpleBracketExpression();
            }
            if (Brackets.StartQuadBracket.IsEquals(c))
            {
                return new QuadBracketExpression();
            }
            return null;
        }
    }
}