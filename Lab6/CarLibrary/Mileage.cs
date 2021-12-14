using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    /// <summary>
    /// Структура - пробег автомобиля
    /// </summary>
    public struct Mileage
    {
        /// <summary>
        /// Дистанция пробега
        /// </summary>
        public double distance;
        /// <summary>
        /// Время старта пробега
        /// </summary>
        public DateTime timeStart;
        /// <summary>
        /// Время конца пробега
        /// </summary>
        public DateTime timeFinish;
        /// <summary>
        /// Конструктор структуры Mileage
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="timeStart"></param>
        /// <param name="timeFinish"></param>
        public Mileage(double distance, DateTime timeStart, DateTime timeFinish)
        {
            this.distance = distance;
            this.timeStart = timeStart;
            this.timeFinish = timeFinish;
        }
    }
}
