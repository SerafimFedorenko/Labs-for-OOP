using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    /// <summary>
    /// Класс, содержащий пробег машины, проверки технического состояния и меторды над ними
    /// </summary>
    public class Car
    {
        private List<Inspection> inspections = new List<Inspection>();
        private List<Mileage> mileages = new List<Mileage>();
        /// <summary>
        /// Свойство - список проверок состояния автомобиля
        /// </summary>
        public List<Inspection> Inspections { get => inspections; set => inspections = value; }
        /// <summary>
        /// Свойство - пробеги автомобиля
        /// </summary>
        public List<Mileage> Mileages { get => mileages; set => mileages = value; }
        /// <summary>
        /// Конструктор, создающий машину с пустыми списками пробегов и проверок
        /// </summary>
        public Car()
        {
            Inspections = new List<Inspection>();
            Mileages = new List<Mileage>();
        }
        /// <summary>
        /// Конструктор, создающий машину с пустым списком пробегов и заполняет список проверок
        /// </summary>
        /// <param name="inspections"></param>
        public Car(List<Inspection> inspections)
        {
            this.Inspections = inspections;
            Mileages = new List<Mileage>();
        }
        /// <summary>
        /// Конструктор, создающий машину с пустым списком проверок и заполняет список пробегов
        /// </summary>
        /// <param name="mileages"></param>
        public Car(List<Mileage> mileages)
        {
            Inspections = new List<Inspection>();
            this.Mileages = mileages;
        }
        /// <summary>
        /// Конструктор, создающий машину, заполняет список проверок и список пробегов
        /// </summary>
        /// <param name="mileages"></param>
        /// <param name="inspections"></param>
        public Car(List<Mileage> mileages, List<Inspection> inspections)
        {
            this.Inspections = inspections;
            this.Mileages = mileages;
        }
        /// <summary>
        /// Метод, возвращающий пробег за указанный период 
        /// </summary>
        /// <param name="timeStart"></param>
        /// <param name="timeFinish"></param>
        /// <returns></returns>
        public double GetMileageForPeriod(DateTime timeStart, DateTime timeFinish)
        {
            double distance = 0;
            foreach (Mileage mileage in Mileages)
            {
                if (mileage.timeStart > timeStart && mileage.timeFinish < timeFinish)
                {
                    distance += mileage.distance;
                }
            }
            return distance;
        }
        /// <summary>
        /// Метод, возвращающий список проверок определённого типа
        /// </summary>
        /// <param name="typeOfInspection"></param>
        /// <returns></returns>
        private List<Inspection> GetInspectionsForType(TypeOfInspection typeOfInspection)
        {
            List<Inspection> listOfInspeections = new List<Inspection>();
            foreach (Inspection inspection in Inspections)
            {
                if (inspection.TypeOfInspection == typeOfInspection)
                {
                    listOfInspeections.Add(inspection);
                }
            }
            return listOfInspeections;
        }
        /// <summary>
        /// Метод, возвращающий список времени проведения проверок определённого типа
        /// </summary>
        /// <param name="inspections"></param>
        /// <returns></returns>
        private List<DateTime> GetTimesOfInspections(List<Inspection> inspections)
        {
            List<DateTime> timesOfInspections = new List<DateTime>();
            foreach (Inspection inspection in inspections)
            {
                timesOfInspections.Add(inspection.timeOfInspection);
            }
            return timesOfInspections;
        }
        /// <summary>
        /// Метод, сортирующий список дат
        /// </summary>
        /// <param name="dateTimes"></param>
        /// <returns></returns>
        private List<DateTime> SortTimes(List<DateTime> dateTimes)
        {
            DateTime temp;
            for (int i = 0; i < dateTimes.Count - 1; i++)
            {
                for (int j = i + 1; j < dateTimes.Count; j++)
                {
                    if (dateTimes[i] > dateTimes[j])
                    {
                        temp = dateTimes[i];
                        dateTimes[i] = dateTimes[j];
                        dateTimes[j] = temp;
                    }
                }
            }
            return dateTimes;
        }
        /// <summary>
        /// Метод, считающий средний пробег междуу подкачками шин
        /// </summary>
        /// <returns></returns>
        public double GetAverageMileageBetweenTireInflations()
        {
            List<Inspection> tireInflations = GetInspectionsForType(TypeOfInspection.TireInflation);
            List<DateTime> datesOfTiteInflations = GetTimesOfInspections(tireInflations);
            List<DateTime> datesOfTiteInflationsSorted = SortTimes(datesOfTiteInflations);
            double averageMileage = 0;
            for (int i = 1; i < datesOfTiteInflationsSorted.Count; i++)
            {
                averageMileage += GetMileageForPeriod(datesOfTiteInflationsSorted[i - 1], datesOfTiteInflationsSorted[i]);
            }
            return averageMileage / (GetQuantityOfInspection(TypeOfInspection.TireInflation) - 1);
        }
        /// <summary>
        /// Метод, возвращающий количество проверок определённого типа
        /// </summary>
        /// <param name="typeOfInspection"></param>
        /// <returns></returns>
        private int GetQuantityOfInspection(TypeOfInspection typeOfInspection)
        {
            int quantity = 0;
            foreach (Inspection inspection in Inspections)
            {
                if (inspection.TypeOfInspection == typeOfInspection)
                {
                    quantity++;
                }
            }
            return quantity;
        }
        /// <summary>
        /// Метод, вычисляющий количество введённого промежутка времени между датами
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        private double GetQuantityOfPeriods(TimeSpan period)
        {
            List<DateTime> timeOfInspections = GetTimesOfInspections(Inspections);
            List<DateTime> timeOfInspectionsSorted = SortTimes(timeOfInspections);
            TimeSpan allTime = timeOfInspectionsSorted[timeOfInspectionsSorted.Count - 1] - timeOfInspectionsSorted[0];
            return allTime.TotalMilliseconds / period.TotalMilliseconds;
        }
        /// <summary>
        /// Метод, возвращающий словарь среднее количество проверок каждого типа за определённый период
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public Dictionary<TypeOfInspection, double> GetAverageQuantityOfInspections(TimeSpan period)
        {
            Dictionary<TypeOfInspection, double> averageQuantities = new Dictionary<TypeOfInspection, double>()
            {
                {
                    TypeOfInspection.OilLevel, GetQuantityOfInspection(TypeOfInspection.OilLevel) / GetQuantityOfPeriods(period)
                },
                {
                    TypeOfInspection.WasherWaterLevel, GetQuantityOfInspection(TypeOfInspection.WasherWaterLevel) / GetQuantityOfPeriods(period)
                },
                {
                    TypeOfInspection.TireInflation, GetQuantityOfInspection(TypeOfInspection.TireInflation) / GetQuantityOfPeriods(period)
                }
            };
            return averageQuantities;
        }
    }
}
