using System;
using System.Collections.Generic;
using System.Linq;

namespace DrivingHistoryTracker
{
    public class DrivingReportGenerator
    {
        public string[] DrivingData { get; set; }
        public List<Driver> Drivers { get; set; }

        /// <summary>
        /// Constructs a new instance of <see cref="DrivingReportGenerator"/> and parses driving data.
        /// </summary>
        /// <param name="drivingData">A list of strings containing Driver and Trip information.</param>
        public DrivingReportGenerator(string[] drivingData)
        {
            DrivingData = drivingData;
            Drivers = FileParser.ParseDriverData(DrivingData);
            MatchTripsToDrivers();
        }

        /// <summary>
        /// Generates a report detailing total miles driven and average speed of all <see cref="Trip"/>s for each <see cref="Driver"/>.
        /// </summary>
        public void GenerateReport()
        {
            SortDrivers();
            foreach (Driver driver in Drivers)
            {
                Console.WriteLine($"{driver.Name}: {Round(driver.TotalMilesDriven)} miles " + $"{(driver.GetAverageSpeed() > 0 ? $"@ {Round(driver.GetAverageSpeed())} mph" : "")}");
            }
        }

        /// <summary>
        /// Rounds a given <see cref="double"/> to the nearest whole number
        /// </summary>
        /// <param name="number"><see cref="Double"/> to be rounded</param>
        /// <returns>Whole number <see cref="double"/></returns>
        public static double Round(double number)
        {
            return Math.Round(number, 0);
        }

        /// <summary>
        /// Sorts <see cref="Driver"/>s List by TotalMilesDriven in descending order.
        /// </summary>
        private void SortDrivers()
        {
            Drivers = Drivers.OrderByDescending(d => d.TotalMilesDriven).ToList();
        }

        /// <summary>
        /// Updates <see cref="Driver"/>s List with their corresponding <see cref="Trip"/>s. 
        /// </summary>
        private void MatchTripsToDrivers()
        {
            List<Trip> Trips = FileParser.ParseTripData(DrivingData);
            foreach (Driver driver in Drivers)
            {
                List<Trip> matches = Trips.Where(t => t.DriverName == driver.Name).ToList();
                driver.Trips = matches;
            }
        }
    }
}
