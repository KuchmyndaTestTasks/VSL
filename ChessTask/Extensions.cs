using System.Collections.Generic;

namespace TestTask.ChessTask
{
    /// <summary>
    /// Розширені методи
    /// </summary>
    static class Extensions
    {
        /// <summary>
        /// Додавання до черги з перевіркою на NULL
        /// </summary>
        /// <typeparam name="T">тип</typeparam>
        /// <param name="queue">черга</param>
        /// <param name="item">елемент</param>
        public static void Add<T>(this Queue<T> queue, T item)
        {
            if (!Equals(item, default(T)))
            {
                queue.Enqueue(item);
            }
        }
    }
}