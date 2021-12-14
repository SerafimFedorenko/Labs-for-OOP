using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary.Tests
{
    [TestClass()]
    public class CarTests
    {
        [TestMethod()]
        public void GetMileageForPeriodTest()
        {
            List<Mileage> mileages = new List<Mileage>();
            DateTime date1 = new DateTime(2020, 01, 10);
            DateTime date2 = new DateTime(2020, 01, 15);
            Mileage mileage = new Mileage(100, date1, date2);
            mileages.Add(mileage);
            date1 = new DateTime(2020, 01, 10);
            date2 = new DateTime(2020, 01, 15);
            mileage = new Mileage(100, date1, date2);
            mileages.Add(mileage);
            date1 = new DateTime(2020, 01, 17);
            date2 = new DateTime(2020, 01, 18);
            mileage = new Mileage(50, date1, date2);
            mileages.Add(mileage);
            date1 = new DateTime(2020, 01, 20);
            date2 = new DateTime(2020, 01, 24);
            mileage = new Mileage(200, date1, date2);
            mileages.Add(mileage);
            date1 = new DateTime(2020, 01, 26);
            date2 = new DateTime(2020, 01, 29);
            mileage = new Mileage(251, date1, date2);
            mileages.Add(mileage);
            Car car = new Car(mileages);
            date1 = new DateTime(2020, 01, 16);
            date2 = new DateTime(2020, 01, 25);
            double expMileage = 250;
            Assert.AreEqual(expMileage,car.GetMileageForPeriod(date1, date2));
        }

        [TestMethod()]
        public void GetAverageMileageBetweenTireInflationsTest()
        {
            List<Mileage> mileages = new List<Mileage>();
            DateTime date1 = new DateTime(2020, 01, 10);
            DateTime date2 = new DateTime(2020, 01, 15);
            Mileage mileage = new Mileage(100, date1, date2);
            mileages.Add(mileage);
            date1 = new DateTime(2020, 01, 10);
            date2 = new DateTime(2020, 01, 15);
            mileage = new Mileage(100, date1, date2);
            mileages.Add(mileage);
            date1 = new DateTime(2020, 01, 17);
            date2 = new DateTime(2020, 01, 18);
            mileage = new Mileage(50, date1, date2);
            mileages.Add(mileage);
            date1 = new DateTime(2020, 01, 20);
            date2 = new DateTime(2020, 01, 24);
            mileage = new Mileage(200, date1, date2);
            mileages.Add(mileage);
            date1 = new DateTime(2020, 01, 26);
            date2 = new DateTime(2020, 01, 30);
            mileage = new Mileage(250, date1, date2);
            mileages.Add(mileage);
            List<Inspection> inspections = new List<Inspection>();
            date1 = new DateTime(2020, 01, 16);
            Inspection inspection = new Inspection(TypeOfInspection.TireInflation, date1);
            inspections.Add(inspection);
            date1 = new DateTime(2020, 01, 19);
            inspection = new Inspection(TypeOfInspection.TireInflation, date1);
            inspections.Add(inspection);
            date1 = new DateTime(2020, 01, 25);
            inspection = new Inspection(TypeOfInspection.TireInflation, date1);
            inspections.Add(inspection);
            Car car = new Car(mileages, inspections);
            double expMileage = 125;
            Assert.AreEqual(expMileage, car.GetAverageMileageBetweenTireInflations());
        }

        [TestMethod()]
        public void GetAverageQuantityOfInspectionsTest()
        {
            List<Inspection> inspections = new List<Inspection>();
            DateTime date1 = new DateTime(2020, 01, 14);
            Inspection inspection = new Inspection(TypeOfInspection.WasherWaterLevel, date1);
            inspections.Add(inspection);
            date1 = new DateTime(2020, 01, 19);
            inspection = new Inspection(TypeOfInspection.TireInflation, date1);
            inspections.Add(inspection);
            date1 = new DateTime(2020, 01, 23);
            inspection = new Inspection(TypeOfInspection.WasherWaterLevel, date1);
            inspections.Add(inspection);
            date1 = new DateTime(2020, 01, 22);
            inspection = new Inspection(TypeOfInspection.WasherWaterLevel, date1);
            inspections.Add(inspection);
            date1 = new DateTime(2020, 01, 26);
            inspection = new Inspection(TypeOfInspection.OilLevel, date1);
            inspections.Add(inspection);
            date1 = new DateTime(2020, 01, 27);
            inspection = new Inspection(TypeOfInspection.WasherWaterLevel, date1);
            inspections.Add(inspection);
            date1 = new DateTime(2020, 01, 27);
            inspection = new Inspection(TypeOfInspection.TireInflation, date1);
            inspections.Add(inspection);
            date1 = new DateTime(2020, 01, 28);
            inspection = new Inspection(TypeOfInspection.OilLevel, date1);
            inspections.Add(inspection);
            date1 = new DateTime(2020, 01, 28);
            inspection = new Inspection(TypeOfInspection.TireInflation, date1);
            inspections.Add(inspection);
            Car car = new Car(inspections);
            TimeSpan period = new TimeSpan(7, 0, 0, 0, 0);
            Dictionary<TypeOfInspection, double> averageQuantities = car.GetAverageQuantityOfInspections(period);
            Assert.AreEqual(1.5, averageQuantities[TypeOfInspection.TireInflation]);
            Assert.AreEqual(1, averageQuantities[TypeOfInspection.OilLevel]);
            Assert.AreEqual(2, averageQuantities[TypeOfInspection.WasherWaterLevel]);
        }
    }
}