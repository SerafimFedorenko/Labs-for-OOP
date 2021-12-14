using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    /// <summary>
    /// Перечисление - тип проверки
    /// </summary>
    public enum TypeOfInspection
    {
        /// <summary>
        /// Подкачка шин
        /// </summary>
        TireInflation,
        /// <summary>
        /// Уровень масла
        /// </summary>
        OilLevel,
        /// <summary>
        /// Уровень воды в бочке омывателя
        /// </summary>
        WasherWaterLevel
    }
    /// <summary>
    /// Структура - проверка технического состояния автомобиля
    /// </summary>
    public struct Inspection
    {
        /// <summary>
        /// Тип проверки технического состояния автомобиля
        /// </summary>
        public TypeOfInspection TypeOfInspection;
        /// <summary>
        /// Дата проверки технического состояния автомобиля
        /// </summary>
        public DateTime timeOfInspection;
        /// <summary>
        /// Конструктор структуры Inspection
        /// </summary>
        /// <param name="typeOfInspection"></param>
        /// <param name="timeOfInspection"></param>
        public Inspection(TypeOfInspection typeOfInspection, DateTime timeOfInspection)
        {
            TypeOfInspection = typeOfInspection;
            this.timeOfInspection = timeOfInspection;
        }
        /// <summary>
        /// Метод, возвращающий строку в зависимости от типа проверки
        /// </summary>
        /// <returns></returns>
        public string TypeToString()
        {
            Dictionary<TypeOfInspection, string> types = new Dictionary<TypeOfInspection, string>()
            {
                {
                    TypeOfInspection.OilLevel, "проверка масла"
                },
                {
                    TypeOfInspection.TireInflation, "подкачка шин"
                },
                {
                    TypeOfInspection.WasherWaterLevel, "проверка уровня воды в бочке омывателя"
                }
            };
            return types[TypeOfInspection];
        }
    }
}
