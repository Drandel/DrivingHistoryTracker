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
        [TestMethod]
        public void TestDriverClassConstruction()
        {
            const string ExpectedName = "Elon";

            Driver driver = new Driver("Elon");

            Assert.AreEqual(ExpectedName, driver.Name);
        }

        [TestMethod]
        public void TestPurgeTrips()
        {
            const int ExpectPostTripLength = 1;

            Driver driver = new Driver("Elon");
            Trip trip1 = new Trip("Elon", "9:18", "15:48", "620");
            Trip trip2 = new Trip("Elon", "7:00", "7:01", "620");
            Trip trip3 = new Trip("Elon", "0:01", "23:59", "10");
            List<Trip> Trips = new List<Trip>() { trip1, trip2, trip3 };
            driver.Trips = Trips;

            Assert.AreEqual(ExpectPostTripLength, driver.Trips.Count);
        }

        [TestMethod]
        public void TestTotalMilesDrivenCalculation()
        {
            const double ExpectedTotalMilesDriven = 540;

            Driver driver = new Driver("Elon");
            Trip trip1 = new Trip("Elon", "9:15", "10:45", "80");
            Trip trip2 = new Trip("Elon", "7:00", "8:00", "60");
            Trip trip3 = new Trip("Elon", "10:30", "15:45", "400");
            List<Trip> Trips = new List<Trip>() { trip1, trip2, trip3 };
            driver.Trips = Trips;

            Assert.AreEqual(ExpectedTotalMilesDriven, driver.TotalMilesDriven);
        }

        [TestMethod]
        public void TestTotalMilesDrivenRoundedUp()
        {
            const double ExpectedTotalMilesDrivenNotRoundedUp = 540.77;
            const double ExpectedTotalMilesDrivenRoundedUp = 541;

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

        [TestMethod]
        public void TestTotalMilesDrivenRoundedDown()
        {
            const double ExpectedTotalMilesDrivenNotRoundedDown = 540.30;
            const double ExpectedTotalMilesDrivenRoundedDown = 540;

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

        [TestMethod]
        public void TestTotalDrivingTimeCalculation()
        {
            const double ExpectedTotalDrivingTime = 7.75;

            Driver driver = new Driver("Elon");
            Trip trip1 = new Trip("Elon", "9:15", "10:45", "80");
            Trip trip2 = new Trip("Elon", "7:00", "8:00", "60");
            Trip trip3 = new Trip("Elon", "10:30", "15:45", "400");
            List<Trip> Trips = new List<Trip>() { trip1, trip2, trip3 };
            driver.Trips = Trips;

            Assert.AreEqual(ExpectedTotalDrivingTime, driver.TotalDrivingTime);
        }

        [TestMethod]
        public void TestTotalDrivingTimeRoundedUp()
        {
            const double ExpectedTotalDrivingTimeNotRoundedUp = 7.75;
            const double ExpectedTotalDrivingTimeRoundedUp = 8;

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

        [TestMethod]
        public void TestTotalDrivingTimeRoundedDown()
        {
            const double ExpectedTotalDrivingTimeNotRoundedDown = 7.25;
            const double ExpectedTotalDrivingTimeRoundedDown = 7;

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

        [TestMethod]
        public void TestGetAverageSpeedCalculation()
        {
            const double ExpectedAverageSpeed = 69.6774193548387;

            Driver driver = new Driver("Elon");
            Trip trip1 = new Trip("Elon", "9:15", "10:45", "80");
            Trip trip2 = new Trip("Elon", "7:00", "8:00", "60");
            Trip trip3 = new Trip("Elon", "10:30", "15:45", "400");
            List<Trip> Trips = new List<Trip>() { trip1, trip2, trip3 };
            driver.Trips = Trips;

            Assert.AreEqual(ExpectedAverageSpeed, driver.GetAverageSpeed());
        }
        
        [TestMethod]
        public void TestGetAverageSpeedRounedUp()
        {
            const double ExpectedAverageSpeedNotRoundedUp = 69.6774193548387;
            const double ExpectedAverageSpeedRoundedUp = 70;

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

        [TestMethod]
        public void TestGetAverageSpeedRounedDown()
        {
            const double ExpectedAverageSpeedNotRoundedDown = 69.41935483870968;
            const double ExpectedAverageSpeedRoundedDown = 69;

            Driver driver = new Driver("Elon");
            Trip trip1 = new Trip("Elon", "9:15", "10:45", "80");
            Trip trip2 = new Trip("Elon", "7:00", "8:00", "60");
            Trip trip3 = new Trip("Elon", "10:30", "15:45", "398");
            List<Trip> Trips = new List<Trip>() { trip1, trip2, trip3 };
            driver.Trips = Trips;

            Assert.AreEqual(ExpectedAverageSpeedNotRoundedDown, driver.GetAverageSpeed());

            double RoundedAverageSpeed = DrivingReportGenerator.Round(driver.GetAverageSpeed());

            Assert.AreEqual(ExpectedAverageSpeedRoundedDown, RoundedAverageSpeed);
        }
    }

    [TestClass]
    public class TripUnitTests
    {
        
        [TestMethod]
        public void TestTripClassConstruction()
        {
            const string ExpectedTripStart = "9:18";
            const string ExpectedTripEnd = "15:48";
            const double ExpectedMilesDriven = 620;

            Trip trip = new Trip("Elon","9:18", "15:48", "620");
            Assert.AreEqual(ExpectedTripStart, trip.TripStart);
            Assert.AreEqual(ExpectedTripEnd, trip.TripEnd);
            Assert.AreEqual(ExpectedMilesDriven, trip.MilesDriven);
        }

        [TestMethod]
        public void TestTripDurationCalculation()
        {
            const double ExpectedDuration = 0.5;

            Trip trip = new Trip("Elon","7:30", "8:00", "25");
            Assert.AreEqual(ExpectedDuration, trip.TripDuration);
        }

        [TestMethod]
        public void TestGetTripSpeedCalculation()
        {
            const double ExpectedSpeed = 50;

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
        [TestMethod]
        public void TestGenerateReport()
        {
            string ExpectedOutput = string.Format("Lauren: 42 miles @ 34 mph{0}Dan: 39 miles @ 47 mph{0}Kumi: 0 miles{0}", Environment.NewLine);

            using (StringWriter sw = new StringWriter())
            {
                string[] data = { "Driver Dan", "Driver Lauren", "Driver Kumi", "Trip Dan 07:15 07:45 17.3", "Trip Dan 06:12 06:32 21.8", "Trip Lauren 12:01 13:16 42.0" };
                Console.SetOut(sw);
                DrivingReportGenerator drg = new DrivingReportGenerator(data);
                drg.GenerateReport();
                Assert.AreEqual(ExpectedOutput.Trim(), sw.ToString().Trim());
            }
        }

        [TestMethod]
        public void TestSortDrivers()
        {
            const string ExpectedPreSortFirstDriver = "Elon";
            const string ExpectedPostSortFirstDriver = "Jeff";

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
        [TestMethod]
        public void TestParseTripData()
        {
            const int ExpectedTripDataLength = 2;

            string[] data = { "Driver Elon", "Driver Jeff", "Driver Buzz", "Trip Elon 7:30 8:00 25", "Trip Jeff 9:18 15:48 620" };
            List<Trip> TripData = FileParser.ParseTripData(data);
            Assert.AreEqual(ExpectedTripDataLength, TripData.Count);
            Assert.IsInstanceOfType(TripData[0], typeof(Trip));
        }

        [TestMethod]
        public void TestParseDriverData()
        {
            const int ExpectedDriverDataLength = 3;

            string[] data = { "Driver Elon", "Driver Jeff", "Driver Buzz", "Trip Elon 7:30 8:00 25", "Trip Jeff 9:18 15:48 620"};
            List<Driver> DriverData = FileParser.ParseDriverData(data);
            Assert.AreEqual(ExpectedDriverDataLength, DriverData.Count);
            Assert.IsInstanceOfType(DriverData[0], typeof(Driver));
        }
    }
}
