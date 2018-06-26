using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace FindAny.Helpers
{
    /// <summary>
    /// Класс с мелкими вспомогательными функциями
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// Возвращает таймер.
        /// ТАм где был вызван метод необходимо определить метод для тика таймера
        /// 
        /// void Timer_Tick(object sender, EventArgs e)
        /// {
        ///     //Тут логика.Будет происходить каждый тик
        /// }
        /// </summary>
        /// <param name="tickSize">Вермя тика таймера в милисекундах</param>
        /// <returns>DispatcherTimer</returns>
        public DispatcherTimer GameTimer(int tickSize) 
        {
            DispatcherTimer Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromMilliseconds(tickSize);
            return Timer;
        }
    }
}
