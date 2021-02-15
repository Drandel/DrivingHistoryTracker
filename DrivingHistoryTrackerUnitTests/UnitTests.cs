using DrivingHistoryTracker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace DrivingHistoryTrackerUnitTests
{
    [TestClass]
    public class DriverUnitTests
    {
        readonly string ExpectedName = "Elon";
        [TestMethod]
        public void TestDriverClassConstruction()
        {
            Driver driver = new Driver("Elon");
            Assert.AreEqual(ExpectedName, driver.Name);
        }

        readonly int ExpectPostTripLength = 1;
        [TestMethod]
        public void TestPurgeTrips()
        {
            Driver driver = new Driver("Elon");
            Trip trip1 = new Trip("Elon", "9:18", "15:48", "620");
            Trip trip2 = new Trip("Elon", "7:00", "7:01", "620");
            Trip trip3 = new Trip("Elon", "0:01", "23:59", "10");
            List<Trip> Trips = new List<Trip>() { trip1, trip2, trip3 };
            driver.Trips = Trips;
            Assert.AreEqual(ExpectPostTripLength, driver.Trips.Count);
        }

        readonly double ExpectedTotalMilesDriven = 540;
        [TestMethod]
        public void TestTotalMilesDrivenCalculation()
        {
            Driver driver = new Driver("Elon");
            Trip trip1 = new Trip("Elon", "9:15", "10:45", "80");
            Trip trip2 = new Trip("Elon", "7:00", "8:00", "60");
            Trip trip3 = new Trip("Elon", "10:30", "15:45", "400");
            List<Trip> Trips = new List<Trip>() { trip1, trip2, trip3 };
            driver.Trips = Trips;
            Assert.AreEqual(ExpectedTotalMilesDriven, driver.TotalMilesDriven);
        }

        readonly double ExpectedTotalMilesDrivenNotRoundedUp = 540.77;
        readonly double ExpectedTotalMilesDrivenRoundedUp = 541;
        [TestMethod]
        public void TestTotalMilesDrivenRoundedUp()
        {
            Driver driver = new Driver("Elon");
            Trip trip1 = new Trip("Elon", "9:15", "10:45", "80.25");
            Trip trip2 = new Trip("Elon", "7:00", "8:00", "60.33");
            Trip trip3 = new Trip("Elon", "10:30", "15:45", "400.19");
            List<Trip> Trips = new List<Trip>() { trip1, trip2, trip3 };
            driver.Trips = Trips;
            Assert.AreEqual(ExpectedTotalMilesDrivenNotRoundedUp, driver.TotalMilesDriven);
            double RoundedTotalMilesDriven = DrivingReportGenerator.Round(driver.TotalMilesDriven);
            Assert.AreEqual(ExpectedTotalMilesDrivenRoundedUp, RoundedTotalMilesDriven);
        }

        readonly double ExpectedTotalMilesDrivenNotRoundedDown = 540.30;
        readonly double ExpectedTotalMilesDrivenRoundedDown = 540;
        [TestMethod]
        public void TestTotalMilesDrivenRoundedDown()
        {
            Driver driver = new Driver("Elon");
            Trip trip1 = new Trip("Elon", "9:15", "10:45", "80.1");
            Trip trip2 = new Trip("Elon", "7:00", "8:00", "60.01");
            Trip trip3 = new Trip("Elon", "10:30", "15:45", "400.19");
            List<Trip> Trips = new List<Trip>() { trip1, trip2, trip3 };
            driver.Trips = Trips;
            Assert.AreEqual(ExpectedTotalMilesDrivenNotRoundedDown, driver.TotalMilesDriven);
            double RoundedTotalMilesDriven = DrivingReportGenerator.Round(driver.TotalMilesDriven);
            Assert.AreEqual(ExpectedTotalMilesDrivenRoundedDown, RoundedTotalMilesDriven);
        }

        readonly double ExpectedTotalDrivingTime = 7.75;
        [TestMethod]
        public void TestTotalDrivingTimeCalculation()
        {
            Driver driver = new Driver("Elon");
            Trip trip1 = new Trip("Elon", "9:15", "10:45", "80");
            Trip trip2 = new Trip("Elon", "7:00", "8:00", "60");
            Trip trip3 = new Trip("Elon", "10:30", "15:45", "400");
            List<Trip> Trips = new List<Trip>() { trip1, trip2, trip3 };
            driver.Trips = Trips;
            Assert.AreEqual(ExpectedTotalDrivingTime, driver.TotalDrivingTime);
        }

        readonly double ExpectedTotalDrivingTimeNotRoundedUp = 7.75;
        readonly double ExpectedTotalDrivingTimeRoundedUp = 8;
        [TestMethod]
        public void TestTotalDrivingTimeRoundedUp()
        {
            Driver driver = new Driver("Elon");
            Trip trip1 = new Trip("Elon", "9:15", "10:45", "80");
            Trip trip2 = new Trip("Elon", "7:00", "8:00", "60");
            Trip trip3 = new Trip("Elon", "10:30", "15:45", "400");
            List<Trip> Trips = new List<Trip>() { trip1, trip2, trip3 };
            driver.Trips = Trips;
            Assert.AreEqual(ExpectedTotalDrivingTimeNotRoundedUp, driver.TotalDrivingTime);
            double RoundedTotalDrivingTime = DrivingReportGenerator.Round(driver.TotalDrivingTime);
            Assert.AreEqual(ExpectedTotalDrivingTimeRoundedUp, RoundedTotalDrivingTime);

        }

        readonly double ExpectedTotalDrivingTimeNotRoundedDown = 7.25;
        readonly double ExpectedTotalDrivingTimeRoundedDown = 7;
        [TestMethod]
        public void TestTotalDrivingTimeRoundedDown()
        {
            Driver driver = new Driver("Elon");
            Trip trip1 = new Trip("Elon", "9:15", "10:15", "80");
            Trip trip2 = new Trip("Elon", "7:00", "8:00", "60");
            Trip trip3 = new Trip("Elon", "10:30", "15:45", "400");
            List<Trip> Trips = new List<Trip>() { trip1, trip2, trip3 };
            driver.Trips = Trips;
            Assert.AreEqual(ExpectedTotalDrivingTimeNotRoundedDown, driver.TotalDrivingTime);
            double RoundedTotalDrivingTime = DrivingReportGenerator.Round(driver.TotalDrivingTime);
            Assert.AreEqual(ExpectedTotalDrivingTimeRoundedDown, RoundedTotalDrivingTime);
        }

        readonly double ExpectedAverageSpeed = 69.6774193548387;
        [TestMethod]
        public void TestGetAverageSpeedCalculation()
        {
            Driver driver = new Driver("Elon");
            Trip trip1 = new Trip("Elon", "9:15", "10:45", "80");
            Trip trip2 = new Trip("Elon", "7:00", "8:00", "60");
            Trip trip3 = new Trip("Elon", "10:30", "15:45", "400");
            List<Trip> Trips = new List<Trip>() { trip1, trip2, trip3 };
            driver.Trips = Trips;
            Assert.AreEqual(ExpectedAverageSpeed, driver.GetAverageSpeed());
        }

        readonly double ExpectedAverageSpeedNotRoundedUp = 69.6774193548387;
        readonly double ExpectedAverageSpeedRoundedUp = 70;
        [TestMethod]
        public void TestGetAverageSpeedRounedUp()
        {
            Driver driver = new Driver("Elon");
            Trip trip1 = new Trip("Elon", "9:15", "10:45", "80");
            Trip trip2 = new Trip("Elon", "7:00", "8:00", "60");
            Trip trip3 = new Trip("Elon", "10:30", "15:45", "400");
            List<Trip> Trips = new List<Trip>() { trip1, trip2, trip3 };
            driver.Trips = Trips;
            Assert.AreEqual(ExpectedAverageSpeedNotRoundedUp, driver.GetAverageSpeed());
            double RoundedAverageSpeed = DrivingReportGenerator.Round(driver.GetAverageSpeed());
            Assert.AreEqual(ExpectedAverageSpeedRoundedUp, RoundedAverageSpeed);

        }

        readonly double ExpectedAverageSpeedNotRoundedDown = 69.41935483870968;
        readonly double ExpectedAverageSpeedRoundedDown = 69;
        [TestMethod]
        public void TestGetAverageSpeedRounedDown()
        {
            Driver driver = new Driver("Elon");
            Trip trip1 = new Trip("Elon", "9:15", "10:45", "80");
            Trip trip2 = new Trip("Elon", "7:00", "8:00", "60");
            Trip trip3 = new Trip("Elon", "10:30", "15:45", "398");
            List<Trip> Trips = new List<Trip>() { trip1, trip2, trip3 };
            driver.Trips = Trips;
            Assert.AreEqual(ExpectedAverageSpeedNotRoundedDown, driver.GetAverageSpeed());
            Console.WriteLine(driver.GetAverageSpeed());
            double RoundedAverageSpeed = DrivingReportGenerator.Round(driver.GetAverageSpeed());
            Assert.AreEqual(ExpectedAverageSpeedRoundedDown, RoundedAverageSpeed);
        }
    }

    [TestClass]
    public class TripUnitTests
    {
        readonly string ExpectedTripStart = "9:18";
        readonly string ExpectedTripEnd = "15:48";
        readonly double ExpectedMilesDriven = 620;
        [TestMethod]
        public void TestTripClassConstruction()
        {
            Trip trip = new Trip("Elon","9:18", "15:48", "620");
            Assert.AreEqual(ExpectedTripStart, trip.TripStart);
            Assert.AreEqual(ExpectedTripEnd, trip.TripEnd);
            Assert.AreEqual(ExpectedMilesDriven, trip.MilesDriven);
        }

        readonly double ExpectedDuration = 0.5;
        [TestMethod]
        public void TestTripDurationCalculation()
        {
            Trip trip = new Trip("Elon","7:30", "8:00", "25");
            Assert.AreEqual(ExpectedDuration, trip.TripDuration);
        }

        readonly double ExpectedSpeed = 50;
        [TestMethod]
        public void TestGetTripSpeedCalculation()
        {
            Trip trip = new Trip("Elon", "7:30", "8:00", "25");
            Assert.AreEqual(ExpectedSpeed, trip.TripSpeed);
        }

        [TestMethod]
        public void TestParseDoubleFromStringMilesDriven()
        {
            Trip trip = new Trip("Elon", "7:30", "8:00", "25");
            Assert.IsInstanceOfType(trip.MilesDriven, typeof(double));
        }

        [TestMethod]
        public void TestGetTripSpeedReturnsDouble()
        {
            Trip trip = new Trip("Elon", "7:30", "8:00", "25");
            Assert.IsInstanceOfType(trip.TripSpeed, typeof(double));
        }

        [TestMethod]
        public void TestGetTripDurationReturnsDouble()
        {
            Trip trip = new Trip("Elon", "7:30", "8:00", "25");
            Assert.IsInstanceOfType(trip.TripDuration, typeof(double));
        }

    }

    [TestClass]
    public class DrivingReportGeneratorUnitTests
    {
        readonly string ExpectedOutput = string.Format("Lauren: 42 miles @ 34 mph{0}Dan: 39 miles @ 47 mph{0}Kumi: 0 miles{0}", Environment.NewLine);
        [TestMethod]
        public void TestGenerateReport()
        {
            using (StringWriter sw = new StringWriter())
            {
                string[] data = { "Driver Dan", "Driver Lauren", "Driver Kumi", "Trip Dan 07:15 07:45 17.3", "Trip Dan 06:12 06:32 21.8", "Trip Lauren 12:01 13:16 42.0" };
                Console.SetOut(sw);
                DrivingReportGenerator drg = new DrivingReportGenerator(data);
                drg.GenerateReport();
                Assert.AreEqual(ExpectedOutput.Trim(), sw.ToString().Trim());
            }
        }

        readonly string ExpectedPreSortFirstDriver = "Elon";
        readonly string ExpectedPostSortFirstDriver = "Jeff";
        [TestMethod]
        public void TestSortDrivers()
        {
            string[] data = { "Driver Elon", "Driver Jeff", "Trip Elon 9:00 12:00 120", "Trip Elon 7:30 8:00 25", "Trip Jeff 9:18 15:48 620" };
            DrivingReportGenerator drg = new DrivingReportGenerator(data);
            Assert.AreEqual(ExpectedPreSortFirstDriver, drg.Drivers[0].Name);
            drg.GenerateReport();
            Assert.AreEqual(ExpectedPostSortFirstDriver, drg.Drivers[0].Name);
        }

        [TestMethod]
        public void TestMatchTripsToDrivers()
        {
            string[] data = { "Driver Elon", "Driver Jeff", "Driver Buzz", "Trip Elon 9:00 12:00 120", "Trip Buzz 12:00 6:15 350", "Trip Elon 7:30 8:00 25", "Trip Jeff 9:18 15:48 620"};
            DrivingReportGenerator drg = new DrivingReportGenerator(data);
            foreach (Driver driver in drg.Drivers)
            {
                foreach (Trip trip in driver.Trips)
                {
                    Assert.AreEqual(driver.Name, trip.DriverName); 
                }
            }
        }
    }

    [TestClass]
    public class FileParserUnitTests
    {
        readonly int ExpectedTripDataLength = 2;
        [TestMethod]
        public void TestParseTripData()
        {
            string[] data = { "Driver Elon", "Driver Jeff", "Driver Buzz", "Trip Elon 7:30 8:00 25", "Trip Jeff 9:18 15:48 620" };
            List<Trip> TripData = FileParser.ParseTripData(data);
            Assert.AreEqual(ExpectedTripDataLength, TripData.Count);
            Assert.IsInstanceOfType(TripData[0], typeof(Trip));
        }

        readonly int ExpectedDriverDataLength = 3;
        [TestMethod]
        public void TestParseDriverData()
        {
            string[] data = { "Driver Elon", "Driver Jeff", "Driver Buzz", "Trip Elon 7:30 8:00 25", "Trip Jeff 9:18 15:48 620"};
            List<Driver> DriverData = FileParser.ParseDriverData(data);
            Assert.AreEqual(ExpectedDriverDataLength, DriverData.Count);
            Assert.IsInstanceOfType(DriverData[0], typeof(Driver));
        }
    }
}
